using System.Globalization;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.PaddleBoard;

namespace Application.Logic;

public class PaddleBoardLogic : IPaddleBoardLogic
{
    private readonly IPaddleBoardDao PaddleBoardDao;

    public PaddleBoardLogic(IPaddleBoardDao paddleBoardDao)
    {
        PaddleBoardDao = paddleBoardDao;
    }

    public async Task<IEnumerable<PaddleBoardDto>> GetAllPaddleBoardsAsync(string dates)
    {
        if (!ValidateDates(dates))
            throw new Exception("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\"");

        //IEnumerable<PaddleBoardDto> paddleBoardDtos = await PaddleBoardDao.GetAllPeddleBoardsAsync();

        return null;
    }

    private bool ValidateDates(string dates)
    {
        if (String.IsNullOrEmpty(dates))
            return true;
        
        string[] output = dates.Split('-');
        DateOnly dateOnly;

        if (output.Length < 2)
            return false;

        if (!DateOnly.TryParseExact(output[0], "dd/MM/yyyy", out dateOnly))
            return false;

        if (!DateOnly.TryParseExact(output[1], "dd/MM/yyyy", out dateOnly))
            return false;

        return true;
    }
}