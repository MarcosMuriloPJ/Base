using System.Linq.Expressions;

namespace Base.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
  Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include = null);
  Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>> include = null);
  Task AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(int id);
  Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
