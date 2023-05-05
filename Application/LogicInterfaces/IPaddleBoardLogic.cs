using Domain;

namespace Application.LogicInterfaces;

public interface IPaddleBoardLogic
{
    public Task<IEnumerable<PaddleBoard>> GetAllPaddleBoardsAsync();
}