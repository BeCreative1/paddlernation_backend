using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoard
{
    [Key]
    public string Guid { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int MinCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public int Quantity { get; set; }
    public PaddleBoardType PaddleBoardType { get; set; }
    
    public ICollection<PaddleBoardReservation> PaddleBoardReservations { get; }

    public PaddleBoard(string name, double price, int minCapacity, int maxCapacity, int quantity, PaddleBoardType paddleBoardType, ICollection<PaddleBoardReservation> paddleBoardReservations)
    {
        Name = name;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        Quantity = quantity;
        PaddleBoardType = paddleBoardType;
        PaddleBoardReservations = paddleBoardReservations;
    }

    public PaddleBoard(string name, double price, int minCapacity, int maxCapacity, int quantity, PaddleBoardType paddleBoardType)
    {
        Name = name;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        Quantity = quantity;
        PaddleBoardType = paddleBoardType;
    }
}