using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public interface IEmployeeRequestCandidateRepository : IBaseRepository<EmployeeRequestCandidate>
{
}

public class EmployeeRequestCandidateRepository : BaseRepository<EmployeeRequestCandidate>, IEmployeeRequestCandidateRepository
{
    public EmployeeRequestCandidateRepository(AppDbContext context) : base(context)
    {
    }
}
