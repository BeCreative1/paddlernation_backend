using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Address
{
    [Key]
    public string Guid { get; set; }
    
    public string City { get; set; }
    public int Zip { get; set; }
    public string Street { get; set; }
    
    public ICollection<Delivery> Deliveries { get; }
    public ICollection<Event> Events { get; }

    public Address(string city, int zip, string street)
    {
        City = city;
        Zip = zip;
        Street = street;
        Deliveries = new List<Delivery>();
        Events = new List<Event>();
    }

    public Address(string city, int zip, string street, ICollection<Delivery> deliveries, ICollection<Event> events)
    {
        City = city;
        Zip = zip;
        Street = street;
        Deliveries = deliveries;
        Events = events;
    }
}