using Domain.Entities;

namespace Application.LogicInterfaces;

public interface IAddressLogic
{
    Task<DeliveryAddress?> GetByIdAsync(int id);
}