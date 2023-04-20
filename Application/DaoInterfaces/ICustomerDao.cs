using Domain;

namespace Application.DaoInterfaces;

public interface ICustomerDao
{
    Task<int> CreateAsync(Customer customer);
    Task<Customer?> GetByIdAsync(int id);
    Task<int> CustomerExistsAsync(Customer customer);
}