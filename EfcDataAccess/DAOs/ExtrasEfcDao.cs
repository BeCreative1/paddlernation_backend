using Application.DaoInterfaces;
using Domain;
using Domain.DTOs.Extras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class ExtrasEfcDao : IExtrasDao
{
    private readonly PaddlerNationContext context;

    public ExtrasEfcDao(PaddlerNationContext context)
    {
        this.context = context;
    }

    public async Task<Extra> CreateAsync(Extra extra)
    {

        EntityEntry<Extra> entity = await context.Extras.AddAsync(extra);
        await context.SaveChangesAsync();

        return entity.Entity;
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