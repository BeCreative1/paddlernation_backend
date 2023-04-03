using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using Domain.DTOs.Search;

namespace Application.Logic;

public class ReservationLogic : IReservationLogic
{
	private readonly IReservationDao _reservationDao;

	public ReservationLogic(IReservationDao reservationDao)
	{
		_reservationDao = reservationDao;
	}

	public async Task<IEnumerable<ReservationDto>> GetAsync()
	{
		IEnumerable<ReservationDto> reservations = await _reservationDao.GetAsync();

		return reservations;
	}

	public async Task<ReservationDto> GetByIdAsync(string id)
	{
		ReservationDto? reservation = await _reservationDao.GetByIdAsync(id);

		if (reservation == null)
		{
			throw new Exception($"Reservation with id {id} was not found!");
		}

		return reservation;
	}
}
