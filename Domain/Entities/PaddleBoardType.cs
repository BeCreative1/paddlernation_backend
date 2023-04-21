using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoardType
{
    [Key]
    public int Id { get; set; }
    public string NameOfType { get; set; }

    public ICollection<PaddleBoard> PaddleBoards { get; }

    // public PaddleBoardType(string nameOfType)
    // {
    //     NameOfType = nameOfType;
    //     PaddleBoards = new List<PaddleBoard>();
    // }
    //
    // public PaddleBoardType(string nameOfType, ICollection<PaddleBoard> paddleBoards)
    // {
    //     NameOfType = nameOfType;
    //     PaddleBoards = paddleBoards;
    // }
}
