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
            new PaddleBoardDto
            {
                Id = 1,
                MaxCapacity = 6,
                MinCapacity = 2,
                NameOfType = "Big",
                PaddleBoardTypeID = 1,
                Price = 15
            },
            new PaddleBoardDto
            {
                Id = 2,
                MaxCapacity = 4,
                MinCapacity = 2,
                NameOfType = "Medium",
                PaddleBoardTypeID = 2,
                Price = 10
            }
        };

        _mockPaddleBoardLogic.Setup(m => m.GetAllPaddleBoardsAsync("")).ReturnsAsync(paddleBoards);

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
        _mockPaddleBoardLogic.Setup(m => m.GetAllPaddleBoardsAsync("4/5/23-May 5, 2012")).ThrowsAsync(
            new Exception("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\""));

        // Act
        var results = await PaddleBoardsController.GetAllPaddleBoardsAsync("4/5/23-May 5, 2012") as ObjectResult;

        // Assert
        Assert.IsNotNull(results);
        Assert.AreEqual(500, results.StatusCode);
        Assert.AreEqual("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\"", results.Value);
    }
}