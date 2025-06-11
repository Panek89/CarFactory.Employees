using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeRequestCandidateConfiguration : IEntityTypeConfiguration<EmployeeRequestCandidate>
{
    public void Configure(EntityTypeBuilder<EmployeeRequestCandidate> builder)
    {
        builder.ToTable("EMPLOYEE_REQUEST_CANIDATES");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property<Guid>("EMPLOYEE_REQUEST_ID").ValueGeneratedNever(); ;

        builder.FirstNameConfiguration();
        builder.LastNameConfiguration();
        builder.PersonalIdConfiguration();
        builder.BaseEntityConfiguration();
    }
}
