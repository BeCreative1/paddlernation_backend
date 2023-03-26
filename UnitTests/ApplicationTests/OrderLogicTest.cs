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
using Xunit;
using xUnit.Utils;
using Assert = Xunit.Assert;

namespace xUnit.ApplicationTests;

[TestClass]
public class OrderServiceTests : DbTestBaseClass
{
    private readonly ICustomerDao _customerDao;
    private readonly IAddressDao _addressDao;
    private readonly IOrderDao _orderDao;

    public OrderServiceTests()
    {
        _customerDao = new CustomerEfcDao(PaddleBoardDb);
        _addressDao = new AddressEfcDao(PaddleBoardDb);
        _orderDao = new OrderEfcDao(PaddleBoardDb);
    }

    [TestMethod]
    public async Task CreateAsync_ShouldCreateOrder_WhenValidDtoProvided()
    {
        // Arrange
        var customer = new Customer { Id = 1, FullName= "John", Email = "123@viauc.dk", Phone = "12345"};
        var address = new DeliveryAddress { Id = 1};
        await PaddleBoardDb.DeliveryAddresses.AddAsync(address);
        await PaddleBoardDb.Customers.AddAsync(customer);
        await PaddleBoardDb.SaveChangesAsync();

        var dto = new OrderCreationDto(120, 1, DateTime.Now, 1, 1, 1);
        var orderLogic = new OrderLogic(_orderDao, _customerDao, _addressDao); 

        // Act
        var result = await orderLogic.CreateAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dto.CreatedAt, result.CreatedAt);
        Assert.Equal(customer, result.Customer);
        Assert.Equal(address, result.DeliveryAddress);
    }

    // [Fact]
    // public async Task CreateAsync_ShouldThrowException_WhenInvalidDtoProvided()
    // {
    //     // Arrange
    //     var dto = new OrderCreationDto
    //     {
    //         OwnerId = Guid.NewGuid(),
    //         AddressId = Guid.NewGuid(),
    //         CreatedAt = DateTime.UtcNow
    //     };
    //
    //     var orderService = new OrderService(_customerDao, _addressDao, _orderDao);
    //
    //     // Act & Assert
    //     await Assert.ThrowsAsync<Exception>(() => orderService.CreateAsync(dto));
    // }
}