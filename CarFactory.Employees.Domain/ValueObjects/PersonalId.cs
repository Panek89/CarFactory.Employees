using System;

namespace CarFactory.Employees.Domain.ValueObjects;

public class PersonalId
{
    public string Value { get; internal set; }

    public PersonalId(string value)
    {
        if (value == default)
        {
            throw new ArgumentNullException(nameof(value), "Personal ID cannot be empty");
        }

        Value = value;
    }

    public static implicit operator string(PersonalId personalId) => personalId.Value;
    public static explicit operator PersonalId(string value) => new PersonalId(value);
}
