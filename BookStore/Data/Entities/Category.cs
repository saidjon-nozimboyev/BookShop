namespace Ustoz_Proyekti.Data.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public List<Book> Books { get; set; } = new();
}