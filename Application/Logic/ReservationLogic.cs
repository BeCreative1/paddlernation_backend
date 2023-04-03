using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Reservation;

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

	public async Task<ReservationDto> GetByIdAsync(int id)
	{
		ReservationDto? reservation = await _reservationDao.GetByIdAsync(id);

		if (reservation == null)
		{
			throw new Exception($"Reservation with id {id} was not found!");
		}

		return reservation;
	}

	public async Task<ReservationDto> CreateReservationAsync(ReservationCreationDto reservationDto)
	{
		Validate(reservationDto);

		return await _reservationDao.CreateReservationAsync(reservationDto);

	}

	private void Validate(ReservationCreationDto dto)
	{
		// Validate input
		if (dto == null)
		{
			throw new ArgumentNullException(nameof(dto));
		}

		//The start date must be before the end date.
		if (dto.DateFrom >= dto.DateTo)
		{
			throw new Exception("The start date must be before the end date.");
		}

		//CreatedAt must be earlier than or equal to DateFrom:
		if (dto.CreatedAt > dto.DateFrom)
		{
			throw new Exception("CreatedAt must be earlier than or equal to DateFrom");
		}

		//PaddleBoardReservations cannot be null or empty:
		if (dto.PaddleBoardReservations == null || dto.PaddleBoardReservations.Count == 0)
		{
			throw new Exception("PaddleBoardReservations cannot be null or empty");
		}

	}
}
