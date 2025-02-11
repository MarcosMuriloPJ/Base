using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Entities;

public class User
{
  [Key]
  public int Id { get; set; }

  [Required(ErrorMessage = "O nome é obrigatório.")]
  [StringLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
  public string Name { get; set; }

  [Required(ErrorMessage = "A senha é obrigatória.")]
  [StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres.")]
  public string Pass { get; set; }

  [Required(ErrorMessage = "O e-mail é obrigatório.")]
  [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
  [StringLength(250, ErrorMessage = "O e-mail deve ter no máximo 250 caracteres.")]
  public string Email { get; set; }

  public ICollection<News> News { get; set; } = new List<News>();

  public User() { }

  public User(string name, string pass, string email)
  {
    Name = name;
    Pass = pass;
    Email = email;
  }
}