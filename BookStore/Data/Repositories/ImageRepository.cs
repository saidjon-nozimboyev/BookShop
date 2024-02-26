using Ustoz_Proyekti.Data.Entities;
using Ustoz_Proyekti.Data.Interfaces;

namespace Ustoz_Proyekti.Data.Repositories;

public class ImageRepository(AppDbContext dbContext)
    : Repository<Image>(dbContext), IImageInterface
{
}
