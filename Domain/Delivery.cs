using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Delivery
{
    [Key]
    public string Guid { get; set; }
    
    public DeliveryType DeliveryType { get; set; }
    public double TotalPrice { get; set; }
    public double TotalKilometers { get; set; }
    public string AtID { get; set; }
    public Address At { get; set; }
    public ICollection<Order> Orders { get; set; }

    public Delivery(DeliveryType deliveryType, double totalPrice, double totalKilometers)
    {
        DeliveryType = deliveryType;
        TotalPrice = totalPrice;
        TotalKilometers = totalKilometers;
        At = null;
        Orders = new List<Order>();
    }

    public Delivery(DeliveryType deliveryType, double totalPrice, double totalKilometers, Address at, ICollection<Order> orders)
    {
        DeliveryType = deliveryType;
        TotalPrice = totalPrice;
        TotalKilometers = totalKilometers;
        At = at;
        AtID = At.Guid;
        Orders = orders;
    }
}