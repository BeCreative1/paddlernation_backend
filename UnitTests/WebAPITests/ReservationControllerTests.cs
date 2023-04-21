using System.Threading.Channels;
using Application.LogicInterfaces;
using Domain.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace xUnit.WebAPITests;

[TestClass]
public class ReservationsControllerTests
{

	private Mock<IReservationLogic> _mockReservationLogic;
	private ReservationsController _reservationsController;

	[TestInitialize]
	public void Setup()
	{
		_mockReservationLogic = new Mock<IReservationLogic>();
		_reservationsController = new ReservationsController(_mockReservationLogic.Object);
	}

	[TestMethod]
	public async Task GetAsync()
	{
		// Arrange
		var reservations = new List<ReservationDto>()
		{
			new ReservationDto { Id = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(1) },
			new ReservationDto { Id = 2, DateFrom = DateTime.Now.AddDays(2), DateTo = DateTime.Now.AddDays(3) }
		};

		_mockReservationLogic.Setup(x => x.GetAsync()).ReturnsAsync(reservations);

		// Act
		var result = await _reservationsController.GetAsync();

		// // Assert
		Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
	}

	[TestMethod]
	public async Task GetByIdAsync()
	{
		// Arrange
		var reservations = new List<ReservationDto>()
		{
			new ReservationDto { Id = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(1) },
			new ReservationDto { Id = 2, DateFrom = DateTime.Now.AddDays(2), DateTo = DateTime.Now.AddDays(3) }
		};

		_mockReservationLogic.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(new ReservationDto { Id = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(1) });

		// Act
		var result = await _reservationsController.GetByIdAsync(4);

		Console.WriteLine(result.Result);

		// // Assert
		Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
	}
}
