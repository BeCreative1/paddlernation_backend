namespace Domain;

public class PaddleBoardReservation
{
    public string PadleBoardID { get; set; }
    public PaddleBoard PaddleBoard { get; set; }
    
    public string ReservationID { get; set; }
    public Reservation Reservation { get; set; }
}