using Domain.DTOs.PaddleBoard;

namespace Application.DaoInterfaces;

public interface IPaddleBoardDao
{
    Task<IEnumerable<PaddleBoardDto>> GetAllPeddleBoardsAsync();
}