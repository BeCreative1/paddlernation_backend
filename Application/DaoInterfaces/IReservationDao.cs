using Domain;

namespace Application.DaoInterfaces;

public interface IReservationDao
{
	Task<IEnumerable<Reservation>> GetAsync();
	Task<Reservation?> GetByIdAsync(int id);
}
