namespace Domain.DTOs.PaddleBoard;

public class PaddleBoardDto
{
    public int Id { get; set; }
    public string NameOfType { get; set; }
    public double Price { get; set; }
    public int MinCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public int PaddleBoardTypeID { get; set; }
}
