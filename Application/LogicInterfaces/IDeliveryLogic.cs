using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IDeliveryLogic
{
    Task<double> CalculateTotalKilometersAsync();
    double CalculateTotalPrice(double totalKilometers);
    Task<Delivery> CreateAsync(DeliveryCreationDto dto);
}