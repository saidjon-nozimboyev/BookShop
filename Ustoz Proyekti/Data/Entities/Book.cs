namespace Ustoz_Proyekti.Data.Entities;

public class Book: BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string ISBN { get; set; }
}
