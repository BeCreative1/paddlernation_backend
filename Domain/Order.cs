namespace Domain;

public class Order
{
    public String Guid { get; set; }
    public double TotalPrice { get; }
    public DateTime CreatedAt { get; }
    public IEnumerable<Reservation> Reservations { get; }
    public IEnumerable<Extra> Extras { get; }
    public Customer? Customer { get; }
    public DeliveryAddress? DeliveryAddress { get; }
    public PaymentMethod PaymentMethod { get; }
    public PaymentStage PaymentStage { get; }

    public Order(double totalPrice, PaymentMethod paymentMethod, PaymentStage paymentStage)
    {
        TotalPrice = totalPrice;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        CreatedAt = DateTime.Now;
        Reservations = new List<Reservation>();
        Extras = new List<Extra>();
        Customer = null;
        DeliveryAddress = null;
    }

    public Order(double totalPrice, IEnumerable<Reservation> reservations, IEnumerable<Extra> extras, Customer? customer, DeliveryAddress? deliveryAddress, PaymentMethod paymentMethod, PaymentStage paymentStage)
    {
        TotalPrice = totalPrice;
        Reservations = reservations;
        Extras = extras;
        Customer = customer;
        DeliveryAddress = deliveryAddress;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        CreatedAt = DateTime.Now;
    }
}