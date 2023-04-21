namespace Domain.DTOs.Reservation;

public class ReservationCreationDto
{
	public DateTime DateFrom { get; set; }
	public DateTime DateTo { get; set; }
	public ICollection<int> PaddleBoardIds { get; set; }
}
