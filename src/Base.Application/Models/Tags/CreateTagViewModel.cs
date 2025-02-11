using System.ComponentModel.DataAnnotations;

namespace Base.Application.Models.Tags;

public class CreateTagViewModel
{
  [Required(ErrorMessage = "A descrição da tag é obrigatória.")]
  [StringLength(100, ErrorMessage = "A descrição da tag não pode exceder 100 caracteres.")]
  public string Description { get; set; }
}
