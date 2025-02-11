using Base.Application.Mapping;
using Base.Application.Models.News;
using Base.Domain.Entities;
using Base.Domain.InterfacesRepositories;

namespace Base.Application.Services;

public class NewsService(INewsRepository repository, UserService userService, NewsTagService newsTagService, TagService tagService)
{
  private readonly INewsRepository _repo = repository;
  private readonly UserService _userService = userService;
  private readonly NewsTagService _newsTagService = newsTagService;
  private readonly TagService _tagService = tagService;

  public async Task<IEnumerable<NewsViewModel>?> GetAllAsync()
  {
    var news = await _repo.GetAllAsync();
    var result = news?.Select(NewsMapping.MapToNewsViewModel);

    return result;
  }

  public async Task<NewsDetailsViewModel> GetDetailsByIdAsync(int id)
  {
    var news = await GetByIdAsync(id);
    var result = NewsMapping.MapToNewsDetailsViewModel(news);

    return result;
  }

  public async Task<CreateNewsViewModel> GetCreateNewsByIdAsync()
  {
    var tags = await _tagService.GetAllAsync();
    var result = NewsMapping.MapToCreateNewsViewModel(new News(), tags);

    return result;
  }

  public async Task<EditNewsViewModel> GetEditNewsByIdAsync(int id)
  {
    var news = await GetByIdAsync(id);
    var tags = await _tagService.GetAllAsync();
    var result = NewsMapping.MapToEditNewsViewModel(news, tags);

    return result;
  }

  public async Task AddAsync(CreateNewsViewModel model)
  {
    var news = NewsMapping.MapToNews(model);

    var userExist = await _userService.GetExistByIdAsync(news.UserId);
    if (!userExist)
      throw new Exception("Usuário não encontrado.");

    await _repo.AddAsync(news);
    // Adiciona as tags
    await _newsTagService.AddTagsToNewsAsync(news.Id, [.. news.NewsTags.Select(nt => nt.TagId)]);
  }

  public async Task UpdateAsync(EditNewsViewModel model)
  {
    var news = NewsMapping.MapToNews(model);

    var userExist = await _userService.GetExistByIdAsync(news.UserId);
    if (!userExist)
      throw new Exception("Usuário não encontrado.");

    await _repo.UpdateAsync(news);

    // Remove as tags antigas
    await _newsTagService.RemoveTagsAssociatedAsync(news.Id);
    // Adiciona as novas tags
    await _newsTagService.AddTagsToNewsAsync(news.Id, model.SelectedTags);
  }

  public async Task<DeleteNewsViewModel> GetDeleteByIdAsync(int id)
  {
    var news = await GetByIdAsync(id);
    var result = NewsMapping.MapToDeleteNewsViewModel(news);

    return result;
  }

  public async Task DeleteAsync(int id)
  {
    _ = await GetByIdAsync(id);
    await _repo.DeleteAsync(id);
  }

  private async Task<News> GetByIdAsync(int id)
  {
    var news = await _repo.GetByIdAsync(id);

    if (news == null)
      throw new Exception("Notícia não encontrada.");

    return news;
  }

}