using Application.DaoInterfaces;
using Application.Logic;
using Domain;
using Domain.DTOs;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using xUnit.Utils;


namespace xUnit.ApplicationTests;

[TestClass]
public class OrderLogicTest : DbTestBaseClass
{
    private  ICustomerDao _customerDao;
    private  IAddressDao _addressDao;
    private  IOrderDao _orderDao;
    private  OrderLogic _orderLogic;

    [TestInitialize]
    public void TestInitialize()
    {
        _customerDao = new CustomerEfcDao(PaddleBoardDb);
        _addressDao = new AddressEfcDao(PaddleBoardDb);
        _orderDao = new OrderEfcDao(PaddleBoardDb);
        _orderLogic = new OrderLogic(_orderDao, _customerDao, _addressDao);
    }

    [TestMethod]
    public async Task OrderCreateAsyncTest()
    {
        // Arrange
        Customer? customer = new Customer{ FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        await PaddleBoardDb.Customers.AddAsync(customer);
        await PaddleBoardDb.SaveChangesAsync();
    
        var address = new Delivery();
        await PaddleBoardDb.Deliveries.AddAsync(address);
        await PaddleBoardDb.SaveChangesAsync();
    
        var order = new OrderCreationDto(120, 0, DateTime.Now,  0, 1, 1);
        
        // Act
        var createdOrder = await _orderLogic.CreateAsync(order);

        // Assert
        Assert.IsNotNull(createdOrder);
        Assert.AreEqual(order.OwnerId, createdOrder.OrderedBy.Id);
        Assert.AreEqual(order.AddressId, createdOrder.Delivery.Id);
    }
    
}