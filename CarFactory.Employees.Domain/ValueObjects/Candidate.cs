namespace CarFactory.Employees.Domain.ValueObjects;

public class Candidate
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Nationality { get; set; }
}
