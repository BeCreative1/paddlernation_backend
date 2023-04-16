using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class CustomerEfcDao : ICustomerDao
{
    private readonly PaddlerNationContext context;

    public CustomerEfcDao(PaddlerNationContext context)
    {
        this.context = context;
    }
    public async Task<Customer?> GetByIdAsync(int id)
    {
        Customer? customer = await context.Customers.FindAsync(id);
        return customer;    
    }
}