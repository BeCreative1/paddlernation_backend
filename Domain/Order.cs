using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Order
{
    [Key]
    public String Guid { get; set; }
    public double TotalPrice { get; set; }
    public DateTime CreatedAt { get; }
    public IEnumerable<Reservation> Reservations { get; }
    public IEnumerable<ExtrasOrder> ExtrasOrders { get; }
    public string? OrderedByID { get; }
    public Customer? OrderedBy { get; }
    public string? DeliveryID { get; }
    public Delivery? Delivery { get; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStage PaymentStage { get; set; }

    public Order(double totalPrice, PaymentMethod paymentMethod, PaymentStage paymentStage)
    {
        TotalPrice = totalPrice;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        CreatedAt = DateTime.Now;
        Reservations = new List<Reservation>();
        ExtrasOrders = new List<ExtrasOrder>();
        OrderedBy = null;
        Delivery = null;
    }

    public Order(double totalPrice, IEnumerable<Reservation> reservations, IEnumerable<ExtrasOrder> extrasOrders, Customer? orderedBy, Delivery? delivery, PaymentMethod paymentMethod, PaymentStage paymentStage)
    {
        TotalPrice = totalPrice;
        Reservations = reservations;
        ExtrasOrders = extrasOrders;
        OrderedBy = orderedBy;
        Delivery = delivery;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        CreatedAt = DateTime.Now;
        OrderedByID = orderedBy.Guid;
        DeliveryID = Delivery.Guid;
    }
}