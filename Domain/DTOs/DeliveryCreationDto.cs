namespace Domain.DTOs;

public class DeliveryCreationDto
{
    public DeliveryType DeliveryType { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
}