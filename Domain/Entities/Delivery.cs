using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class Delivery
{
    [Key]
    public int Id { get; set; }
    
    public DeliveryType DeliveryType { get; set; }
    public double TotalPrice { get; set; }
    public double TotalKilometers { get; set; }
    public int? AtID { get; set; }
    public Address? At { get; set; }
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; }


}