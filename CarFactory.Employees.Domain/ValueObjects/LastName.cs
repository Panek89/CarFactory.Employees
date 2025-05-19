using CarFactory.Employees.SharedLibrary.Extensions;

namespace CarFactory.Employees.Domain.ValueObjects;

public class LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        if (value == default)
        {
            throw new ArgumentNullException(nameof(value), "First name cannot be null");
        }

        if (value.Length < 2)
        {
            throw new ArgumentException("First name must have at least two letters", nameof(value));
        }

        if (value.HasNonLettersChars())
        {
            throw new ArgumentException("First name can only contains letters", nameof(value));
        }

        Value = value;
    }

    public static implicit operator string(LastName lastName) => lastName.Value;
    public static explicit operator LastName(string value) => new LastName(value);
}
