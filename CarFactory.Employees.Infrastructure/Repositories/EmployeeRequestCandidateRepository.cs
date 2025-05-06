using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class EmployeeRequestCandidateRepository : BaseRepository<EmployeeRequestCandidate>, IEmployeeRequestCandidateRepository
{
    public EmployeeRequestCandidateRepository(AppDbContext context) : base(context)
    {
    }
}
