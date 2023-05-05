using Domain;

namespace Application.LogicInterfaces;

public interface IExtraLogic
{
    Task<IEnumerable<Extra>> GetAllAsync();
    Task<Extra?> GetByIdAsync(int id);
}