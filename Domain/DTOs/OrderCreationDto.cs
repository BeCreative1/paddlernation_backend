namespace Domain.DTOs;

public class OrderCreationDto
{
    public int TotalPrice { get; }
    public int PaymentMethod { get;}
    public DateTime CreatedAt { get;}
    public int PaymentStage { get;}
    public int OwnerId { get; }
    public int AddressId { get; }

    public OrderCreationDto(int totalPrice, int paymentMethod, DateTime createdAt, int paymentStage, int ownerId, int addressId)
    {
        TotalPrice = totalPrice;
        PaymentMethod = paymentMethod;
        CreatedAt = createdAt;
        PaymentStage = paymentStage;
        OwnerId = ownerId;
        AddressId = addressId;
    }
}