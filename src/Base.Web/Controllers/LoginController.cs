using Base.Application.Models.Login;
using Base.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Controllers;

public class LoginController(UserService service) : Controller
{
  private readonly UserService _service = service;

  public IActionResult Index()
  {
    ViewData["Title"] = "Login";
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var userId = await _service.AuthenticateAsync(model.Email, model.Password);
    if (userId == null)
    {
      ViewBag.ErrorMessage = "E-mail ou senha inválidos.";
      return RedirectToAction("Index", "Login");
    }

    HttpContext.Session.SetInt32("UserId", (int)userId);
    return RedirectToAction("Index", "News");
  }
}
