using Base.Application.Models.Tags;
using Base.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class TagController(TagService service) : Controller
{
  private readonly TagService _service = service;

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    ViewData["Title"] = "Lista de Tags";
    var result = await _service.GetAllAsync();

    if (result == null || !result.Any())
      TempData["Message"] = "Não há tags cadastradas.";

    return View(result);
  }

  [HttpGet("Details/{id}")]
  public async Task<IActionResult> Details(int id)
  {
    ViewData["Title"] = "Detalhes da Tag";
    var result = await _service.GetDetailsByIdAsync(id);

    return View(result);
  }

  [HttpGet("Create")]
  public IActionResult Create()
  {
    ViewData["Title"] = "Criar Tag";
    return View();
  }

  [HttpPost("Create")]
  public async Task<IActionResult> Create([FromBody] CreateTagViewModel model)
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
    ViewData["Title"] = "Editar Tag";
    var result = await _service.GetEditTagByIdAsync(id);

    return View(result);
  }

  [HttpPut("Edit/{id}")]
  public async Task<IActionResult> Edit(int id, [FromBody] EditTagViewModel model)
  {
    if (ModelState.IsValid)
    {
      await _service.UpdateAsync(model);
      return RedirectToAction("Index");
    }

    return View(model);
  }

  [HttpGet("Delete/{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    ViewData["Title"] = "Excluir Tag";
    var result = await _service.GetDeleteByIdAsync(id);

    return View(result);
  }

  [HttpDelete("Delete/{id}")]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    await _service.DeleteAsync(id);
    return RedirectToAction("Index");
  }

}
