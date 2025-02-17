using Base.Application.Mapping;
using Base.Application.Models.Tags;
using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Base.Application.Services;

public class TagService(ITagRepository repository)
{
  private readonly ITagRepository _repo = repository;

  public async Task<IEnumerable<TagViewModel>?> GetAllAsync()
  {
    var tags = await _repo.GetAllAsync(query => query
                          .Include(n => n.NewsTags)
                            .ThenInclude(nt => nt.News)
    );
    var result = tags?.Select(TagMapping.MapToTagViewModel);

    return result;
  }

  public async Task<TagDetailsViewModel> GetDetailsByIdAsync(int id)
  {
    var tag = await GetByIdAsync(id);
    var result = TagMapping.MapToTagDetailsViewModel(tag);

    return result;
  }

  public async Task<EditTagViewModel> GetEditTagByIdAsync(int id)
  {
    var tag = await GetByIdAsync(id);
    var result = TagMapping.MapToEditTagViewModel(tag);

    return result;
  }

  public async Task AddAsync(CreateTagViewModel model)
  {
    var tag = TagMapping.MapToTag(model);
    await _repo.AddAsync(tag);
  }

  public async Task UpdateAsync(EditTagViewModel model)
  {
    var tag = TagMapping.MapToTag(model);
    await _repo.UpdateAsync(tag);
  }

  public async Task<DeleteTagViewModel> GetDeleteByIdAsync(int id)
  {
    var news = await GetByIdAsync(id);
    var result = TagMapping.MapToDeleteTagViewModel(news);

    return result;
  }

  public async Task DeleteAsync(int id)
  {
    var tag = await _repo.GetByIdAsync(id);
    if (tag == null)
      throw new Exception("Tag não encontrada.");

    await _repo.DeleteAsync(id);
  }

  private async Task<Tag> GetByIdAsync(int id)
  {
    var tag = await _repo.GetByIdAsync(id, query => query
                        .Include(n => n.NewsTags)
                          .ThenInclude(nt => nt.News));

    if (tag == null)
      throw new Exception("Tag não encontrada.");

    return tag;
  }

}
