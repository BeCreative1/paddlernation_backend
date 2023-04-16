using Application.DaoInterfaces;
using Domain;

namespace EfcDataAccess.DAOs;

public class AddressEfcDao : IAddressDao
{
    private readonly PaddlerNationContext context;

    public AddressEfcDao(PaddlerNationContext context)
    {
        this.context = context;
    }

    public async Task<Delivery> GetByIdAsync(int id)
    {
        Delivery? address = await context.Deliveries.FindAsync(id);
        return address;
    }
}