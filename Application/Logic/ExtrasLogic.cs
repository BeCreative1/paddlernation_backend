using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class ExtrasLogic : IExtraLogic
{
    private readonly IExtrasDao ExtrasDao;

    public ExtrasLogic(IExtrasDao extrasDao)
    {
        ExtrasDao = extrasDao;
    }
    
    public async Task<IEnumerable<Extra>> GetAllAsync()
    {
        return await ExtrasDao.GetAllAsync();
    }

    public async Task<Extra?> GetByIdAsync(int id)
    {
        return await ExtrasDao.GetByIdAsync(id);
    }
}