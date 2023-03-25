using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ExtrasOrder
{
    public int Id { get; set; }
    public int Amount { get; set; }
    
    [Required] public Extras Extras { get; set; } = null!;
    [Required] public Order Order { get; set; } = null!;
}