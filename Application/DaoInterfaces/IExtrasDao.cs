using Domain;

namespace Application.DaoInterfaces;

public interface IExtrasDao
{
    Task<IEnumerable<Extra>> GetAllAsync();
    Task<Extra?> GetByIdAsync(int id);
}