using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaddleBoard
{
    [Key] public int Id { get; set; }
    public bool IsActive { get; set; }
    public int PaddleBoardTypeID { get; set; }
    public PaddleBoardType PaddleBoardType { get; set; }

    public ICollection<PaddleBoardReservation> PaddleBoardReservations { get; }

    // public PaddleBoard(bool isActive)
    // {
    //     Name = name;
    //     Price = price;
    //     MinCapacity = minCapacity;
    //     MaxCapacity = maxCapacity;
    //     IsActive = isActive;
    // }
    //
    // public PaddleBoard(bool isActive,
    //     PaddleBoardType paddleBoardType, ICollection<PaddleBoardReservation> paddleBoardReservations)
    // {
    //     Name = name;
    //     Price = price;
    //     MinCapacity = minCapacity;
    //     MaxCapacity = maxCapacity;
    //     IsActive = isActive;
    //     PaddleBoardType = paddleBoardType;
    //     PaddleBoardTypeID = paddleBoardType.Id;
    //     PaddleBoardReservations = paddleBoardReservations;
    // }
}
