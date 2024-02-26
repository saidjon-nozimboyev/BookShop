namespace Ustoz_Proyekti.Data.Entities;

public class Order : BaseEntity
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<Book> Books { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}