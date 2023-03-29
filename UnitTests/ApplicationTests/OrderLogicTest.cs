using System.Data.Common;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using EfcDataAccess;
using EfcDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Xunit;
using xUnit.Utils;
using Assert = Xunit.Assert;

namespace xUnit.ApplicationTests;

[TestClass]
public class OrderLogicTest : DbTestBaseClass
{
    private readonly ICustomerDao _customerDao;
    private readonly IAddressDao _addressDao;
    private readonly IOrderDao _orderDao;
    private readonly OrderLogic _orderLogic;

    public OrderLogicTest()
    {
        _customerDao = new CustomerEfcDao(PaddleBoardDb);
        _addressDao = new AddressEfcDao(PaddleBoardDb);
        _orderDao = new OrderEfcDao(PaddleBoardDb);
        _orderLogic = new OrderLogic(_orderDao, _customerDao, _addressDao);
    }

    // [TestMethod]
    // public async Task OrderCreateAsyncTest()
    // {
    //     // Arrange
    //     Customer? customer = new Customer{ FullName = "John", Email = "john@example.com", Phone = "1234567890" };
    //     await PaddleBoardDb.Customers.AddAsync(customer);
    //     await PaddleBoardDb.SaveChangesAsync();
    //
    //     var address = new DeliveryAddress();
    //     await PaddleBoardDb.DeliveryAddresses.AddAsync(address);
    //     await PaddleBoardDb.SaveChangesAsync();
    //
    //     var order = new OrderCreationDto(120, 0, DateTime.Now, 0, 1, 1);
    //
    //     Task<Customer?> cust = _customerDao.GetByIdAsync(1);
    //     Console.WriteLine(cust.Id);
    //     var createdOrder = await _orderLogic.CreateAsync(order);
    //
    //     // Act
    //
    //     // Assert
    //     //Assert.NotNull(createdOrder);
    //     //Assert.Equal(order.OwnerId, createdOrder.Customer.Id);
    //     //Assert.Equal(order.AddressId, createdOrder.DeliveryAddress.Id);
    // }

    // [TestMethod]
    // public async Task CreateAsyncTest()
    // {
    //     var customer = new Customer { Id = 1, FullName= "John", Email = "123@viauc.dk", Phone = "12345"};
    //     await PaddleBoardDb.Customers.AddAsync(customer);
    //     await PaddleBoardDb.SaveChangesAsync();
    //
    //     var customerLogic = new CustomerLogic(_customerDao);
    //
    //     var result = await customerLogic.GetByIdAsync(1);
    //
    //     Assert.Equal(1, result.Id);
    //
    // }
}