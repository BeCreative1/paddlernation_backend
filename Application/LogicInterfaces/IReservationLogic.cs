using Domain;
using Domain.DTOs.Search;

namespace Application.LogicInterfaces;

public interface IReservationLogic
{
	Task<IEnumerable<Reservation>> GetAsync();
	Task<Reservation> GetByIdAsync(int id);
}
