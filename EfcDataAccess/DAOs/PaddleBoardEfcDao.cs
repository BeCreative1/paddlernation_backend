using Application.DaoInterfaces;
using Domain;
using Domain.DTOs.PaddleBoard;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class PaddleBoardEfcDao : IPaddleBoardDao
{
	private readonly PaddlerNationContext _context;

	public PaddleBoardEfcDao(PaddlerNationContext context)
	{
		_context = context;
	}
	
    public async Task<IEnumerable<PaddleBoardDto>> GetAllPeddleBoardsAsync()
    {
	    // TODO:
	    // Get all paddle boards in a range
	    // Check if The paddle boards are available
	    // Convert the PaddleBoards list in to a list of PaddleBoardDtos

	    IEnumerable<PaddleBoard> paddleBoards = await _context.PaddleBoards
		   // .Where(pb => pb.IsActive == true)
		    .ToListAsync();

        throw new NotImplementedException();
    }
}