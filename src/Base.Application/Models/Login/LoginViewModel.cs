using System.ComponentModel.DataAnnotations;

namespace Base.Application.Models.Login;

public class LoginViewModel
{
  [Required(ErrorMessage = "O e-mail é obrigatório.")]
  [EmailAddress(ErrorMessage = "E-mail inválido.")]
  public string Email { get; set; }

  [Required(ErrorMessage = "A senha é obrigatória.")]
  public string Password { get; set; }
}
