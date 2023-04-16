using Domain;

namespace Application.DaoInterfaces;

public interface IAddressDao
{
    Task<Delivery> GetByIdAsync(int id);

}