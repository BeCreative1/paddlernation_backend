using Application.DaoInterfaces;
using Domain;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.EfcDataTests;

[TestClass]
public class DeliveryDaoTest : DbTestBaseClass
{
    private IDeliveryDao _deliveryDao;

    [TestInitialize]
    public void TestInitialize()
    {
        _deliveryDao = new DeliveryEfcDao(PaddleBoardDb);
    }

    [TestMethod]
    public async Task DeliveryCreateAsyncTest()
    {
        //Arrange
        var delivery = new Delivery
        {
            DeliveryType = DeliveryType.HomeDelivery,
            TotalPrice = 100.0,
            TotalKilometers = 50.0,
        };
        //Act
        var result = await _deliveryDao.CreateAsync(delivery);
        //Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetByAsyncNotFound()
    {
        //Arrange
        //Act
        var result = await _deliveryDao.GetByIdAsync(2);
        //Assert
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public async Task GetByAsyncDeliveryFound()
    {
        //Arrange
        var delivery = new Delivery
        {
            DeliveryType = DeliveryType.HomeDelivery,
            TotalPrice = 100.0,
            TotalKilometers = 50.0,
        };
        //Act
        var createdDelivery = await _deliveryDao.CreateAsync(delivery);
        var result = await _deliveryDao.GetByIdAsync(createdDelivery.Id);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreSame(delivery, result);
    }
}