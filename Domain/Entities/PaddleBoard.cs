using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoard
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int MinCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public bool IsActive { get; set; }
    public int PaddleBoardTypeID { get; set; }
    public PaddleBoardType PaddleBoardType { get; set; }

    public ICollection<PaddleBoardReservation> PaddleBoardReservations { get; }

    public PaddleBoard(string name, double price, int minCapacity, int maxCapacity, bool isActive)
    {
        Name = name;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        IsActive = isActive;
    }

    public PaddleBoard(string name, double price, int minCapacity, int maxCapacity, bool isActive,
        PaddleBoardType paddleBoardType, ICollection<PaddleBoardReservation> paddleBoardReservations)
    {
        Name = name;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        IsActive = isActive;
        PaddleBoardType = paddleBoardType;
        PaddleBoardTypeID = paddleBoardType.Id;
        PaddleBoardReservations = paddleBoardReservations;
    }
}