using Ustoz_Proyekti.BusinessLogic.DTOs.CategoryDTOs;
using Ustoz_Proyekti.Data.Entities;

namespace Ustoz_Proyekti.BusinessLogic.DTOs.BrendDTOs;

public class AuthorDto : CategoryDto
{
    public static implicit operator AuthorDto(Author author)
        => new()
        {
            Id = author.Id,
            Name = author.Name,
            ImagePath = author.ImageUrl
        };
}
