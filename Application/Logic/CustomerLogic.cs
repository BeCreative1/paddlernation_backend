using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class CustomerLogic : ICustomerLogic
{
    private readonly ICustomerDao _customerDao;

    public CustomerLogic(ICustomerDao customerDao)
    {
        this._customerDao = customerDao;
    }

    public async Task<int> CreateAsync(CustomerCreationDto dto)
    {
        var customer = new Customer()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
        };

        var customerId = _customerDao.CustomerExists(customer);

        if (customerId <= 0)
            customerId = await _customerDao.CreateAsync(customer);

        return customerId;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        Customer? customer = await _customerDao.GetByIdAsync(id);
        if (customer == null)
        {
            throw new Exception($"Customer with id {id} was not found");
        }

        return customer;
    }
}