using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class AddressLogic : IAddressLogic
{
    private readonly IAddressDao addressDao;

    public AddressLogic(IAddressDao addressDao)
    {
        this.addressDao = addressDao;
    }

    public async Task<Delivery?> GetByIdAsync(int id)
    {
        Delivery? address = await addressDao.GetByIdAsync(id);
        if (address == null)
        {
            throw new Exception($"Address with id {id} was not found");
        }

        return address;
    }
}