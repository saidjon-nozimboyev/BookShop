using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Ustoz_Proyekti.BusinessLogic.Common;
using Ustoz_Proyekti.BusinessLogic.DTOs.BookDTOs;
using Ustoz_Proyekti.BusinessLogic.Interfaces;

namespace Ustoz_Proyekti.Controllers;

public class BooksController(IBookService BookService,
                             ICategoryService categoryService,
                             IAuthorService AuthorService)
    : Controller
{
    private readonly IBookService _BookService = BookService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IAuthorService _AuthorService = AuthorService;

    public IActionResult Index(int pageNumber = 1)
    {
        var kitoblar = _BookService.GetAll();
        var pageModel = new PageModel<BookDto>(kitoblar, pageNumber);
        return View(pageModel);
    }

    public IActionResult Add()
    {
        var categories = _categoryService.GetAll();
        var Authors = _AuthorService.GetAll();

        AddBookDto dto = new()
        {
            Categories = categories,
            Authors = Authors
        };

        return View(dto);
    }

    [HttpPost]
    public IActionResult Add(AddBookDto dto)
    {
        try
        {
            _BookService.Create(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _BookService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var Book = _BookService.GetById(id);
            UpdateBookDto dto = new()
            {
                Id = Book.Id,
                Name = Book.Name,
                Description = Book.Description,
                Price = Book.Price,
                CategoryId = Book.Category.Id,
                AuthorId = Book.Author.Id,
                Categories = _categoryService.GetAll(),
                Authors = _AuthorService.GetAll()
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateBookDto dto)
    {
        try
        {
            _BookService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Detail(int id)
    {
        try
        {
            var Book = _BookService.GetById(id);
            return View(Book);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }
}
