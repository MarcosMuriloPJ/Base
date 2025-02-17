using System.Linq.Expressions;
using Base.Domain.Interfaces.Entities;
using Base.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.Persistence.Repositories
{
  public class GenericRepository<T>(BaseDbContext context) : IGenericRepository<T> where T : class, IEntity
  {
    private readonly BaseDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include = null)
    {
      IQueryable<T> query = _dbSet;

      if (include != null)
        query = include(query);

      return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>> include = null)
    {
      IQueryable<T> query = _dbSet;

      if (include != null)
      {
        query = include(query);
      }

      return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _dbSet.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity != null)
      {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await _dbSet.Where(predicate).ToListAsync();
  }
}