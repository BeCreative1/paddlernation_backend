using Domain;

namespace Application.DaoInterfaces;

public interface IAddressDao
{
    Task<Address> CreateAsync(Address address);
    Task<Address?> GetByIdAsync(int id);
    Address? AddressExists(Address address);

}