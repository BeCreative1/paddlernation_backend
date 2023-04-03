using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xUnit.ApplicationTests;

// [TestFixture]
// public class ReservationTests
// {
// 	[Test]
// 	public void Constructor_SetsProperties()
// 	{
// 		// Arrange
// 		var createdAt = DateTime.Now;
// 		var dateFrom = new DateTime(2022, 04, 01, 10, 0, 0);
// 		var dateTo = new DateTime(2022, 04, 01, 11, 0, 0);
// 		var paddleBoardReservations = new List<PaddleBoardReservation>();
// 		var order = new Order();
//
// 		// Act
// 		var reservation = new Reservation
// 		{
// 			CreatedAt = createdAt,
// 			DateFrom = dateFrom,
// 			DateTo = dateTo,
// 			PaddleBoardReservations = paddleBoardReservations,
// 			OrderedIn = order
// 		};
//
// 		// Assert
// 		Assert.AreEqual(createdAt, reservation.CreatedAt);
// 		Assert.AreEqual(dateFrom, reservation.DateFrom);
// 		Assert.AreEqual(dateTo, reservation.DateTo);
// 		Assert.AreEqual(paddleBoardReservations, reservation.PaddleBoardReservations);
// 		Assert.AreEqual(order, reservation.OrderedIn);
// 	}
//
// 	[Test]
// 	public void PaddleBoardReservations_Getter_ReturnsEmptyListWhenNull()
// 	{
// 		// Arrange
// 		var reservation = new Reservation();
//
// 		// Act
// 		var result = reservation.PaddleBoardReservations;
//
// 		// Assert
// 		Assert.IsNotNull(result);
// 		Assert.IsEmpty(result);
// 	}
//
// 	[Test]
// 	public void OrderedIn_Getter_ReturnsNullWhenNotSet()
// 	{
// 		// Arrange
// 		var reservation = new Reservation();
//
// 		// Act
// 		var result = reservation.OrderedIn;
//
// 		// Assert
// 		Assert.IsNull(result);
// 	}
// }
