using System.ComponentModel.DataAnnotations;

namespace Domain;

public class DeliveryAddress
{
    [Key]
    public string Guid { get; set; }
    public double TotalPrice { get; set; }
    public double TotalKm { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
    public string Street { get; set; }
    public Order Order { get;  }

    public DeliveryAddress(double totalPrice, double totalKm, string city, int zip, string street)
    {
        TotalPrice = totalPrice;
        TotalKm = totalKm;
        City = city;
        Zip = zip;
        Street = street;
    }
    
    public DeliveryAddress(double totalPrice, double totalKm, string city, int zip, string street, Order order)
    {
        TotalPrice = totalPrice;
        TotalKm = totalKm;
        City = city;
        Zip = zip;
        Street = street;
        Order = order;
    }
}