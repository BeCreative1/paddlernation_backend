using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Reservation;

namespace Application.Logic;

public class ReservationLogic : IReservationLogic
{
	private readonly IReservationDao _reservationDao;
	// private readonly IPaddleBoardLogic _paddleBoardLogic;

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

		var reservation = new Reservation()
		{
			CreatedAt = DateTime.UtcNow,
			DateFrom = reservationDto.DateFrom,
			DateTo = reservationDto.DateTo,
			PaddleBoardReservations = new List<PaddleBoardReservation>()
		};

		foreach (var id in reservationDto.PaddleBoardIds)
		{
			reservation.PaddleBoardReservations.Add(new PaddleBoardReservation()
			{
				ReservationID = reservation.Id,
				PadleBoardID = id
			});
		}

		var created = await _reservationDao.CreateReservationAsync(reservation);

		return new ReservationDto()
		{
			Id = created.Id,
			CreatedAt = created.CreatedAt,
			DateFrom = created.DateFrom,
			DateTo = created.DateTo,
			PaddleBoardReservations = created.PaddleBoardReservations,
		};

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

		//PaddleBoardReservations cannot be null or empty:
		if (dto.PaddleBoardIds == null || dto.PaddleBoardIds.Count == 0)
		{
			throw new Exception("PaddleBoardReservations cannot be null or empty");
		}

	}

}
