using Base.Application.Models.News;
using Base.Application.Models.Tags;
using Base.Domain.Entities;

namespace Base.Application.Mapping;

public class NewsMapping
{
  // Mapeamento de NewsViewModel p/ News
  public static News MapToNews(NewsViewModel newsDetailsViewModel)
  {
    return new News
    {
      Id = newsDetailsViewModel.Id,
      Title = newsDetailsViewModel.Title,
      Content = newsDetailsViewModel.Content,
      User = new User { Name = newsDetailsViewModel.UserName },
      NewsTags = [.. newsDetailsViewModel.Tags.Select(tag => new NewsTag
      {
        Tag = new Tag { Description = tag }
      })]
    };
  }

  // Mapeamento de News p/ NewsViewModel
  public static NewsViewModel MapToNewsViewModel(News news)
  {
    return new NewsViewModel
    {
      Id = news.Id,
      Title = news.Title,
      Content = news.Content,
      UserName = news.User.Name,
      Tags = [.. news.NewsTags.Select(nt => nt.Tag.Description)]
    };
  }

  // Mapeamento de NewsDetailsViewModel p/ News
  public static News MapToNews(NewsDetailsViewModel newsDetailsViewModel)
  {
    return new News
    {
      Id = newsDetailsViewModel.Id,
      Title = newsDetailsViewModel.Title,
      Content = newsDetailsViewModel.Content,
      User = new User { Name = newsDetailsViewModel.UserName },
      NewsTags = [.. newsDetailsViewModel.Tags.Select(tag => new NewsTag
      {
        Tag = new Tag { Description = tag }
      })]
    };
  }

  // Mapeamento de News p/ NewsDetailsViewModel
  public static NewsDetailsViewModel MapToNewsDetailsViewModel(News news)
  {
    return new NewsDetailsViewModel
    {
      Id = news.Id,
      Title = news.Title,
      Content = news.Content,
      UserName = news.User.Name,
      Tags = [.. news.NewsTags.Select(nt => nt.Tag.Description)]
    };
  }

  // Mapeamento de EditNewsViewModel p/ News
  public static News MapToNews(EditNewsViewModel editNewsViewModel)
  {
    return new News
    {
      Id = editNewsViewModel.Id,
      Title = editNewsViewModel.Title,
      Content = editNewsViewModel.Content,
      UserId = editNewsViewModel.UserId,
      NewsTags = [.. editNewsViewModel.SelectedTags.Select(tagId => new NewsTag
      {
        TagId = tagId
      })]
    };
  }

  // Mapeamento de News p/ EditNewsViewModel
  public static EditNewsViewModel MapToEditNewsViewModel(News news, IEnumerable<TagViewModel> tags)
  {
    return new EditNewsViewModel
    {
      Id = news.Id,
      Title = news.Title,
      Content = news.Content,
      UserId = news.UserId,
      SelectedTags = [.. news.NewsTags.Select(nt => nt.TagId)],
      Tags = [.. tags]
    };
  }

  // Mapeamento de CreateNewsViewModel p/ News
  public static News MapToNews(CreateNewsViewModel createNewsViewModel)
  {
    return new News
    {
      Title = createNewsViewModel.Title,
      Content = createNewsViewModel.Content,
      UserId = createNewsViewModel.UserId,
      NewsTags = [.. createNewsViewModel.SelectedTags.Select(tagId => new NewsTag
      {
        TagId = tagId
      })]
    };
  }

  // Mapeamento de News p/ CreateNewsViewModel
  public static CreateNewsViewModel MapToCreateNewsViewModel(News news, IEnumerable<TagViewModel> tags)
  {
    return new CreateNewsViewModel
    {
      Title = news.Title,
      Content = news.Content,
      UserId = news.UserId,
      SelectedTags = [.. news.NewsTags.Select(nt => nt.TagId)],
      Tags = [.. tags]
    };
  }

  // Mapeamento de DeleteNewsViewModel p/ News
  public static News MapToNews(DeleteNewsViewModel deleteNewsViewModel)
  {
    return new News
    {
      Id = deleteNewsViewModel.Id,
      Title = deleteNewsViewModel.Title
    };
  }

  // Mapeamento de News p/ DeleteNewsViewModel
  public static DeleteNewsViewModel MapToDeleteNewsViewModel(News news)
  {
    return new DeleteNewsViewModel
    {
      Id = news.Id,
      Title = news.Title
    };
  }

}
