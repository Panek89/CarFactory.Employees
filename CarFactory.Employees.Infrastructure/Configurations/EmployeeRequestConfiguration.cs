using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeRequestConfiguration : IEntityTypeConfiguration<EmployeeRequest>
{
    public void Configure(EntityTypeBuilder<EmployeeRequest> builder)
    {
        builder.ToTable("EMPLOYEE_REQUESTS");

        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Candidates)
            .WithOne(c => c.EmployeeRequest)
            .HasForeignKey(c => c.EmployeeRequestId)
            .IsRequired();

        builder.Property(p => p.Business)
            .HasMaxLength(50)
            .HasColumnName(nameof(EmployeeRequest.Business));

        builder.BaseEntityConfiguration();
    }
}
