using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeRequestConfiguration : IEntityTypeConfiguration<EmployeeRequest>
{
    public void Configure(EntityTypeBuilder<EmployeeRequest> builder)
    {
        builder.ToTable("EMPLOYEE_REQUESTS");

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.HasMany(e => e.Candidates)
            .WithOne()
            .HasForeignKey("EMPLOYEE_REQUEST_ID")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Business)
            .HasMaxLength(50)
            .HasColumnName(nameof(EmployeeRequest.Business));

        builder.BaseEntityConfiguration();
    }
}
