using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Search;

namespace Application.Logic;

public class ReservationLogic : IReservationLogic
{
	private readonly IReservationDao _reservationDao;

	public ReservationLogic(IReservationDao reservationDao)
	{
		_reservationDao = reservationDao;
	}

	public async Task<IEnumerable<Reservation>> GetAsync()
	{
		IEnumerable<Reservation> reservations = await _reservationDao.GetAsync();

		return reservations;
	}

	public async Task<Reservation> GetByIdAsync(string id)
	{
		Reservation? reservation = await _reservationDao.GetByIdAsync(id);

		if (reservation == null)
		{
			throw new Exception($"Reservation with id {id} was not found!");
		}

		return reservation;
	}
}
