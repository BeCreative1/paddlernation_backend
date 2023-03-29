using Domain;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    public Task<Customer?> GetByIdAsync(int id);
}