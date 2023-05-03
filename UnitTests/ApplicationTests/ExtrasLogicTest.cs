using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using EfcDataAccess.DAOs;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

[TestClass]
public class ExtrasLogicTest : DbTestBaseClass
{
    private  ExtrasLogic ExtrasLogic;
    private  IExtrasDao ExtrasDao;

    [TestInitialize]
    public async Task TestInitialize()
    {
        ExtrasDao = new ExtrasEfcDao(PaddleBoardDb);
        ExtrasLogic = new ExtrasLogic(ExtrasDao);
        
        await CreateDummyDataAsync();
    }

    private async Task CreateDummyDataAsync()
    {
        Extra extra1 = new Extra(5, "GoPro", 15 , "", 2);
        Extra extra2 = new Extra(1, "Drone", 55.5 , "", 1);

        await ExtrasDao.CreateAsync(extra1);
        await ExtrasDao.CreateAsync(extra2);
    }

    [TestMethod]
    public async Task GetAllTestAsync()
    {
        //Act
        IEnumerable<Extra> extras = await ExtrasLogic.GetAllAsync();

        //Assert
        Assert.AreEqual(2, extras.Count());
    }
    
    [TestMethod]
    public async Task GetByIdAsync()
    {
        //Act
        Extra? extra = await ExtrasLogic.GetByIdAsync(1);

        //Assert
        Assert.AreEqual("GoPro", extra?.Name);
    }
    
    [TestMethod]
    public async Task GetByIdNullAsync()
    {
        //Act
        Extra? extra = await ExtrasLogic.GetByIdAsync(3);

        //Assert
        Assert.AreEqual(null, extra);
    }
}