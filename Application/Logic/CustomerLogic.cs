using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerDao customerDao;

    public CustomerLogic(ICustomerDao customerDao)
    {
        this.customerDao = customerDao;
    }

    public async Task<Customer?> GetByIdAsync(int guid)
    {
        Customer? customer = await customerDao.GetByIdAsync(guid);
        if (customer == null)
        {
            throw new Exception($"Customer with guid {guid} does not exist");
        }

        return customer;
    }
}