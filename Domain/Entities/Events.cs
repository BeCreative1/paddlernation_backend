namespace Domain;

public class Events
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    // TODO: in what format are we accepting timespan?
    public string Place { get; set; }
    public int Activity { get; set; }
    public string? Comment { get; set; }
    public string? CVR { get; set; }
}