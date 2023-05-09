using Domain.DTOs.PaddleBoard;

namespace Application.DaoInterfaces;

public interface IPaddleBoardDao
{
    Task<IEnumerable<PaddleBoardDto>> GetAllAvailablePeddleBoardsAsync(DateOnly dateFrom, DateOnly dateTo);
    Task<IEnumerable<PaddleBoardDto>> GetAllPeddleBoardsAsync();
}