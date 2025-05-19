using CarFactory.Employees.SharedLibrary.Extensions;

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

        if (value.Length != 11)
        {
            throw new ArgumentException(nameof(value), "Personal ID length must be exact 11");
        }

        if (value.HasNonDigitChars())
        {
            throw new ArgumentException(nameof(value), "Personal ID can contains only digits");
        }

        Value = value;
    }

    public static implicit operator string(PersonalId personalId) => personalId.Value;
    public static implicit operator PersonalId(string value) => new PersonalId(value);
}
