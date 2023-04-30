using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IDeliveryLogic
{
    Task<Delivery> CreateAsync(DeliveryCreationDto dto);
}