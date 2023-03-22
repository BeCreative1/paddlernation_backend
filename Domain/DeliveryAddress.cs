using System.ComponentModel.DataAnnotations;

namespace Domain;

public class DeliveryAddress
{
    [Key]
    public string Guid { get; set; }
    public double TotalPrice { get; }
    public double TotalKM { get; }
    public string City { get; }
    public int Zip { get; }
    public string Street { get; }

    public DeliveryAddress(double totalPrice, double totalKm, string city, int zip, string street)
    {
        TotalPrice = totalPrice;
        TotalKM = totalKm;
        City = city;
        Zip = zip;
        Street = street;
    }
}