using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IBooksStoreRepository repository;
        public GenreNavigation(IBooksStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Books
                  .Select(x => x.Genre)
                  .Distinct()
                  .OrderBy(x => x));
        }
    }
}
