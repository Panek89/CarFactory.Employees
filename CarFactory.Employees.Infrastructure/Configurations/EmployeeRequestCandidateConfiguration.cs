using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFactory.Employees.Infrastructure.Configurations;

public class EmployeeRequestCandidateConfiguration : IEntityTypeConfiguration<EmployeeRequestCandidate>
{
    public void Configure(EntityTypeBuilder<EmployeeRequestCandidate> builder)
    {
        builder.ToTable("EmployeeRequestCandidates");
    }
}
