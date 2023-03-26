using Application.DaoInterfaces;
using Domain.Entities;

namespace EfcDataAccess.DAOs;

public class AddressEfcDao : IAddressDao
{
    private readonly PaddleBoardDbContext context;

    public AddressEfcDao(PaddleBoardDbContext context)
    {
        this.context = context;
    }

    public async Task<DeliveryAddress> GetByIdAsync(int id)
    {
        DeliveryAddress? address = await context.DeliveryAddresses.FindAsync(id);
        return address;
    }
}