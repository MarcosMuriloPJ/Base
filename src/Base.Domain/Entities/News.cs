using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Entities;

public class News
{
  [Key]
  public int Id { get; set; }

  [Required(ErrorMessage = "O título é obrigatório.")]
  [StringLength(250, ErrorMessage = "O título deve ter no máximo 250 caracteres.")]
  public string Title { get; set; }

  [Required(ErrorMessage = "O conteúdo da notícia é obrigatório.")]
  public string Content { get; set; }

  public int UserId { get; set; }

  public User User { get; set; }
  public ICollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();

  public News() { }

  public News(int? id, int userId, string title, string content)
  {
    if (id != null)
      Id = (int)id;

    UserId = userId;
    Title = title;
    Content = content;
  }
}