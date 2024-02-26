using Microsoft.AspNetCore.Cors.Infrastructure;
using Ustoz_Proyekti.BusinessLogic.Common;

namespace Ustoz_Proyekti.BusinessLogic.Services;

public class BookService(IUnitOfWork unitOfWork)
    : IBookService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(AddBookDto BookDto)
    {
        if (BookDto == null)
        {
            throw new CustomException("", "BookDto was null");
        }

        if (string.IsNullOrEmpty(BookDto.Name))
        {
            throw new CustomException("Name", "Book name is required");
        }

        Book Book = new()
        {
            Name = BookDto.Name,
            Description = BookDto.Description,
            Price = BookDto.Price,
            CategoryId = BookDto.CategoryId,
            BrendId = BookDto.BrendId,
            Brend = null,
            Category = null
        };
        _unitOfWork.Books.Add(Book);
    }

    public void Delete(int id)
    {
        var Book = _unitOfWork.Books.GetById(id);
        if (Book == null)
        {
            throw new CustomException("", "Book not found");
        }

        _unitOfWork.Books.Delete(Book.Id);
    }

    public List<BookDto> GetAll()
    {
        var Books = _unitOfWork.Books.GetBooksWithReleations();
        var dtos = Books.Select(Book => Book.ToBookDto());
        return dtos.ToList();
    }

    public BookDto GetById(int id)
    {
        var Book = _unitOfWork.Books.GetBooksWithReleations().FirstOrDefault(c => c.Id == id);
        if (Book == null)
        {
            throw new CustomException("", "Book not found");
        }

        return Book.ToBookDto();
    }

    public void Update(UpdateBookDto BookDto)
    {
        var Book = _unitOfWork.Books.GetById(BookDto.Id);
        if (Book == null)
        {
            throw new CustomException("", "Book not found");
        }

        Book.Name = BookDto.Name;
        Book.Description = BookDto.Description;
        Book.Price = BookDto.Price;
        Book.CategoryId = BookDto.CategoryId;
        Book.BrendId = BookDto.BrendId;

        _unitOfWork.Books.Update(Book);
    }
}