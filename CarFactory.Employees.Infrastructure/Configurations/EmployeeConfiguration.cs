
using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("EMPLOYEES");

        builder.HasKey(k => k.Id);

        builder.FirstNameConfiguration();
        builder.LastNameConfiguration();
        builder.PersonalIdConfiguration();
        builder.BaseEntityConfiguration();
    }
}
