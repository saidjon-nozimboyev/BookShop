using Microsoft.AspNetCore.Mvc;
using Ustoz_Proyekti.BusinessLogic.Common;
using Ustoz_Proyekti.BusinessLogic.DTOs.BrendDTOs;
using Ustoz_Proyekti.BusinessLogic.Interfaces;

namespace Ustoz_Proyekti.Controllers;

public class AuthorsController(IAuthorService authorService) : Controller
{
    private readonly IAuthorService _authorService = authorService;

    public IActionResult Index(int pageNumber = 1)
    {
        var categories = _authorService.GetAll();
        var pageModel = new PageModel<AuthorDto>(categories, pageNumber);
        return View(pageModel);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddAuthorDto dto)
    {
        try
        {
            _authorService.Create(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _authorService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/authors/index" });
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var author = _authorService.GetById(id);
            UpdateAuthorDto dto = new()
            {
                Id = author.Id,
                Name = author.Name,
                ImagePath = author.ImagePath
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/authors/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateAuthorDto dto)
    {
        try
        {
            _authorService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }
}
