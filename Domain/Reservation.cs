using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Reservation
{
    [Key]
    public string Guid { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime DateFrom { get; }
    public DateTime DateTo { get; }
    public IEnumerable<PaddleBoard> PaddleBoards { get; }

    public Reservation(DateTime dateFrom, DateTime dateTo)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        CreatedAt = DateTime.Now;
        PaddleBoards = new List<PaddleBoard>();
    }

    public Reservation(DateTime dateFrom, DateTime dateTo, IEnumerable<PaddleBoard> paddleBoards)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        PaddleBoards = paddleBoards;
        CreatedAt = DateTime.Now;
    }
}