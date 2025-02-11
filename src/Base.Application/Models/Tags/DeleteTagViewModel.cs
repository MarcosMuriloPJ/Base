using System.ComponentModel;

namespace Base.Application.Models.Tags;

public class DeleteTagViewModel
{
  public int Id { get; set; }

  [DisplayName("Descrição")]
  public string Description { get; set; }
}
