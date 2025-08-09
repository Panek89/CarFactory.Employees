using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Entities;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IDomainEventDispatcher _eventDispatcher;

    public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher eventDispatcher)
    : base(options)
    {
        _eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            var aggreagatesWithEvents = ChangeTracker
                .Entries<AggregateRoot>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in aggreagatesWithEvents)
            {
                await _eventDispatcher.DispatchAsync(aggregate.DomainEvents);
                aggregate.ClearDomainEvents();
            }
        }

        return result;
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
    public DbSet<Factory> Factories { get; set; }
}
