using Base.Application.Models.Tags;
using Base.Domain.Entities;

namespace Base.Application.Mapping;

public class TagMapping
{
  // Mapeamento de TagViewModel p/ Tag
  public static Tag MapToTag(TagViewModel tagViewModel)
  {
    return new Tag
    {
      Id = tagViewModel.Id,
      Description = tagViewModel.Description
    };
  }

  // Mapeamento de Tag p/ TagViewModel
  public static TagViewModel MapToTagViewModel(Tag tag)
  {
    return new TagViewModel
    {
      Id = tag.Id,
      Description = tag.Description
    };
  }

  // Mapeamento de CreateTagViewModel p/ Tag
  public static Tag MapToTag(CreateTagViewModel createTagViewModel)
  {
    return new Tag
    {
      Description = createTagViewModel.Description
    };
  }

  // Mapeamento de Tag p/ CreateTagViewModel
  public static CreateTagViewModel MapToCreateTagViewModel(Tag tag)
  {
    return new CreateTagViewModel
    {
      Description = tag.Description
    };
  }

  // Mapeamento de EditTagViewModel p/ Tag
  public static Tag MapToTag(EditTagViewModel editTagViewModel)
  {
    return new Tag
    {
      Id = editTagViewModel.Id,
      Description = editTagViewModel.Description
    };
  }

  // Mapeamento de Tag p/ EditTagViewModel
  public static EditTagViewModel MapToEditTagViewModel(Tag tag)
  {
    return new EditTagViewModel
    {
      Id = tag.Id,
      Description = tag.Description
    };
  }

  // Mapeamento de TagDetailsViewModel p/ Tag
  public static Tag MapToTag(TagDetailsViewModel tagDetailsViewModel)
  {
    return new Tag
    {
      Id = tagDetailsViewModel.Id,
      Description = tagDetailsViewModel.Description
    };
  }

  // Mapeamento de Tag p/ TagDetailsViewModel
  public static TagDetailsViewModel MapToTagDetailsViewModel(Tag tag)
  {
    return new TagDetailsViewModel
    {
      Id = tag.Id,
      Description = tag.Description,
      NewsTitles = [.. tag.NewsTags.Select(nt => nt.News.Title)]
    };
  }

  // Mapeamento de DeleteTagViewModel p/ Tag
  public static Tag MapToTag(DeleteTagViewModel deleteTagViewModel)
  {
    return new Tag
    {
      Id = deleteTagViewModel.Id,
      Description = deleteTagViewModel.Description
    };
  }

  // Mapeamento de Tag p/ DeleteTagViewModel
  public static DeleteTagViewModel MapToDeleteTagViewModel(Tag tag)
  {
    return new DeleteTagViewModel
    {
      Id = tag.Id,
      Description = tag.Description
    };
  }

}
