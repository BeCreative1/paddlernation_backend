using Application.DaoInterfaces;
using Domain.DTOs.PaddleBoard;

namespace EfcDataAccess.DAOs;

public class PaddleBoardEfcDao : IPaddleBoardDao
{
	private readonly PaddlerNationContext _context;

	public PaddleBoardEfcDao(PaddlerNationContext context)
	{
		_context = context;
	}
	
    public Task<IEnumerable<PaddleBoardDto>> GetAllPeddleBoardsAsync()
    {
        throw new NotImplementedException();
    }
}