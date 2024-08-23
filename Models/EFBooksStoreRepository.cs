using System.Linq;

namespace BooksStore.Models
{
    public class EFBooksStoreRepository : IBooksStoreRepository
    {
        private BooksStoreDbContext context;
        public EFBooksStoreRepository(BooksStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
