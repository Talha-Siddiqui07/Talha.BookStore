using Microsoft.AspNetCore.Mvc;
using Talha.BookStore.Models;
using Talha.BookStore.Repositry;

namespace Talha.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepositry = null;
        public BookController(BookRepositry bookRepositry)
        {
            _bookRepositry = bookRepositry;
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
        public ViewResult AddNewBooks(bool isSuccess = false, int bookid = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookid = bookid;    
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBooks(BookModel bookModel)
        {
            int id = _bookRepositry.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBooks), new {isSuccess = true, bookid = id});
            }
            return View();
        }
    }
}
