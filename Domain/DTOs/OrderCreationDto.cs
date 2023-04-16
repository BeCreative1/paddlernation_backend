namespace Domain.DTOs;

public class OrderCreationDto
{
    public int TotalPrice { get; }
    public PaymentMethod PaymentMethod { get;}
    public DateTime CreatedAt { get;}
    public PaymentStage PaymentStage { get;}
    public int OwnerId { get; }
    public int AddressId { get; }

    public OrderCreationDto(int totalPrice, PaymentMethod paymentMethod, DateTime createdAt, PaymentStage paymentStage, int ownerId, int addressId)
    {
        TotalPrice = totalPrice;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        OwnerId = ownerId;
        AddressId = addressId;
        CreatedAt = DateTime.Now;
    }
}