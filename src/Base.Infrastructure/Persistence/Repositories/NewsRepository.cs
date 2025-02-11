using Base.Domain.Entities;
using Base.Domain.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Infrastructure.Persistence.Repositories;

public class NewsRepository(ILogger<NewsRepository> logger, BaseDbContext context) : INewsRepository
{
  private readonly ILogger<NewsRepository> _logger = logger;
  private readonly BaseDbContext _context = context;

  public async Task<IEnumerable<News>> GetAllAsync()
  {
    try
    {
      return await _context.News
          .Include(n => n.User)
          .Include(n => n.NewsTags)
            .ThenInclude(nt => nt.Tag)
          .ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar as notícias");
      throw new Exception("As notícias não podem ser buscadas, favor contate o administrador para mais informações.");
    }
  }

  public async Task<News> GetByIdAsync(int id)
  {
    try
    {
      return await _context.News
          .Include(n => n.User)
          .Include(n => n.NewsTags)
            .ThenInclude(nt => nt.Tag)
          .FirstOrDefaultAsync(n => n.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar a notícia com ID {Id}", id);
      throw new Exception("A notícia não pode ser buscada, favor contate o administrador para mais informações.");
    }
  }

  public async Task AddAsync(News news)
  {
    try
    {
      await _context.News.AddAsync(news);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      var newsId = news?.Id ?? -1;
      _logger.LogError(ex, "Erro ao criar a notícia com ID {NewsId}", newsId);
      throw new Exception("A notícia não pode ser criada, favor contate o administrador para mais informações.");
    }
  }

  public async Task UpdateAsync(News news)
  {
    try
    {
      _context.News.Update(news);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      var newsId = news?.Id ?? -1;
      _logger.LogError(ex, "Erro ao atualizar a notícia com ID {NewsId}", newsId);
      throw new Exception("A notícia não pode ser atualizada, favor contate o administrador para mais informações.");
    }
  }

  public async Task DeleteAsync(int id)
  {
    try
    {
      var news = await _context.News.FindAsync(id);

      if (news != null)
      {
        _context.News.Remove(news);
        await _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao excluir a notícia com ID {Id}", id);
      throw new Exception("A notícia não pode ser excluída, favor contate o administrador para mais informações.");
    }
  }
}