namespace Domain;

public class PaddleBoardReservation
{
    public int PadleBoardID { get; set; }
    public PaddleBoard PaddleBoard { get; set; }

    public int ReservationID { get; set; }
    public Reservation Reservation { get; set; }

}
