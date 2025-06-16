using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<FirstName>()
            .HaveConversion<FirstNameConverter>();

        configurationBuilder
            .Properties<LastName>()
            .HaveConversion<LastNameConverter>();

        configurationBuilder
            .Properties<PersonalId>()
            .HaveConversion<PersonalIdConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureMarker).Assembly);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeRequest> EmployeeRequests { get; set; }
    public DbSet<EmployeeRequestCandidate> EmployeeRequestCandidates { get; set; }
}
