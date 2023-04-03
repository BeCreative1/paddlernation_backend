using Application.DaoInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class ReservationDao : IReservationDao
{

	private readonly PaddlerNationContext _context;

	public ReservationDao(PaddlerNationContext context)
	{
		_context = context;
	}
	public async Task<IEnumerable<ReservationDto>> GetAsync()
	{
		IEnumerable<Reservation> reservations = await _context.Reservations.ToListAsync();

		return reservations.Select(r => new ReservationDto
		{
			Id = r.Id,
			CreatedAt = r.CreatedAt,
			DateFrom = r.DateFrom,
			DateTo = r.DateTo,
			//TODO there is no setter
			PaddleBoardReservations = {},
			OrderedIn = { }
		});

	}

	public async Task<ReservationDto?> GetByIdAsync(int id)
	{
		Reservation? r = await _context.Reservations.FindAsync(id);

		if (r == null)
		{
			return null;
		}
		return new ReservationDto
		{
			Id = r.Id,
			CreatedAt = r.CreatedAt,
			DateFrom = r.DateFrom,
			DateTo = r.DateTo,
			//TODO there is no setter
			PaddleBoardReservations = {},
			OrderedIn = { }
		};
	}

	public async Task<ReservationDto> CreateReservationAsync(ReservationCreationDto reservationDto)
	{
		var reservationEntity = new Reservation
		{
			CreatedAt = reservationDto.CreatedAt,
			DateFrom = reservationDto.DateFrom,
			DateTo = reservationDto.DateTo,
			//TODO there is no setter
			// PaddleBoardReservations = reservationDto.PaddleBoardReservations,
			// OrderedIn = reservationDto.OrderedIn
		};
		await _context.Reservations.AddAsync(reservationEntity);
		await _context.SaveChangesAsync();

		return new ReservationDto()
		{
			Id = reservationEntity.Id,
			CreatedAt = reservationEntity.CreatedAt,
			DateFrom = reservationEntity.DateFrom,
			DateTo = reservationEntity.DateTo,
			//TODO there is no setter
			PaddleBoardReservations = {},
			OrderedIn = { }
		};
	}
}
