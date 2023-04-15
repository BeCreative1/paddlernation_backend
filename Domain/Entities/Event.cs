using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Event
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long TimeSpan { get; set; }
    public string Phone { get; set; }
    public int HeldAtID { get; set; }
    public Address HeldAt { get; set; }
    public string Activity { get; set; }
    public string Comment { get; set; }
    [Range(100000000,999999999)]
    public int? CVR { get; set; }

    public Event(string name, string email, long timeSpan, string phone,  string activity, string comment)
    {
        Name = name;
        Email = email;
        TimeSpan = timeSpan;
        Phone = phone;
        Activity = activity;
        Comment = comment;
    }

    public Event(string name, string email, long timeSpan, string phone, Address heldAt, string activity, string comment, int? cvr)
    {
        Name = name;
        Email = email;
        TimeSpan = timeSpan;
        Phone = phone;
        HeldAt = heldAt;
        HeldAtID = HeldAt.Id;
        Activity = activity;
        Comment = comment;
        CVR = cvr;
    }
}