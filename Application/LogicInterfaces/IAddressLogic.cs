using Domain;

namespace Application.LogicInterfaces;

public interface IAddressLogic
{
    Task<Address?> GetByIdAsync(int id);
}