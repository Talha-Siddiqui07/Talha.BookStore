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
        public BookModel GetBook(int id)
        {
            return _bookRepositry.GetBookById(id);
        }
        public List<BookModel> searchBook(string title, string author)
        {
            return _bookRepositry.SearchBooks(title, author);
        }
    }
}
