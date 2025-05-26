using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarFactory.Employees.Infrastructure.Converters;

public class LastNameConverter : ValueConverter<LastName, string>
{
    public LastNameConverter()
        : base(v => v.Value.ToString(), v => new LastName(v))
    {
    }
}
