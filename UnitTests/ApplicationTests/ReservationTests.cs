using System.Collections;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace xUnit.ApplicationTests;
[TestClass]
public class ReservationTests
{
	private Mock<IReservationLogic> _logic;

	[TestInitialize]
	public void Setup()
	{
		_logic = new Mock<IReservationLogic>();
	}

	[TestMethod]
	public void Constructor_SetsProperties()
	{
		// Arrange
		var createdAt = DateTime.Now;
		var dateFrom = new DateTime(2022, 04, 01, 10, 0, 0);
		var dateTo = new DateTime(2022, 04, 01, 11, 0, 0);

		// Act
		var reservation = new Reservation
		{
			CreatedAt = createdAt,
			DateFrom = dateFrom,
			DateTo = dateTo
		};

		// Assert
		Assert.AreEqual(createdAt, reservation.CreatedAt);
		Assert.AreEqual(dateFrom, reservation.DateFrom);
		Assert.AreEqual(dateTo, reservation.DateTo);
	}

	[TestMethod]
	public async Task GetAsync_Empty()
	{
		// Act
		var result = await _logic.Object.GetAsync();

		// Assert
		Assert.AreEqual(0, result.Count());
	}

	[TestMethod]
	public async Task GetByIdAsync_Empty()
	{
		// Act
		var result = await _logic.Object.GetByIdAsync(1);


		// Assert
		Assert.AreEqual(null, result);
	}

}
