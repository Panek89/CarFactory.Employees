using System;

namespace CarFactory.Employees.Domain.ValueObjects;

public class Address
{
    public required string Street { get; init; }
    public int HouseNumber { get; init; }
    public int? FlatNumber { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
}
