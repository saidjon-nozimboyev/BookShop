using Ustoz_Proyekti.Data.Interfaces;

namespace Ustoz_Proyekti.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext)
    : IUnitOfWork
{
    public IAuthorInterface Authors => new AuthorRepository(dbContext);

    public IBookInterface Books => new BookRepository(dbContext);

    public ICategoryInterface Categories => new CategoryRepository(dbContext);

    public IImageInterface Images => new ImageRepository(dbContext);

    public IOrderInterface Orders => new OrderRepository(dbContext);

    public IUserInterface Users => new UserRepository(dbContext);
}