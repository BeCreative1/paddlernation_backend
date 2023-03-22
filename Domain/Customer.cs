using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Customer
{
    [Key]
    public string Guid { get; set; }
    public string FullName { get; }
    public string Email { get; }
    public string Phone { get; }

    public Customer(string fullName, string email, string phone)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
    }
}