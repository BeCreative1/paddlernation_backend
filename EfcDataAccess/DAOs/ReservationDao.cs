using Application.DaoInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
			PaddleBoardReservations = r.PaddleBoardReservations,
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
			PaddleBoardReservations = r.PaddleBoardReservations,
		};
	}

	public async Task<Reservation> CreateReservationAsync(Reservation reservation)
	{
		EntityEntry<Reservation> entity = await _context.Reservations.AddAsync(reservation);
		await _context.SaveChangesAsync();

		return entity.Entity;
	}
}
