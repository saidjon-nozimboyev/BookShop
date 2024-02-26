using Ustoz_Proyekti.BusinessLogic.DTOs.BookDTOs;

namespace Ustoz_Proyekti.BusinessLogic.Interfaces;

public interface IBookService
{
    List<BookDto> GetAll();
    BookDto GetById(int id);
    void Create(AddBookDto BookDto);
    void Update(UpdateBookDto BookDto);
    void Delete(int id);
}
