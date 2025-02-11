using Base.Application.Models.News;
using Base.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController(NewsService service) : Controller
{
  private readonly NewsService _service = service;

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    ViewData["Title"] = "Lista de Notícias";
    var result = await _service.GetAllAsync();

    if (result == null || !result.Any())
      TempData["Message"] = "Não há notícias cadastradas.";

    return View(result);
  }

  [HttpGet("Details/{id}")]
  public async Task<IActionResult> Details(int id)
  {
    ViewData["Title"] = "Detalhes da Notícia";
    var result = await _service.GetDetailsByIdAsync(id);

    return View(result);
  }

  [HttpGet("Create")]
  public async Task<IActionResult> Create()
  {
    ViewData["Title"] = "Criar Notícia";
    var result = await _service.GetCreateNewsByIdAsync();

    return View(result);
  }

  [HttpPost("Create")]
  public async Task<IActionResult> Create([FromBody] CreateNewsViewModel model)
  {
    if (ModelState.IsValid)
    {
      await _service.AddAsync(model);
      return RedirectToAction("Index");
    }
    return View(model);
  }

  [HttpGet("Edit/{id}")]
  public async Task<IActionResult> Edit(int id)
  {
    ViewData["Title"] = "Editar Notícia";
    var result = await _service.GetEditNewsByIdAsync(id);

    return View(result);
  }

  [HttpPut("Edit/{id}")]
  public async Task<IActionResult> Edit(int id, [FromBody] EditNewsViewModel model)
  {
    if (ModelState.IsValid)
    {
      await _service.UpdateAsync(model);
      return Json(new { success = true, message = "Notícia atualizada com sucesso!" });
    }

    return Json(new { success = false, message = "Erro ao atualizar a notícia." });
  }

  [HttpGet("Delete/{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    ViewData["Title"] = "Excluir Notícia";
    var result = await _service.GetDeleteByIdAsync(id);

    return View(result);
  }

  [HttpDelete("Delete/{id}")]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    await _service.DeleteAsync(id);
    return Json(new { success = true, message = "Notícia apagada com sucesso!" });
  }

}
