using Microsoft.EntityFrameworkCore;
using Ustoz_Proyekti.Data.Entities;

namespace Ustoz_Proyekti.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){ }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Users { get; set; }
}
