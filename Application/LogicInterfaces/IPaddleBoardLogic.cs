using Domain.DTOs.PaddleBoard;

namespace Application.LogicInterfaces;

public interface IPaddleBoardLogic
{
    public Task<IEnumerable<PaddleBoardDto>> GetAllPaddleBoardsAsync(string dates);
}