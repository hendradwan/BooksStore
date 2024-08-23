namespace BooksStore.Models
{
    public interface IBooksStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
