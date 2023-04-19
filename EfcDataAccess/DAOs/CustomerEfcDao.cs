using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class CustomerEfcDao : ICustomerDao
{
    private readonly PaddlerNationContext _context;

    public CustomerEfcDao(PaddlerNationContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Customer customer)
    {
        var createdCustomer = await _context.Customers.AddAsync(customer);
        return createdCustomer.Entity.Id;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        Customer? customer = await _context.Customers.FindAsync(id);
        return customer;    
    }

    public async  Task<int> CustomerExists(Customer customer)
    {
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.FullName.Equals(customer.FullName) && c.Email.Equals(customer.Email) && c.Phone.Equals(customer.Phone));

        if (existingCustomer is not null)
            return existingCustomer.Id;

        return -1;
    }
}