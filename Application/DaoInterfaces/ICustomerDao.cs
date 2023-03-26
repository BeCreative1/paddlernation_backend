using Domain;

namespace Application.DaoInterfaces;

public interface ICustomerDao
{
    Task<Customer?> GetByIdAsync(int id);
}