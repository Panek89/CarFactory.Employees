using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeRequestCandidateConfiguration : IEntityTypeConfiguration<EmployeeRequestCandidate>
{
    public void Configure(EntityTypeBuilder<EmployeeRequestCandidate> builder)
    {
        builder.ToTable("EMPLOYEE_REQUEST_CANIDATES");

        builder.HasKey(x => x.Id);

        builder.FirstNameConfiguration();
        builder.LastNameConfiguration();
        builder.PersonalIdConfiguration();
        builder.BaseEntityConfiguration();
    }
}
