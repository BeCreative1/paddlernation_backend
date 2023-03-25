using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Extras
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Comment { get; set; }
    public int MaxAmount { get; set; }
    
    public ICollection<ExtrasOrder> ExtrasOrders { get; set; }
}