using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain;

public class Order
{
    public int Id { get; set; }

    public int TotalPrice { get; set; }
    public int PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }
    public int PaymentStage { get; set; }

    [Required] public Customer Customer { get; set; } = null!;
    public DeliveryAddress? DeliveryAddress { get; set; }


}