using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderDao _orderDao;
    private readonly ICustomerDao _customerDao;
    private readonly IAddressDao _addressDao;
    private readonly IDeliveryLogic _deliveryLogic;

    public OrderLogic(IOrderDao orderDao, ICustomerDao customerDao, IAddressDao addressDao, IDeliveryLogic deliveryLogic)
    {
        _orderDao = orderDao;
        _customerDao = customerDao;
        _addressDao = addressDao;
        _deliveryLogic = deliveryLogic;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        try
        {
            //Reservation reservation = new Reservation(DateTime.Today,)
            var customer = await _customerDao.GetByIdAsync(dto.OwnerId);
            if (customer == null)
            {
                throw new Exception($"Customer with id {dto.OwnerId} was not found");
            }

            Address? address = null;
            if (dto.City is not null && dto.Street is not null && dto.Zip is not null)
            {
                var addressToCreate = new Address(dto.City, dto.Zip, dto.Street);
                address = _addressDao.AddressExists(addressToCreate) ?? await _addressDao.CreateAsync(addressToCreate);
            }
            
            var deliveryToCreate = new DeliveryCreationDto()
            {
                DeliveryType = dto.DeliveryType,
                AddressId = address?.Id,
                Address = address
            };
            var createdDelivery = await _deliveryLogic.CreateAsync(deliveryToCreate);
            
            ValidateOrder(dto);
            var orderToCreate = new Order
            {
                TotalPrice = dto.TotalPrice,
                CreatedAt = DateTime.Now,
                //Reservation = {  }
                //ExtrasOrders = {  }
                OrderedBy = customer,
                Delivery = createdDelivery,
                PaymentMethod = dto.PaymentMethod,
                PaymentStage = PaymentStage.Unpaid
            };

            var created = await _orderDao.CreateAsync(orderToCreate);
            return created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderDao.GetByIdAsync(id);
        if (order == null)
        {
            throw new Exception($"Order with id {id} was not found");
        }

        await _orderDao.DeleteAsync(id);

    }

    private void ValidateOrder(OrderCreationDto dto)
    {
        //needs to be implemented
    }
}