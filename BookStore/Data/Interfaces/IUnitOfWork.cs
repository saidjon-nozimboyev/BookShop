namespace Ustoz_Proyekti.Data.Interfaces;

public interface IUnitOfWork
{
    IAuthorInterface Authors { get; }
    IBookInterface Books { get; }
    ICategoryInterface Categories { get; }
    IImageInterface Images { get; }
    IOrderInterface Orders { get; }
    IUserInterface Users { get; }
}
