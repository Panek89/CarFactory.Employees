using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarFactory.Employees.Infrastructure.Converters;

public class FirstNameConverter : ValueConverter<FirstName, string>
{
    public FirstNameConverter() 
        : base(v => v.Value.ToString(), v => new FirstName(v))
    {
    }
}
