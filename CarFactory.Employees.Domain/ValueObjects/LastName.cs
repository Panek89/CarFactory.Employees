using System;

namespace CarFactory.Employees.Domain.ValueObjects;

public class LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        Value = value;
    }

    public static implicit operator string(LastName lastName) => lastName.Value;
    public static explicit operator LastName(string value) => new LastName(value);
}
