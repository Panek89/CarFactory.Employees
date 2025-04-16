using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(Guid id, CancellationToken token);
    Task AddAsync(T entity, CancellationToken token);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync(CancellationToken token);
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);
}

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet;
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token) => await _dbSet.ToListAsync(token);

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken token) => await _dbSet.FindAsync(id, token);

    public async Task AddAsync(T entity, CancellationToken token) => await _dbSet.AddAsync(entity, token);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task SaveChangesAsync(CancellationToken token) => await _context.SaveChangesAsync(token);

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token) => await _dbSet.AnyAsync(entity => entity.Id == id);
}
