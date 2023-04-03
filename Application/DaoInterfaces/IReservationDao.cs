using Domain;
using Domain.DTOs.Reservation;

namespace Application.DaoInterfaces;

public interface IReservationDao
{
	Task<IEnumerable<ReservationDto>> GetAsync();
	Task<ReservationDto?> GetByIdAsync(int id);
	Task<ReservationDto> CreateReservationAsync(ReservationCreationDto reservationDto);
}
