using Domain;
using Domain.DTOs.Extras;

namespace Application.DaoInterfaces;

public interface IExtrasDao
{
    Task<Extra> CreateAsync(Extra extra);
    Task<IEnumerable<Extra>> GetAllAsync();
    Task<Extra?> GetByIdAsync(int id);
}