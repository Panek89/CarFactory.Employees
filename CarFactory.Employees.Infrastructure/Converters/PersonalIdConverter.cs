using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarFactory.Employees.Infrastructure.Converters;

public class PersonalIdConverter : ValueConverter<PersonalId, string>
{
    public PersonalIdConverter()
        : base(v => v.Value.ToString(), v => new PersonalId(v)) 
    { 
    }
}
