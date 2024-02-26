using Ustoz_Proyekti.BusinessLogic.DTOs.BrendDTOs;
using Ustoz_Proyekti.BusinessLogic.DTOs.CategoryDTOs;

namespace Ustoz_Proyekti.BusinessLogic.DTOs.BookDTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public CategoryDto Category { get; set; } = new();
    public AuthorDto Author { get; set; } = new();
}
