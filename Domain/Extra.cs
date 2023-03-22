using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Extra
{
    [Key]
    public string Guid { get; set; }
    public int Quantity { get; set; }
    public String Name { get; set; }
    public double Price { get; set; }
    public String Comment { get; set; }
    public int MaxAmount { get; set; }
    public ICollection<ExtrasOrder> ExtrasOrders { get; }

    public Extra(int quantity, string name, double price, string comment, int maxAmount)
    {
        Quantity = quantity;
        Name = name;
        Price = price;
        Comment = comment;
        MaxAmount = maxAmount;
        ExtrasOrders = new List<ExtrasOrder>();
    }
    
    public Extra(int quantity, string name, double price, string comment, int maxAmount, ICollection<ExtrasOrder> extrasOrders)
    {
        Quantity = quantity;
        Name = name;
        Price = price;
        Comment = comment;
        MaxAmount = maxAmount;
        ExtrasOrders = extrasOrders;
    }
}