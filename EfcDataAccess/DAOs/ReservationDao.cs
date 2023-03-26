using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class ReservationDao : IReservationDao
{

	private readonly PaddlerNationContext _context;

	public ReservationDao(PaddlerNationContext context)
	{
		_context = context;
	}
	public async Task<IEnumerable<Reservation>> GetAsync()
	{
		IEnumerable<Reservation> reservations = await _context.Reservations.ToListAsync();

		return reservations;
	}

	public async Task<Reservation?> GetByIdAsync(string id)
	{
		Reservation? reservation = await _context.Reservations.FindAsync(id);

		return reservation;
	}
}
