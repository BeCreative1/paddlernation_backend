using Application.LogicInterfaces;
using Domain.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using Moq;
namespace xUnit.ApplicationTests;

[TestClass]
public class ReservationsControllerTests
{
    private ReservationsController _reservationsController;

    [TestInitialize]
    public void TestInitialize()
    {
        var mockLogic = new Mock<IReservationLogic>();
        _reservationsController = new ReservationsController(mockLogic.Object);
    }

    [TestMethod]
    public async Task GetByIdAsync_ReturnsOkResult_WhenReservationExists()
    {
        // Arrange
        int id = 1;
        var reservationDto = new ReservationDto
        {
            Id = id,
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now.AddDays(1)
        };
        var expected = new OkObjectResult(reservationDto);

        var mockLogic = new Mock<IReservationLogic>();
        mockLogic.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(reservationDto);
        var controller = new ReservationsController(mockLogic.Object);

        // Act
        var result = await controller.GetByIdAsync(id);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        Assert.AreEqual(expected.Value, ((OkObjectResult)result).Value);
    }

    [TestMethod]
    public async Task GetAsync_ReturnsOkResult_WhenReservationsExist()
    {
        // Arrange
        var reservationDtos = new List<ReservationDto>
        {
            new ReservationDto
            {
                Id = 1,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(1)
            },
            new ReservationDto
            {
                Id = 2,
                DateFrom = DateTime.Now.AddDays(2),
                DateTo = DateTime.Now.AddDays(3)
            }
        };
        var expected = new OkObjectResult(reservationDtos);

        var mockLogic = new Mock<IReservationLogic>();
        mockLogic.Setup(x => x.GetAsync()).ReturnsAsync(reservationDtos);
        var controller = new ReservationsController(mockLogic.Object);

        // Act
        var result = await controller.GetAsync();

        // Assert
