using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ExtrasOrder
{
    public int ExtrasID { get; set;  }
    public Extra Extra { get; set; }
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public int Amount { get; set; }

    public ExtrasOrder(int amount)
    {
        Amount = amount;
    }
}