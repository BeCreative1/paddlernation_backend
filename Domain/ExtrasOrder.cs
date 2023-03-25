using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ExtrasOrder
{
    public string ExtrasID { get; set;  }
    public Extra Extra { get; set; }
    public string OrderID { get; set; }
    public Order Order { get; set; }
    public int Amount { get; set; }

    public ExtrasOrder(int amount)
    {
        Amount = amount;
    }
}