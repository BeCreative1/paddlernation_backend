using Domain;
using Domain.DTOs.Reservation;

namespace Application.DaoInterfaces;

public interface IReservationDao
{
	Task<IEnumerable<ReservationDto>> GetAsync();
	Task<ReservationDto?> GetByIdAsync(string id);
}
