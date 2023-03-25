using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Customer
{
    [Key]
    public string Guid { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<Order> Orders { get; set; }

    public Customer(string fullName, string email, string phone)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
    }
    
    public Customer(string fullName, string email, string phone, ICollection<Order> orders)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        Orders = orders;
    }
}