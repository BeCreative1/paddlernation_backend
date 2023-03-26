using Domain.Entities;

namespace Application.DaoInterfaces;

public interface IAddressDao
{
    Task<DeliveryAddress> GetByIdAsync(int id);

}