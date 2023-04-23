using Application.DaoInterfaces;
using Domain;

namespace EfcDataAccess.DAOs;

public class AddressEfcDao : IAddressDao
{
    private readonly PaddlerNationContext _context;

    public AddressEfcDao(PaddlerNationContext context)
    {
        _context = context;
    }

    public async Task<Address> CreateAsync(Address address)
    {
        var created = await _context.Addresses.AddAsync(address);
        return created.Entity;
    }

    public async Task<Address?> GetByIdAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        return address;
    }

    public Address? AddressExists(Address address)
    {
        var existingAddress = _context.Addresses.Local.SingleOrDefault(a => a.City.Equals(address.City) && a.Street.Equals(address.Street) && a.Zip == address.Zip);

        return existingAddress ?? null;
    }
}