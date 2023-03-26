using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<Order> CreateAsync(OrderCreationDto dto);
}