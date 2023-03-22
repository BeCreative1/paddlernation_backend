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
    public string CustomerID { get; }
    public Customer? Customer { get; }
    public string DeliveryAddressID { get; }
    public DeliveryAddress? DeliveryAddress { get; }
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
        Customer = null;
        DeliveryAddress = null;
    }

    public Order(double totalPrice, IEnumerable<Reservation> reservations, IEnumerable<ExtrasOrder> extrasOrders, Customer? customer, DeliveryAddress? deliveryAddress, PaymentMethod paymentMethod, PaymentStage paymentStage)
    {
        TotalPrice = totalPrice;
        Reservations = reservations;
        ExtrasOrders = extrasOrders;
        Customer = customer;
        DeliveryAddress = deliveryAddress;
        PaymentMethod = paymentMethod;
        PaymentStage = paymentStage;
        CreatedAt = DateTime.Now;
        CustomerID = customer.Guid;
        DeliveryAddressID = deliveryAddress.Guid;
    }
}