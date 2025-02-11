using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Base.Application.Models.Tags;

namespace Base.Application.Models.News;

public class CreateNewsViewModel
{
  [DisplayName("Título")]
  [Required(ErrorMessage = "O título é obrigatório.")]
  public string Title { get; set; }

  [DisplayName("Conteúdo")]
  [Required(ErrorMessage = "O conteúdo é obrigatório.")]
  public string Content { get; set; }

  [Required(ErrorMessage = "O usuário é obrigatório.")]
  public int UserId { get; set; }

  public List<int>? SelectedTags { get; set; }

  [DisplayName("Tags")]
  public IEnumerable<TagViewModel>? Tags { get; set; }
}
