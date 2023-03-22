using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Customer
{
    [Key]
    public string Guid { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Order Ordered { get;  }

    public Customer(string fullName, string email, string phone)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
    }
    
    public Customer(string fullName, string email, string phone, Order ordered)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        Ordered = ordered;
    }
}