using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.PaddleBoard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace xUnit.WebAPITests;

[TestClass]
public class PaddleBoardsControllerTest
{
    private Mock<IPaddleBoardLogic> _mockPaddleBoardLogic;
    private PaddleBoardsController PaddleBoardsController;

    [TestInitialize]
    public void Setup()
    {
        _mockPaddleBoardLogic = new Mock<IPaddleBoardLogic>();
        PaddleBoardsController = new PaddleBoardsController(_mockPaddleBoardLogic.Object);
    }

    [TestMethod]
    public async Task GetAllPaddleBoardsOkTest()
    {
        // Arrange
        var paddleBoards = new List<PaddleBoardDto>()
        {
            new PaddleBoardDto {PaddleBoard = new PaddleBoard {Id = 1, IsActive = true, PaddleBoardReservations = { }, PaddleBoardType = new PaddleBoardType("Big", 15, 1, 6), PaddleBoardTypeID = 1}, Amount = 2},
            new PaddleBoardDto {PaddleBoard = new PaddleBoard {Id = 2, IsActive = true, PaddleBoardReservations = { }, PaddleBoardType = new PaddleBoardType("Small", 5, 1, 2), PaddleBoardTypeID = 2}, Amount = 4},
        };

        _mockPaddleBoardLogic.Setup(m => m.GetAllPaddleBoardsAsync()).ReturnsAsync(paddleBoards);

        // Act
        var results = await PaddleBoardsController.GetAllPaddleBoardsAsync("") as OkObjectResult;

        // Assert
        Assert.IsNotNull(results);
        Assert.AreEqual(paddleBoards, results.Value);
    }
    
    [TestMethod]
    public async Task GetAllPaddleBoardsExceptionTest()
    {
        // Arrange
        _mockPaddleBoardLogic.Setup(m => m.GetAllPaddleBoardsAsync()).ThrowsAsync(new Exception("Invalid date format provided, format should follow \"MM/DD/YYYY-MM/DD/YYYY\""));

        // Act
        var results = await PaddleBoardsController.GetAllPaddleBoardsAsync("4/5/23-May 5, 2012") as ObjectResult;

        // Assert
        Assert.IsNotNull(results);
        Assert.AreEqual(500, results.StatusCode);
        Assert.AreEqual("Invalid date format provided, format should follow \"MM/DD/YYYY-MM/DD/YYYY\"", results.Value);
    }
}