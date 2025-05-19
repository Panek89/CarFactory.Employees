using CarFactory.Employees.SharedLibrary.Extensions;

namespace CarFactory.Employees.Domain.ValueObjects;

public class FirstName
{
    public string Value { get; }

    public FirstName(string value)
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

    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static explicit operator FirstName(string value) => new FirstName(value);
}
