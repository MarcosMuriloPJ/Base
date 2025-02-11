namespace Base.Domain.Interfaces.Repositories;

public interface INewsTagRepository
{
  Task AddAsync(int newsId, int tagId);
  Task DeleteByNewsIdAsync(int newsId);
}
