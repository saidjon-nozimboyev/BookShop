using Ustoz_Proyekti.Data.Entities;
using Ustoz_Proyekti.Data.Interfaces;

namespace Ustoz_Proyekti.Data.Repositories;

public class OrderRepository(AppDbContext dbContext)
    : Repository<Order>(dbContext), IOrderInterface
{
}
