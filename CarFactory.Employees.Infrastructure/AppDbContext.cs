using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<EmployeeRequest> EmployeeRequests { get; set; }
    public DbSet<EmployeeRequestCandidate> EmployeeRequestCandidates { get; set; }
}
