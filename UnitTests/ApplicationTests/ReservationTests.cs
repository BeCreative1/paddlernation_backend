using System.Collections;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using EfcDataAccess.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using xUnit.Utils;

namespace xUnit.ApplicationTests;
[TestClass]
public class ReservationTests : DbTestBaseClass
{
	private IReservationLogic _logic;

	[TestInitialize]
	public void Setup()
	{
		_logic = new ReservationLogic(new ReservationDao(PaddleBoardDb));
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
		var result = await _logic.GetAsync();

		// Assert
		Assert.AreEqual(0, result.Count());
	}

	[TestMethod]
	public async Task GetByIdAsync_Empty()
	{
		// Act
		var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _logic.GetByIdAsync(1));

		// Assert
		Assert.AreEqual("Reservation with id 1 was not found!", exception.Message);
	}

	[TestMethod]
	public async Task GetByIdAsync_ItemExists()
	{
		// Act
		var paddleBoards = new List<int>();
		paddleBoards.Add(1);
		var reservationDto = new ReservationCreationDto()
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = paddleBoards
		};
		await _logic.CreateReservationAsync(reservationDto);
		var response = await _logic.GetByIdAsync(1);

		// Assert
		Assert.AreEqual(1, response.Id);
		Assert.AreEqual(DateTime.Today,response.DateFrom);
		Assert.AreEqual(DateTime.Today.AddDays(1),response.DateTo);
	}


	[TestMethod]
	public async Task CreateReservationAsync_AddsReservationWithPaddleBoardReservations()
	{
		// Arrange
		var paddleBoards = new List<int> { 1, 2 };
		var reservationDto = new ReservationCreationDto
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = paddleBoards
		};

		// Act
		var createdReservation = await _logic.CreateReservationAsync(reservationDto);

		// Assert
		Assert.AreEqual(2, createdReservation.PaddleBoardReservations.Count);
		Assert.AreEqual(1, createdReservation.PaddleBoardReservations.First().PadleBoardID);
	}

	[TestMethod]
	public async Task CreateReservationAsync_ThrowsExceptionWhenPaddleBoardIdsAreNull()
	{
		// Arrange
		var reservationDto = new ReservationCreationDto
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = null
		};

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(() => _logic.CreateReservationAsync(reservationDto));
	}

	[TestMethod]
	public async Task CreateReservationAsync_ThrowsExceptionWhenPaddleBoardIdsAreEmpty()
	{
		// Arrange
		var reservationDto = new ReservationCreationDto
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = new List<int>()
		};

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(() => _logic.CreateReservationAsync(reservationDto));
	}

	[TestMethod]
	public async Task CreateAsync_EmptyPaddleBoards()
	{
		// Arrange

		var reservationDto = new ReservationCreationDto()
		{
			DateFrom = DateTime.Now,
			DateTo = DateTime.Today.AddDays(1)
		};
		// await PaddleBoardDb.Reservations.AddAsync(reservationDto);
		// await PaddleBoardDb.SaveChangesAsync();

		// Act
		var created = await Assert.ThrowsExceptionAsync<Exception>(async () => await _logic.CreateReservationAsync(reservationDto));

		// Assert
		Assert.AreEqual("PaddleBoardReservations cannot be null or empty!", created.Message);


	}

	[TestMethod]
	public async Task CreateReservationAsync_StartDateAfterEndDate_ThrowsException()
	{
		// Arrange
		var paddleBoards = new List<int>();
		paddleBoards.Add(1);
		var reservationDto = new ReservationCreationDto()
		{
			DateFrom = DateTime.Today.AddDays(1),
			DateTo = DateTime.Today,
			PaddleBoardIds = paddleBoards
		};

		// Act and Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () => await _logic.CreateReservationAsync(reservationDto));
	}

	[TestMethod]
	public async Task CreateReservationAsync_InvalidPaddleBoardIds()
	{
		// Arrange
		var paddleBoards = new List<int>();
		paddleBoards.Add(-1);
		var reservationDto = new ReservationCreationDto()
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = paddleBoards
		};

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () => await _logic.CreateReservationAsync(reservationDto));
	}

	[TestMethod]
	public async Task GetByIdAsync_InvalidId()
	{
		// Arrange
		// Act and Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () => await _logic.GetByIdAsync(0));
	}

	[TestMethod]
	public async Task GetByIdAsync_NonExistentId()
	{
		// Arrange
		var paddleBoards = new List<int>();
		paddleBoards.Add(1);
		var reservationDto = new ReservationCreationDto()
		{
			DateFrom = DateTime.Today,
			DateTo = DateTime.Today.AddDays(1),
			PaddleBoardIds = paddleBoards
		};
		await _logic.CreateReservationAsync(reservationDto);
		int id = 100;

		// Act and Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () => await _logic.GetByIdAsync(id));
	}

	[TestMethod]
	public async Task GetAsync_ReturnsReservations()
	{
		// Arrange
		var paddleBoards = new List<int>();
		paddleBoards.Add(1);
		var expectedCount = 2;
		var expectedDates = new List<DateTime> { DateTime.Today, DateTime.Today.AddDays(1) };
		var reservation1 = new ReservationCreationDto { DateFrom = expectedDates[0], DateTo = expectedDates[0].AddDays(1), PaddleBoardIds = paddleBoards};
		var reservation2 = new ReservationCreationDto { DateFrom = expectedDates[1], DateTo = expectedDates[1].AddDays(1), PaddleBoardIds = paddleBoards };
		await _logic.CreateReservationAsync(reservation1);
		await _logic.CreateReservationAsync(reservation2);

		// Act
		var response = await _logic.GetAsync();

		// Assert
		Assert.AreEqual(expectedCount, response.Count());
		Assert.IsTrue(response.Select(r => r.DateFrom).All(expectedDates.Contains));
		Assert.IsTrue(response.Select(r => r.DateTo).All(expectedDates.Select(d => d.AddDays(1)).Contains));
	}

	[TestMethod]
	public async Task GetAsync_ReturnsEmptyList()
	{
		// Act
		var response = await _logic.GetAsync();

		// Assert
		Assert.IsFalse(response.Any());
	}


}
