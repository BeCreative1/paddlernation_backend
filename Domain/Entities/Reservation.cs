using Domain.Enums;

namespace Domain;

public class Reservation
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public int ReservationTypeNumber { get; set; }
    public ReservationType Type
    {
        get => (ReservationType)ReservationTypeNumber;
        set => ReservationTypeNumber = (int)value;
    }

    public Order? Order { get; set; }
    public ICollection<ReservationItem> ReservationItems { get; set; } = null!;
}