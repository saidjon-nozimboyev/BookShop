using Ustoz_Proyekti.Data.Entities;
using Ustoz_Proyekti.Data.Interfaces;

namespace Ustoz_Proyekti.Data.Repositories;

public class AuthorRepository(AppDbContext dbContext)
    : Repository<Author>(dbContext), IAuthorInterface
{
}
