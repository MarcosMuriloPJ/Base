using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Base.Application.Models.Tags;

public class EditTagViewModel
{
  public int Id { get; set; }

  [DisplayName("Descrição")]
  [Required(ErrorMessage = "A descrição da tag é obrigatória.")]
  [StringLength(100, ErrorMessage = "A descrição da tag não pode exceder 100 caracteres.")]
  public string? Description { get; set; }
}
