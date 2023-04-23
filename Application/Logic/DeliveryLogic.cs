using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Application.Utils;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class DeliveryLogic : IDeliveryLogic
{
    private readonly IDeliveryDao _deliveryDao;

    public DeliveryLogic(IDeliveryDao deliveryDao)
    {
        _deliveryDao = deliveryDao;
    }
    
    public Task<double> CalculateTotalKilometersAsync()
    {
        throw new NotImplementedException();
    }

    public double CalculateTotalPrice(double totalKilometers)
    {
        return totalKilometers * Constants.PRICE_PER_KILOMETER;
    }

    public Task<Delivery> CreateAsync(DeliveryCreationDto dto)
    {
        var totalKilometers = CalculateTotalKilometersAsync();
        var totalPrice = CalculateTotalPrice(totalKilometers.Result);
        var deliveryToCreate = new Delivery
        {
            DeliveryType = dto.DeliveryType,
            TotalKilometers = totalKilometers.Result,
            TotalPrice = totalPrice,
            AtID = dto.AddressId,
            At = dto.Address
        };

        var created = _deliveryDao.CreateAsync(deliveryToCreate);

        return created;
    }
}