namespace CarFactory.Employees.Domain.ValueObjects;

public class Notification
{
    public required string Title { get; set; }
    public required string Desciption { get; set; }
    public List<string> EMails { get; set; } = [];
}
