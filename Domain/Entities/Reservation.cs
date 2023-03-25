namespace Domain;

public class Reservation
{
    public int Id { get; set; }


    public ICollection<ReservationItem> ReservationItems { get; set; } = null!;
}