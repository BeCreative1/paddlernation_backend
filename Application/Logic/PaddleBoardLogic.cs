using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class PaddleBoardLogic : IPaddleBoardLogic
{
    public Task<IEnumerable<PaddleBoard>> GetAllPaddleBoardsAsync()
    {
        throw new NotImplementedException();
    }
}