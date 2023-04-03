using Domain;
using Domain.DTOs.Reservation;
using Domain.DTOs.Search;

namespace Application.LogicInterfaces;

public interface IReservationLogic
{
	Task<IEnumerable<ReservationDto>> GetAsync();
	Task<ReservationDto> GetByIdAsync(string id);
}
