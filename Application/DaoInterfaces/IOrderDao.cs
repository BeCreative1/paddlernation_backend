using Domain;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<Order> CreateAsync(Order order);
    Task<Order?> GetByIdAsync(int id);

    Task DeleteAsync(int id);

}