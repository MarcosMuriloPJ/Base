using System.ComponentModel;

namespace Base.Application.Models.News;

public class DeleteNewsViewModel
{
  public int Id { get; set; }

  [DisplayName("Título")]
  public string Title { get; set; }
}
