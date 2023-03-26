using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Logic;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderDao orderDao;
    private readonly ICustomerDao customerDao;
    private readonly IAddressDao addressDao;

    public OrderLogic(IOrderDao orderDao, ICustomerDao customerDao, IAddressDao addressDao)
    {
        this.orderDao = orderDao;
        this.customerDao = customerDao;
        this.addressDao = addressDao;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        try
        {
            Customer? customer = await customerDao.GetByIdAsync(dto.OwnerId);
            if (customer == null)
            {
                throw new Exception($"Customer with guid {dto.OwnerId} was not found");
            }

            DeliveryAddress? deliveryAddress = await addressDao.GetByIdAsync(dto.AddressId);
            if (deliveryAddress == null)
            {
                throw new Exception($"Address with id {dto.AddressId} was not found");
            }
            
            
            ValidateOrder(dto);
            Order orderToCreate = new Order()
            {
                CreatedAt = dto.CreatedAt,
                Customer = customer,
                DeliveryAddress = deliveryAddress
                //TODO missing data
            };
            Order created = await orderDao.CreateAsync(orderToCreate);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void ValidateOrder(OrderCreationDto dto)
    {
        
    }
}