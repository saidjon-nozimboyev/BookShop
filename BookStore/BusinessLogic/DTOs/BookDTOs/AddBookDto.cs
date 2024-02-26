using Ustoz_Proyekti.BusinessLogic.DTOs.BrendDTOs;
using Ustoz_Proyekti.BusinessLogic.DTOs.CategoryDTOs;

namespace Ustoz_Proyekti.BusinessLogic.DTOs.BookDTOs;

public class AddBookDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }

    public List<CategoryDto> Categories { get; set; } = new();
    public List<AuthorDto> Authors { get; set; } = new();
}
