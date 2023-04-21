using Application.DaoInterfaces;
using Application.Logic;
using Domain;
using Domain.DTOs;
using EfcDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

[TestClass]
public class CustomerLogicTest : DbTestBaseClass
{
    private ICustomerDao _customerDao;
    private CustomerLogic _customerLogic;

    [TestInitialize]
    public void TestInitialize()
    {
        _customerDao = new CustomerEfcDao(PaddleBoardDb);
        _customerLogic = new CustomerLogic(_customerDao);
    }

    [TestMethod]
    public async Task CustomerCreateAsyncTest()
    {
        //Arrange
        CustomerCreationDto customerToCreate = new CustomerCreationDto { FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        //Act
        var customerId = await _customerLogic.CreateAsync(customerToCreate);
        //Assert
        Assert.IsNotNull(customerId);
        Assert.IsNotNull(await PaddleBoardDb.Customers.FindAsync(customerId));
    }
    
    [TestMethod]
    public async Task GetByIdAsyncTest()
    {
        //Arrange
        var customerToCreate = new CustomerCreationDto { FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        //Act
        var customerId = await _customerLogic.CreateAsync(customerToCreate);
        var customerFromDb = await _customerLogic.GetByIdAsync(customerId);
        //Assert
        Assert.IsNotNull(customerId);
        Assert.IsNotNull(customerFromDb);
        Assert.AreEqual(customerToCreate.FullName, customerFromDb.FullName);
        Assert.AreEqual(customerToCreate.Email, customerFromDb.Email);
        Assert.AreEqual(customerToCreate.Phone, customerFromDb.Phone);
    }
    
    [TestMethod]
    public async Task CustomerExistsAsyncTest()
    {
        //Arrange
        var customerToCreate = new CustomerCreationDto { FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        var customerToExist = new Customer { FullName = "John", Email = "john@example.com", Phone = "1234567890" };
        //Act
        var customerId = await _customerLogic.CreateAsync(customerToCreate);
        var existingCustomerId = await _customerDao.CustomerExistsAsync(customerToExist);
        //Assert
        Assert.IsNotNull(customerId);
        Assert.IsNotNull(existingCustomerId);
        Assert.AreEqual(customerId, existingCustomerId);
    }
}