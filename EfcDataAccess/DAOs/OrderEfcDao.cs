using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class OrderEfcDao : IOrderDao
{

    private readonly PaddleBoardDbContext context;

    public OrderEfcDao(PaddleBoardDbContext context)
    {
        this.context = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        EntityEntry<Order> newOrder = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return newOrder.Entity;
    }
}