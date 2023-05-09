using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.PaddleBoard;
using Domain.DTOs.Reservation;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit.Utils;

namespace xUnit.ApplicationTests;

[TestClass]
public class PaddleBoardLogicTest : DbTestBaseClass
{
    private IPaddleBoardLogic _logic;
    private IReservationLogic _reservationLogic;

    [TestInitialize]
    public void SetUp()
    {
        _logic = new PaddleBoardLogic(new PaddleBoardEfcDao(PaddleBoardDb));
        _reservationLogic = new ReservationLogic(new ReservationDao(PaddleBoardDb));

        // Add initial data in to database
        AddInitialData();
    }

    private void AddInitialData()
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

        PaddleBoardDb.PaddleBoardTypes.Add(paddleBoardTypeBig);
        PaddleBoardDb.PaddleBoardTypes.Add(paddleBoardTypeMedium);
        PaddleBoardDb.PaddleBoardTypes.Add(paddleBoardTypeSmall);

        PaddleBoardDb.PaddleBoards.Add(paddleBoardBig1);
        PaddleBoardDb.PaddleBoards.Add(paddleBoardBig2);
        PaddleBoardDb.PaddleBoards.Add(paddleBoardBig3);


        PaddleBoardDb.PaddleBoards.Add(paddleBoardMedium1);
        PaddleBoardDb.PaddleBoards.Add(paddleBoardMedium2);


        PaddleBoardDb.PaddleBoards.Add(paddleBoardSmall1);
        PaddleBoardDb.PaddleBoards.Add(paddleBoardSmall2);

        PaddleBoardDb.SaveChanges();
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
    public async Task GetAllPaddleBoardsAsync_GetAllActivePaddleBoards()
    {
        // Arrange
        string dates = "";

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(5, paddleBoardDtos.Count());
    }

    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_NoReservations()
    {
        // Arrange
        string dates = "05/05/2023-07/05/2023";

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(5, paddleBoardDtos.Count());
    }

    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationNotInBetween()
    {
        // Arrange
        string dates = "05/05/2023-07/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 6, 6, 6, 0, 0),
            DateTo = new DateTime(2023, 6, 6, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(5, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationInBetween()
    {
        // Arrange
        string dates = "05/05/2023-07/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 6, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 6, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_TwoReservationInBetweenWithDifferentPaddleBoards()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 6, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 6, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });
        
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 7, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 7, 12, 0, 0),
            PaddleBoardIds = new List<int> {2}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(3, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_TwoReservationInBetweenWithSamePaddleBoard()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 6, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 6, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });
        
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 7, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 7, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationOverlapping1()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 3, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 7, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationOverlapping2()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 7, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 9, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationOverlapping3()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 1, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 9, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationOverlapOnEdge1()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 3, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 5, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_OneReservationOverlapOnEdge2()
    {
        // Arrange
        string dates = "05/05/2023-08/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 8, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 14, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(4, paddleBoardDtos.Count());
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsAsync_MultipleReservations()
    {
        // Arrange
        string dates = "03/05/2023-09/05/2023";

        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 1, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 4, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });
        
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 8, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 14, 12, 0, 0),
            PaddleBoardIds = new List<int> {1}
        });
        
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 1, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 14, 12, 0, 0),
            PaddleBoardIds = new List<int> {2}
        });
        
        // Skip 3 because it is inactive 
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 2, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 4, 12, 0, 0),
            PaddleBoardIds = new List<int> {4}
        });
        
        // Skip 3 because it is inactive 
        await _reservationLogic.CreateReservationAsync(new ReservationCreationDto
        {
            DateFrom = new DateTime(2023, 5, 8, 6, 0, 0),
            DateTo = new DateTime(2023, 5, 12, 12, 0, 0),
            PaddleBoardIds = new List<int> {4}
        });

        // Act
        IEnumerable<PaddleBoardDto> paddleBoardDtos = await _logic.GetAllPaddleBoardsAsync(dates);

        // Assert
        Assert.AreEqual(2, paddleBoardDtos.Count());
    }
}