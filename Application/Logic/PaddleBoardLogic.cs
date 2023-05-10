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
        ValidateDates(dates);

        if (String.IsNullOrEmpty(dates))
            return await PaddleBoardDao.GetAllPeddleBoardsAsync();

        string[] output = dates.Split('-');
        DateOnly dateFrom;
        DateOnly dateTo;

        DateOnly.TryParseExact(output[0], "dd/MM/yyyy", out dateFrom);
        DateOnly.TryParseExact(output[1], "dd/MM/yyyy", out dateTo);

        return await PaddleBoardDao.GetAllAvailablePeddleBoardsAsync(dateFrom, dateTo);
    }

    private void ValidateDates(string dates)
    {
        if(String.IsNullOrEmpty(dates))
            return;
        
        string[] output = dates.Split('-');
        DateOnly dateTo;
        DateOnly dateFrom;

        if (output.Length < 2)
            throw new Exception("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\"");

        if (!DateOnly.TryParseExact(output[0], "dd/MM/yyyy", out dateFrom))
            throw new Exception("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\"");

        if (!DateOnly.TryParseExact(output[1], "dd/MM/yyyy", out dateTo))
            throw new Exception("Invalid date format provided, format should follow \"dd/MM/yyyy-dd/MM/yyyy\"");

        if (dateFrom > dateTo)
            throw new Exception("Date from is bigger then Date to");
    }
}