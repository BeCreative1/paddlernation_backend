using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public ICollection<PaddleBoardReservation> PaddleBoardReservations { get; }
    public Order OrderedIn { get; }

    // public Reservation(DateTime dateFrom, DateTime dateTo)
    // {
    //     DateFrom = dateFrom;
    //     DateTo = dateTo;
    //     CreatedAt = DateTime.Now;
    //     PaddleBoardReservations = new List<PaddleBoardReservation>();
    // }
    //
    // public Reservation(DateTime dateFrom, DateTime dateTo, Order orderedIn)
    // {
    //     DateFrom = dateFrom;
    //     DateTo = dateTo;
    //     CreatedAt = DateTime.Now;
    //     PaddleBoardReservations = new List<PaddleBoardReservation>();
    //     OrderedIn = orderedIn;
    // }
    //
    // public Reservation(DateTime dateFrom, DateTime dateTo, ICollection<PaddleBoardReservation> paddleBoardReservations, Order orderedIn)
    // {
    //     DateFrom = dateFrom;
    //     DateTo = dateTo;
    //     PaddleBoardReservations = paddleBoardReservations;
    //     CreatedAt = DateTime.Now;
    //     OrderedIn = orderedIn;
    // }
}
