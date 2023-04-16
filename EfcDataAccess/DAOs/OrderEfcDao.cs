using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class OrderEfcDao : IOrderDao
{

    private readonly PaddlerNationContext context;

    public OrderEfcDao(PaddlerNationContext context)
    {
        this.context = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        EntityEntry<Order> newOrder = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return newOrder.Entity;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        Order? order = await context.Orders.AsNoTracking().Include(order => order.OrderedBy)
            .Include(order => order.Delivery)
            .SingleOrDefaultAsync(order => order.Id == id);
        return order;
    }
    public async Task DeleteAsync(int id)
    {
        Order? order = await GetByIdAsync(id);
        if (order == null)
        {
            throw new Exception($"Order with id {id} not found");
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
}