using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Infrastructure.Persistence.Repositories;

public class TagRepository(ILogger<TagRepository> logger, BaseDbContext context) : ITagRepository
{
  private readonly ILogger<TagRepository> _logger = logger;
  private readonly BaseDbContext _context = context;

  public async Task<IEnumerable<Tag>> GetAllAsync()
  {
    try
    {
      return await _context.Tags
                          .Include(n => n.NewsTags)
                            .ThenInclude(nt => nt.News)
                        .ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar as tags");
      throw new Exception("As tags não podem ser buscadas, favor contate o administrador para mais informações.");
    }
  }

  public async Task<Tag> GetByIdAsync(int id)
  {
    try
    {
      return await _context.Tags
                        .Include(n => n.NewsTags)
                          .ThenInclude(nt => nt.News)
                        .FirstOrDefaultAsync(n => n.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar a tag com ID {Id}", id);
      throw new Exception("A tag não pode ser buscada, favor contate o administrador para mais informações.");
    }
  }

  public async Task AddAsync(Tag tag)
  {
    try
    {
      await _context.Tags.AddAsync(tag);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      var tagId = tag?.Id ?? -1;
      _logger.LogError(ex, "Erro ao criar a tag com ID {TagId}", tagId);
      throw new Exception("A tag não pode ser criada, favor contate o administrador para mais informações.");
    }
  }

  public async Task UpdateAsync(Tag tag)
  {
    try
    {
      _context.Tags.Update(tag);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      var tagId = tag?.Id ?? -1;
      _logger.LogError(ex, "Erro ao atualizar a tag com ID {TagId}", tagId);
      throw new Exception("A tag não pode ser atualizada, favor contate o administrador para mais informações.");
    }
  }

  public async Task DeleteAsync(int id)
  {
    try
    {
      var tag = await _context.Tags.FindAsync(id);

      if (tag != null)
      {
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao excluir a tag com ID {Id}", id);
      throw new Exception("A tag não pode ser excluída, favor contate o administrador para mais informações.");
    }
  }
}
