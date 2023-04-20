using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerDao customerDao;

    public CustomerLogic(ICustomerDao customerDao)
    {
        this.customerDao = customerDao;
    }

    public async Task<int> CreateAsync(CustomerCreationDto dto)
    {
        Customer customer = new Customer()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
        };

        var customerId = await CustomerExistsAsync(customer);

        if (customerId <= 0)
            customerId = await customerDao.CreateAsync(customer);

        return customerId;
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

    private async Task<int> CustomerExistsAsync(Customer customer)
    {
        return await customerDao.CustomerExistsAsync(customer);
    }
    
}