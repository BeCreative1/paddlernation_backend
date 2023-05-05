using Application.LogicInterfaces;
using Domain.DTOs.PaddleBoard;

namespace Application.Logic;

public class PaddleBoardLogic : IPaddleBoardLogic
{
    public Task<IEnumerable<PaddleBoardDto>> GetAllPaddleBoardsAsync()
    {
        throw new NotImplementedException();
    }
}