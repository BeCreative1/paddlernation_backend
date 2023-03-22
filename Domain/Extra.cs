using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Extra
{
    [Key]
    public string Guid { get; set; }
    public int Quantity { get; }
    public String Name { get; }
    public double Price { get; }
    public String Comment { get; }
    public int MaxAmount { get; }

    public Extra(int quantity, string name, double price, string comment, int maxAmount)
    {
        Quantity = quantity;
        Name = name;
        Price = price;
        Comment = comment;
        MaxAmount = maxAmount;
    }
}