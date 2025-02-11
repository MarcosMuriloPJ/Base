using Base.Domain.Interfaces.Repositories;

namespace Base.Application.Services;

public class NewsTagService(INewsTagRepository repo)
{
  private readonly INewsTagRepository _repo = repo;

  public async Task AddTagsToNewsAsync(int newsId, List<int> tagIds)
  {
    foreach (var tagId in tagIds)
    {
      await _repo.AddAsync(newsId, tagId);
    }
  }

  public async Task RemoveTagsAssociatedAsync(int newsId)
  {
    await _repo.DeleteByNewsIdAsync(newsId);
  }
}
