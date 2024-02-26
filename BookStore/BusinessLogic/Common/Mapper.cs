using Ustoz_Proyekti.Data.Entities;

namespace Ustoz_Proyekti.BusinessLogic.Common;

public static class Mapper
{
    public static BookDto toBookDto(this Book book)
        => new()
        {
            Id = book.Id,
            Name = book.Name,
            Description = book.Description,
            Price = book.Price,
            Category = (CategoryDto)book.Category,
            Author = (AuthorDto)book.Author

        };
}
