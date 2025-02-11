using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Entities;

public class Tag
{
  [Key]
  public int Id { get; set; }

  [Required(ErrorMessage = "A descrição da tag é obrigatória.")]
  [StringLength(100, ErrorMessage = "A descrição da tag deve ter no máximo 100 caracteres.")]
  public string Description { get; set; }

  public ICollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();

  public Tag() { }

  public Tag(string description)
  {
    Description = description;
  }
}
