using Application.DaoInterfaces;
using Domain;

namespace EfcDataAccess.DAOs;

public class DeliveryEfcDao : IDeliveryDao
{
    private readonly PaddlerNationContext _context;

    public DeliveryEfcDao(PaddlerNationContext context)
    {
        _context = context;
    }
    
    public async Task<Delivery> CreateAsync(Delivery delivery)
    {
        var created = await _context.Deliveries.AddAsync(delivery);
        return created.Entity;
    }

    public async Task<Delivery?> GetByIdAsync(int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        return delivery;
    }
}