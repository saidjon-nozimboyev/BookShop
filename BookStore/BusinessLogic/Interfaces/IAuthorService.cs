using Ustoz_Proyekti.BusinessLogic.DTOs.BrendDTOs;

namespace Ustoz_Proyekti.BusinessLogic.Interfaces;

public interface IAuthorService
{
    List<AuthorDto> GetAll();
    AuthorDto GetById(int id);
    void Create(AddAuthorDto AuthorDto);
    void Update(UpdateAuthorDto AuthorDto);
    void Delete(int id);
}
