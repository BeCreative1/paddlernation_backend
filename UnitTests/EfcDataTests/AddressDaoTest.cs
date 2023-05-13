using Application.DaoInterfaces;
using Domain;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.EfcDataTests;

[TestClass]
public class AddressDaoTest : DbTestBaseClass
{
    private IAddressDao _addressDao;

    [TestInitialize]
    public void TestInitialize()
    {
        _addressDao = new AddressEfcDao(PaddleBoardDb);
    }

    [TestMethod]
    public async Task CreateAddressAsync()
    {
        //Arrange
        var address = new Address("City", 8700, "Street");
        //Act
        var result = await _addressDao.CreateAsync(address);
        //Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetByIdNotFound()
    {
        //Arrange
        //Act
        var result = await _addressDao.GetByIdAsync(2);
        //Assert
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public async Task GetByIdFound()
    {
        //Arrange
        var address = new Address("City", 8700, "Street");
        //Act
        var createdAddress = await _addressDao.CreateAsync(address);
        var result = await _addressDao.GetByIdAsync(createdAddress.Id);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreSame(address,result);
    }
    
    [TestMethod]
    public async Task AddressExists()
    {
        //Arrange
        var address = new Address("City", 8700, "Street");
        //Act
        var createdAddress = await _addressDao.CreateAsync(address);
        var result = _addressDao.AddressExists(createdAddress);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreSame(address,result);
    }
    
    [TestMethod]
    public void AddressDoesNotExists()
    {
        //Arrange
        var address = new Address("City", 8700, "Street");
        //Act
        var result = _addressDao.AddressExists(address);
        //Assert
        Assert.IsNull(result);
    }
}