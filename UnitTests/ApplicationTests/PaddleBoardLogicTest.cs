using Application.Logic;
using Application.LogicInterfaces;
using Domain;
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
    public async void SetUp()
    {
        _logic = new PaddleBoardLogic(new PaddleBoardEfcDao(PaddleBoardDb));

        // Add initial data in to database
        await AddInitialData();
    }

    private async Task AddInitialData()
    {
        PaddleBoardType paddleBoardTypeBig = new PaddleBoardType("Big", 15, 2, 6);
        PaddleBoardType paddleBoardTypeMedium = new PaddleBoardType("Medium", 10, 2, 4);
        PaddleBoardType paddleBoardTypeSmall = new PaddleBoardType("Small", 5, 2, 2);

        PaddleBoard paddleBoardBig1 = new PaddleBoard
        {
            IsActive = true,
            PaddleBoardTypeID = 1,
            PaddleBoardType = paddleBoardTypeBig
        };
        PaddleBoard paddleBoardBig2 = new PaddleBoard
        {
            IsActive = true,
            PaddleBoardTypeID = 1,
            PaddleBoardType = paddleBoardTypeBig
        };
        PaddleBoard paddleBoardBig3 = new PaddleBoard
        {
            IsActive = false,
            PaddleBoardTypeID = 1,
            PaddleBoardType = paddleBoardTypeBig
        };
        
        
        PaddleBoard paddleBoardMedium1 = new PaddleBoard
        {
            IsActive = true,
            PaddleBoardTypeID = 2,
            PaddleBoardType = paddleBoardTypeMedium
        };
        PaddleBoard paddleBoardMedium2 = new PaddleBoard
        {
            IsActive = true,
            PaddleBoardTypeID = 2,
            PaddleBoardType = paddleBoardTypeMedium
        };
        
        
        PaddleBoard paddleBoardSmall1 = new PaddleBoard
        {
            IsActive = true,
            PaddleBoardTypeID = 3,
            PaddleBoardType = paddleBoardTypeSmall
        };
        PaddleBoard paddleBoardSmall2 = new PaddleBoard
        {
            IsActive = false,
            PaddleBoardTypeID = 3,
            PaddleBoardType = paddleBoardTypeSmall
        };
        
        await PaddleBoardDb.PaddleBoardTypes.AddAsync(paddleBoardTypeBig);
        await PaddleBoardDb.PaddleBoardTypes.AddAsync(paddleBoardTypeMedium);
        await PaddleBoardDb.PaddleBoardTypes.AddAsync(paddleBoardTypeSmall);
        
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardBig1);
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardBig2);
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardBig3);
        

        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardMedium1);
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardMedium2);
        
        
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardSmall1);
        await PaddleBoardDb.PaddleBoards.AddAsync(paddleBoardSmall2);
        
        await PaddleBoardDb.SaveChangesAsync();
    }

    // --- Exceptions testing ---

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

    // --- Logic testing ---

    [TestMethod]
    public void GetAllPaddleBoardsAsync_GetAllActivePaddleBoards()
    {
        // Arrange

        // Act

        // Assert
    }
}