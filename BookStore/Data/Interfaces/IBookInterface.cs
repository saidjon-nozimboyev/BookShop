using Ustoz_Proyekti.Data.Entities;

namespace Ustoz_Proyekti.Data.Interfaces;

public interface IBookInterface : IRepository<Book>
{
    List<Book> GetBooksWithReleations();
}
