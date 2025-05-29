using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepositry.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepositry.GetBookById(id);

            return View(data);
        }
        public List<BookModel> searchBook(string title, string author)
        {
            return _bookRepositry.SearchBooks(title, author);
        }
        public ViewResult AddNewBooks(bool isSuccess = false, int bookid = 0)
        {
            ViewBag.languages = new SelectList(GetLanguage(), "Id", "text");

            ViewBag.isSuccess = isSuccess;
            ViewBag.bookid = bookid;    
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBooks(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepositry.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBooks), new { isSuccess = true, bookid = id });
                }
            }

            ViewBag.languages = new SelectList(GetLanguage(), "Id", "text");

            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, text = "English" },
                new LanguageModel() { Id = 2, text = "Urdu" },
                new LanguageModel() { Id = 3, text = "Arabic" },
                new LanguageModel() { Id = 4, text = "French" },
                new LanguageModel() { Id = 5, text = "Spanish" },
                new LanguageModel() { Id = 6, text = "Japanese" },
                new LanguageModel() { Id = 7, text = "German" }
            };
        }
    }
}
