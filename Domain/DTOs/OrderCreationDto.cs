namespace Domain.DTOs;

public class OrderCreationDto
{
    public double TotalPrice { get; }
    public PaymentMethod PaymentMethod { get;}
    public int OwnerId { get; }
    public DeliveryType DeliveryType { get; }
    public string? City { get; }
    public int? Zip { get; }
    public string? Street { get; }
    
    public OrderCreationDto(double totalPrice, PaymentMethod paymentMethod, int ownerId, DeliveryType deliveryType, string? city, int? zip, string? street)
    {
        TotalPrice = totalPrice;
        PaymentMethod = paymentMethod;
        OwnerId = ownerId;
        DeliveryType = deliveryType;
        City = city;
        Zip = zip;
        Street = street;
    }
}