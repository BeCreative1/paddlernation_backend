using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class ExtrasEfcDao : IExtrasDao
{
    private readonly PaddlerNationContext context;

    public ExtrasEfcDao(PaddlerNationContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Extra>> GetAllAsync()
    {
        IEnumerable<Extra> extras = await context.Extras.ToListAsync();

        return extras;
    }

    public async Task<Extra?> GetByIdAsync(int id)
    {
        return await context.Extras.FindAsync(id);;
    }
}