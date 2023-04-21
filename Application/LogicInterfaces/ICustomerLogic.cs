using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    public Task<int> CreateAsync(CustomerCreationDto dto);
    public Task<Customer?> GetByIdAsync(int id);
}