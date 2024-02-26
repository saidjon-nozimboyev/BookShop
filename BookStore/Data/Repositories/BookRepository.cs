namespace Ustoz_Proyekti.Data.Repositories;

public class BookRepository(AppDbContext dbContext)
    : Repository<Book>(dbContext), IBookInterface
{
    public List<Book> GetBooksWithReleations()
        => _dbContext.Books
            .Include(c => c.Category)
            .Include(c => c.Brend)
            .Include(c => c.Colors)
            .ThenInclude(c => c.Images)
            .ToList();
}
