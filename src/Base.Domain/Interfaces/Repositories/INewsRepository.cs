using Base.Domain.Entities;

namespace Base.Domain.InterfacesRepositories;

public interface INewsRepository
{
  Task<IEnumerable<News>> GetAllAsync();
  Task<News> GetByIdAsync(int id);
  Task AddAsync(News news);
  Task UpdateAsync(News news);
  Task DeleteAsync(int id);
}