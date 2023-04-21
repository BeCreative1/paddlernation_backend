using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoardType
{
    [Key]
    public int Id { get; set; }
    public string NameOfType { get; set; }
    public double Price { get; set; }
    public int MinCapacity { get; set; }
    public int MaxCapacity { get; set; }
    
    public ICollection<PaddleBoard> PaddleBoards { get; }

    public PaddleBoardType(string nameOfType, double price, int minCapacity, int maxCapacity)
    {
        NameOfType = nameOfType;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        PaddleBoards = new List<PaddleBoard>();
    }

    public PaddleBoardType(string nameOfType, double price, int minCapacity, int maxCapacity, ICollection<PaddleBoard> paddleBoards)
    {
        NameOfType = nameOfType;
        Price = price;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        PaddleBoards = paddleBoards;
    }
}