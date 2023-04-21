namespace Domain.DTOs;

public class CustomerCreationDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public CustomerCreationDto(){}
    
    public CustomerCreationDto(string fullName, string email, string phone)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
    }
    
}