using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs.PaddleBoard;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

[TestClass]
public class PaddleBoardLogicTest : DbTestBaseClass
{
    private IPaddleBoardLogic _logic;

    [TestInitialize]
    public void SetUp()
    {
        _logic = new PaddleBoardLogic(new PaddleBoardEfcDao(PaddleBoardDb));
    }

    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_ValidDateTest()
    {
        // Arrange
        string dates = "05/05/2023-07/05/2023";


        try
        {
            // Act
            IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);
        }
        catch (Exception e)
        {
            // Assert
            Assert.Fail("Expected no exception, but got: " + e.Message);
        }
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_ValidDateEmptyTest()
    {
        // Arrange
        string dates = "";


        try
        {
            // Act
            IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);
        }
        catch (Exception e)
        {
            // Assert
            Assert.Fail("Expected no exception, but got: " + e.Message);
        }
    }
    
    [TestMethod]
    public void GetAllPaddleBoardsAsync_InvalidDateTest1()
    {
        // Arrange
        string dates = "5/5/23-07/05/2023";

        // Assert
        Assert.ThrowsExceptionAsync<Exception>(async () =>
        {
            // Act
            IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);
        });
    }
    
    [TestMethod]
    public void GetAllPaddleBoardsAsync_InvalidDateTest2()
    {
        // Arrange
        string dates = "05/05/23_07/05/2023";

        // Assert
        Assert.ThrowsExceptionAsync<Exception>(async () =>
        {
            // Act
            IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);
        });
    }
    
    [TestMethod]
    public void GetAllPaddleBoardsAsync_InvalidDateTest3()
    {
        // Arrange
        string dates = "05/05/23 07/05/2023";

        // Assert
        Assert.ThrowsExceptionAsync<Exception>(async () =>
        {
            // Act
            IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);
        });
    }
}