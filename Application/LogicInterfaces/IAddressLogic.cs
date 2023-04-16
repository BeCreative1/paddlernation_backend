using Domain;

namespace Application.LogicInterfaces;

public interface IAddressLogic
{
    Task<Delivery?> GetByIdAsync(int id);
}