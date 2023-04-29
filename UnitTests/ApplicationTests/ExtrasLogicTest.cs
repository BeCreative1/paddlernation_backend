using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using EfcDataAccess.DAOs;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

public class ExtrasLogicTest : DbTestBaseClass
{
    private  ExtrasLogic ExtrasLogic;
    private  IExtrasDao ExtrasDao;

    [TestInitialize]
    public void TestInitialize()
    {
        ExtrasDao = new ExtrasEfcDao(PaddleBoardDb);
        ExtrasLogic = new ExtrasLogic(ExtrasDao);
    }

    [TestMethod]
    public async Task GetAllTestAsync()
    {
        //Arrange
    }
}