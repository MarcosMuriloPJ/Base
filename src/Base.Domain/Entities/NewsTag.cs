using System.ComponentModel.DataAnnotations;
using Base.Domain.Interfaces.Entities;

namespace Base.Domain.Entities;

public class NewsTag : IEntity
{
  [Key]
  public int Id { get; set; }
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
