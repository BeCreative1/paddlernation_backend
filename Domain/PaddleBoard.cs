using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoard
{
    [Key]
    public string Guid { get; set; }
    public string Name { get; }
    public double Price { get; }
    public int MinCapacity { get; }
    public int MaxCapacity { get; }
    public int Quantity { get; }
    public PaddleBoardType PaddleBoardType { get; }

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