namespace Domain.DTOs.Reservation;

public class ReservationCreationDto
{
	public DateTime CreatedAt { get; set; }
	public DateTime DateFrom { get; set; }
	public DateTime DateTo { get; set; }
	public ICollection<PaddleBoardReservation> PaddleBoardReservations { get; }
	public Order OrderedIn { get; }
}
