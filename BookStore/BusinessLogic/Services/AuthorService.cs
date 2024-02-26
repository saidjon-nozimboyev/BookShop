using AutoMapper;
using Ustoz_Proyekti.BusinessLogic.Common;
using Ustoz_Proyekti.BusinessLogic.Interfaces;

namespace Ustoz_Proyekti.BusinessLogic.Services;

public class AuthorService(IUnitOfWork unitOfWork,
                          IFileService fileService,
                          IMapper mapper)
    : IBookService
private readonly IUnitOfWork _unitOfWork = unitOfWork;
private readonly IFileService _fileService = fileService;
private readonly IMapper _mapper = mapper;

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

    if (BookDto.Name.Length < 3 || BookDto.Name.Length > 30)
    {
        throw new CustomException("Name", "Book name must be between 3 and 30 characters");
    }

    if (BookDto.file == null)
    {
        throw new CustomException("file", "Book image is required");
    }

    Book Book = new()
    {
        Name = BookDto.Name,
        ImageUrl = _fileService.UploadImage(BookDto.file)
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
    _fileService.DeleteImage(Book.ImageUrl);
    _unitOfWork.Books.Delete(Book.Id);
}

public List<BookDto> GetAll()
{
    var categories = _unitOfWork.Books.GetAll();
    var list = categories.Select(_mapper.Map<BookDto>)
                         .ToList();

    return list;
}

public BookDto GetById(int id)
{
    var Book = _unitOfWork.Books.GetById(id);

    if (Book == null)
    {
        throw new CustomException("", "Book not found");
    }

    var dto = new BookDto()
    {
        Id = Book.Id,
        Name = Book.Name,
        ImagePath = Book.ImageUrl
    };

    return dto;
}

public void Update(UpdateBookDto BookDto)
{
    var Book = _unitOfWork.Books.GetById(BookDto.Id);

    if (Book == null)
    {
        throw new CustomException("", "Book not found");
    }

    if (string.IsNullOrEmpty(BookDto.Name))
    {
        throw new CustomException("", "Book name is required");
    }

    if (BookDto.Name.Length < 3 || BookDto.Name.Length > 30)
    {
        throw new CustomException("", "Book name must be between 3 and 30 characters");
    }

    if (BookDto.file != null)
    {
        _fileService.DeleteImage(Book.ImageUrl);
        BookDto.ImagePath = _fileService.UploadImage(BookDto.file);
    }

    Book.Name = BookDto.Name;
    Book.ImageUrl = BookDto.ImagePath;

    _unitOfWork.Books.Update(Book);
}