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

    public async Task<Customer?> GetByIdAsync(int id)
    {
        Customer? customer = await customerDao.GetByIdAsync(id);
        if (customer == null)
        {
            throw new Exception($"Customer with id {id} was not found");
        }

        return customer;
    }
    
}