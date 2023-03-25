using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ReservationItem
{
    public int Id { get; set; }

    [Required] 
    public PaddleboardType PaddleBoardType { get; set; } = null!;

    [Required]
    public Reservation Reservation { get; set; } = null!;
}