namespace Ustoz_Proyekti.Data.Entities;

public class Author
{
    public string Name { get; set; } = null!;
    public List<Book> Books { get; set; } = new();
}