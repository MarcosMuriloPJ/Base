using System.ComponentModel;

namespace Base.Application.Models.Tags;

public class TagDetailsViewModel
{
  public int Id { get; set; }

  [DisplayName("Descrição")]
  public string Description { get; set; }

  [DisplayName("Notícias")]
  public List<string> NewsTitles { get; set; }
}
