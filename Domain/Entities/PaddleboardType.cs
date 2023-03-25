namespace Domain;

public class PaddleboardType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int MinCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public int Quantity { get; set; }
    
    
    public ICollection<ReservationItem>? ReservationItems { get; set; }
}