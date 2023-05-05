using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Application.Utils;
using BingMapsRESTToolkit;
using Domain;
using Domain.DTOs;
using Microsoft.Configuration.ConfigurationBuilders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Address = Domain.Address;

namespace Application.Logic;

public class DeliveryLogic : IDeliveryLogic
{
    private readonly IDeliveryDao _deliveryDao;
    private readonly IConfigurationRoot _configuration;
    private readonly string? _apiKey = "";

    public DeliveryLogic(IDeliveryDao deliveryDao)
    {
        _deliveryDao = deliveryDao;
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets<DeliveryLogic>()
            .Build();
        _apiKey = _configuration["BING_MAP_API"];
        
        if (string.IsNullOrWhiteSpace(_apiKey))
        {
            _apiKey = Environment.GetEnvironmentVariable("BING_MAP_API")!;
        }
        
    }
    
    private async Task<double> CalculateTotalKilometersAsync(DeliveryCreationDto dto)
    {
        if (dto.Address is null)
            return 0;
        
        var origin = new SimpleWaypoint
        {
            Coordinate = GetCoordinates(Constants.GENERAL_ADDRESS, _apiKey).Result
        };
        var destination = new SimpleWaypoint
        {
            Coordinate = GetCoordinates(dto.Address, _apiKey).Result
        };

        return await GetTotalDistance(origin, destination, _apiKey);
    }

    private static async Task<double> GetTotalDistance(SimpleWaypoint origin, SimpleWaypoint destination, string apiKey)
    {
        var request = new DistanceMatrixRequest()
        {
            Origins = new List<SimpleWaypoint>
            {
                origin
            },
            Destinations = new List<SimpleWaypoint>
            {
                destination
            },
            TravelMode = TravelModeType.Driving,
            BingMapsKey = apiKey
        };
        
        //Process the request by using the ServiceManager.
        var response = await request.Execute();

        if (response is not { ResourceSets.Length: > 0 } ||
            response.ResourceSets[0].Resources is not { Length: > 0 }) return -1;

        if (response.ResourceSets[0].Resources[0] is DistanceMatrix result) return result.Results[0].TravelDistance;

        return 0;
    }

    
    private static async Task<Coordinate?> GetCoordinates(Address a, string apiKey)
    {
        //Create a request.
        var request = new GeocodeRequest()
        {
            Address = new SimpleAddress
            {
                Locality = a.City,
                PostalCode = a.Zip + ""
            },
            MaxResults = 1,
            BingMapsKey = apiKey
        };
        
        //Process the request by using the ServiceManager.
        var response = await request.Execute();

        if (response is not { ResourceSets.Length: > 0 } ||
            response.ResourceSets[0].Resources is not { Length: > 0 }) return null;
        
        var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;

        return result?.Point.GetCoordinate();
    }

    private static double CalculateTotalPrice(double totalKilometers)
    {
        return totalKilometers * Constants.PRICE_PER_KILOMETER;
    }

    public Task<Delivery> CreateAsync(DeliveryCreationDto dto)
    {
        Delivery deliveryToCreate;
        if (dto.DeliveryType == DeliveryType.PickUpYourself)
        {
            deliveryToCreate = new Delivery
            {
                DeliveryType = dto.DeliveryType,
                TotalKilometers = 0,
                TotalPrice = 0,
            };
        }
        else
        {
            var totalKilometers = CalculateTotalKilometersAsync(dto).Result;
                    var totalPrice = CalculateTotalPrice(totalKilometers);
                    deliveryToCreate = new Delivery
                    {
                        DeliveryType = dto.DeliveryType,
                        TotalKilometers = totalKilometers,
                        TotalPrice = totalPrice,
                        AtID = dto.AddressId,
                        At = dto.Address
                    };
        }
        

        var created = _deliveryDao.CreateAsync(deliveryToCreate);

        return created;
    }
}