using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
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
    private IDeliveryDao _deliveryDao;
    private IDeliveryLogic _deliveryLogic;

    [TestInitialize]
    public void TestInitialize()
    {
        _customerDao = new CustomerEfcDao(PaddleBoardDb);
        _addressDao = new AddressEfcDao(PaddleBoardDb);
        _orderDao = new OrderEfcDao(PaddleBoardDb);
        _deliveryDao = new DeliveryEfcDao(PaddleBoardDb);
        _orderLogic = new OrderLogic(_orderDao, _customerDao, _addressDao, _deliveryLogic);
    }

    [TestMethod]
    public async Task OrderCreateAsyncTest()
    {
        // Arrange
        var customer = new Customer{ FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        await PaddleBoardDb.Customers.AddAsync(customer);
        await PaddleBoardDb.SaveChangesAsync();
    
        var order = new OrderCreationDto(120, PaymentMethod.CreditCard, customer.Id,  DeliveryType.HomeDelivery, 1, 1, "ciy", 8000, "Street");
        
        // Act
        var createdOrder = await _orderLogic.CreateAsync(order);

        // Assert
        Assert.IsNotNull(createdOrder);
        Assert.AreEqual(order.OwnerId, createdOrder.OrderedBy.Id);
    }
    
}