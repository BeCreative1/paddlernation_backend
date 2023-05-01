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
public class DeliveryLogicTest : DbTestBaseClass
{
    private IDeliveryDao _deliveryDao;
    private IAddressDao _addressDao;
    private IDeliveryLogic _deliveryLogic;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _deliveryDao = new DeliveryEfcDao(PaddleBoardDb);
        _addressDao = new AddressEfcDao(PaddleBoardDb);
        _deliveryLogic = new DeliveryLogic(_deliveryDao);
    }

    [TestMethod]
    public async Task CreateDeliveryAsyncPickUpYourselfTest()
    {
        //Arrange
        var address = new Address("Horsens", 8700, "Sundvej");
        var createdAddress = await _addressDao.CreateAsync(address);
        
        var dto = new DeliveryCreationDto()
        {
            Address = createdAddress,
            AddressId = createdAddress.Id,
            DeliveryType = DeliveryType.PickUpYourself
        };
        
        //Act
        var createdDelivery = _deliveryLogic.CreateAsync(dto);
        //Assert
        Assert.IsNotNull(createdDelivery);
        Assert.AreEqual(0, createdDelivery.Result.TotalPrice);
    }
    
    [TestMethod]
    public async Task CreateDeliveryAsyncHomeDeliveryInHorsensTest()
    {
        //Arrange
        var address = new Address("Horsens", 8700, "Sundvej");
        var createdAddress = await _addressDao.CreateAsync(address);
        
        var dto = new DeliveryCreationDto()
        {
            Address = createdAddress,
            AddressId = createdAddress.Id,
            DeliveryType = DeliveryType.HomeDelivery
        };
        
        //Act
        var createdDelivery = _deliveryLogic.CreateAsync(dto);
        //Assert
        Assert.IsNotNull(createdDelivery);
        Assert.AreEqual(0, createdDelivery.Result.TotalPrice);
    }
    
    [TestMethod]
    public async Task CreateDeliveryAsyncHomeDeliveryInVejleTest()
    {
        //Arrange
        var address = new Address("Vejle", 7100, "Strandgade 3");
        var createdAddress = await _addressDao.CreateAsync(address);
        
        var dto = new DeliveryCreationDto()
        {
            Address = createdAddress,
            AddressId = createdAddress.Id,
            DeliveryType = DeliveryType.HomeDelivery
        };
        
        //Act
        var createdDelivery = _deliveryLogic.CreateAsync(dto);
        //Assert
        Assert.IsNotNull(createdDelivery);
        Assert.IsTrue(createdDelivery.Result.TotalPrice > 0);
    }
}