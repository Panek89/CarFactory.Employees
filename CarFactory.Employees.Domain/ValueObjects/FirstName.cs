using System;

namespace CarFactory.Employees.Domain.ValueObjects;

public class FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        Value = value;
    }

    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static explicit operator FirstName(string value) => new FirstName(value);
}
