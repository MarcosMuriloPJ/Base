using System.ComponentModel;

namespace Base.Application.Models.News;

public class NewsDetailsViewModel
{
  public int Id { get; set; }

  [DisplayName("Título")]
  public string Title { get; set; }

  [DisplayName("Conteúdo")]
  public string Content { get; set; }

  [DisplayName("Usuário")]
  public string UserName { get; set; }

  [DisplayName("Tags")]
  public List<string> Tags { get; set; }
}
