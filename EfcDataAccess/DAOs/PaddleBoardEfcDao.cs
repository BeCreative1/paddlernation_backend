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

    public async Task<IEnumerable<PaddleBoardDto>> GetAllAvailablePeddleBoardsAsync(DateOnly dateFrom, DateOnly dateTo)
    {
        // All paddle boards reserved in the given date ranges.
        IEnumerable<PaddleBoard> noneAvailablePaddleBoards = await _context.PaddleBoardReservations
            .Where(pbr =>
                (
                    dateFrom.ToDateTime(TimeOnly.MinValue) > pbr.Reservation.DateFrom &&
                    pbr.Reservation.DateTo < dateFrom.ToDateTime(TimeOnly.MaxValue)
                )
                ||
                (
                    dateTo.ToDateTime(TimeOnly.MinValue) > pbr.Reservation.DateFrom &&
                    pbr.Reservation.DateTo < dateTo.ToDateTime(TimeOnly.MaxValue)
                )
            )
            .Select(pbr => pbr.PaddleBoard)
            .ToListAsync();


        // Get all paddle boards and exclude the ones that are reserved.
        IEnumerable<PaddleBoard> paddleBoards = await _context.PaddleBoards
            .Where(pb => pb.IsActive == true)
            .Where(pb => !noneAvailablePaddleBoards.Contains(pb))
            .ToListAsync();

        // Convert the PaddleBoard object to PaddleBoardDto object.
        return ConvertPaddleBoardsToPaddleBoardDtos(paddleBoards);
    }

    public async Task<IEnumerable<PaddleBoardDto>> GetAllPeddleBoardsAsync()
    {
        IEnumerable<PaddleBoard> paddleBoards = await _context.PaddleBoards
            .Where(pb => pb.IsActive == true)
            .ToListAsync();

        return ConvertPaddleBoardsToPaddleBoardDtos(paddleBoards);
    }

    private IEnumerable<PaddleBoardDto> ConvertPaddleBoardsToPaddleBoardDtos(IEnumerable<PaddleBoard> paddleBoards)
    {
        // Convert the PaddleBoard object to PaddleBoardDto object.
        return paddleBoards.Select(pb => new PaddleBoardDto
        {
            Id = pb.Id,
            MaxCapacity = pb.PaddleBoardType.MaxCapacity,
            MinCapacity = pb.PaddleBoardType.MinCapacity,
            NameOfType = pb.PaddleBoardType.NameOfType,
            PaddleBoardTypeID = pb.PaddleBoardTypeID,
            Price = pb.PaddleBoardType.Price
        });
    }
}