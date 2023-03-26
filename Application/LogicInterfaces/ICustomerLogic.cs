using Domain;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    Task<Customer?> GetByIdAsync(int guid);
}