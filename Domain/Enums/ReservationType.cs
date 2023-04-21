namespace Domain.Enums;

public enum ReservationType
{
    /// <summary>
    /// If the customer has placed the order (permanent)
    /// </summary>
    Order = 0,
    /// <summary>
    /// If the customer reserved the boards but haven't payed yet (these will be deleted in 15 minutes)
    /// </summary>
    Temporary = 1,
    /// <summary>
    /// If David wants to make a reservation, then he will probably use this
    /// </summary>
    Custom = 100,
}