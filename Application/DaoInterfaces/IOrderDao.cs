using Domain;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<Order> CreateAsync(Order order);
}