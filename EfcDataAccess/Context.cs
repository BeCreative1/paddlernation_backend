using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class Context
{
	public DbSet<Reservation> Reservations { get; set; }
}
