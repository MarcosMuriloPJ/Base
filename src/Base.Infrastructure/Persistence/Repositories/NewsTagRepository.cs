using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Infrastructure.Persistence.Repositories;

public class NewsTagRepository(ILogger<NewsTagRepository> logger, BaseDbContext context) : INewsTagRepository
{
  private readonly ILogger<NewsTagRepository> _logger = logger;
  private readonly BaseDbContext _context = context;

  public async Task AddAsync(int newsId, int tagId)
  {
    try
    {
      var newsTag = new NewsTag(newsId, tagId);
      await _context.NewsTags.AddAsync(newsTag);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao criar notícia/tag");
      throw new Exception("O vínculo notícia/tag não pode ser criado, favor contate o administrador para mais informações.");
    }
  }

  public async Task DeleteByNewsIdAsync(int newsId)
  {
    try
    {
      var newsTag = await _context.NewsTags
                                  .Where(nt => nt.NewsId == newsId)
                                  .ToListAsync();

      if (newsTag != null)
      {
        _context.NewsTags.RemoveRange(newsTag);
        await _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao excluir notícia/tag para notícia ID {NewsId}", newsId);
      throw new Exception("O vínculo notícia/tag não pode ser excluído, favor contate o administrador para mais informações.");
    }
  }

}
