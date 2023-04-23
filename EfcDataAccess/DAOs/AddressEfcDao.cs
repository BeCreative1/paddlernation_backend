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

    public async Task<Address> GetByIdAsync(int id)
    {
        Address? address = await context.Addresses.FindAsync(id);
        return address;
    }
}
