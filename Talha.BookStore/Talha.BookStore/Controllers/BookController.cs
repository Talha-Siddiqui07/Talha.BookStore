using Microsoft.AspNetCore.Mvc;
using Talha.BookStore.Models;
using Talha.BookStore.Repositry;

namespace Talha.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepositry = null;
        public BookController()
        {
            _bookRepositry = new BookRepositry();
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepositry.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data = _bookRepositry.GetBookById(id);

            return View(data);
        }
        public List<BookModel> searchBook(string title, string author)
        {
            return _bookRepositry.SearchBooks(title, author);
        }
        public ViewResult AddNewBooks()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBooks(BookModel bookModel)
        {
            return View();
        }
    }
}
