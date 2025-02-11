using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Entities;

public class NewsTag
{
  [Key]
  public int Id { get; private set; }
  public int NewsId { get; set; }
  public int TagId { get; set; }
  public News News { get; set; }
  public Tag Tag { get; set; }

  public NewsTag() { }

  public NewsTag(int newsId, int tagId)
  {
    NewsId = newsId;
    TagId = tagId;
  }
}
