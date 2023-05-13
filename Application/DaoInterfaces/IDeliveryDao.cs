using Domain;

namespace Application.DaoInterfaces;

public interface IDeliveryDao
{
    Task<Delivery> CreateAsync(Delivery delivery);
    Task<Delivery?> GetByIdAsync(int id);
}