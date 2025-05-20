using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Talha.BookStore.Data;
using Talha.BookStore.Models;

namespace Talha.BookStore.Repositry
{
    public class BookRepositry
    {

        private readonly BookStoreContext _context = null;

        public BookRepositry(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newbook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                category = model.category,
                language = model.language,
                Description = model.Description,
                totalpages = model.totalpages,
                createdon = DateTime.UtcNow,
            };

            await _context.Books.AddAsync(newbook);
            await _context.SaveChangesAsync();

            return newbook.Id;
        }
        
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Id = book.Id,
                        category = book.category,
                        totalpages = book.totalpages,
                        Description = book.Description,
                        language = book.language
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookdetail = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Id = book.Id,
                    category = book.category,
                    totalpages = book.totalpages,
                    Description = book.Description,
                    language = book.language
                };
                return bookdetail;
                
            }
            return null;

        }
        public List<BookModel> SearchBooks(string title, string author)
        {
            return DataSourse().Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSourse()
        {
            return new List<BookModel>
            {
                new BookModel() { Id = 1, Title = "Great Minds", Author = "Talha Siddiqui", Description = "Great Mind's Description", category = "Motivational", language = "English", totalpages = 169 },
                new BookModel() { Id = 2, Title = "JavaScript", Author = "Author 2", Description = "JS's Description", category = "Programming", language = "English", totalpages = 172 },
                new BookModel() { Id = 3, Title = "PHP", Author = "Author 3", Description = "PHP's Description", category = "Programming", language = "English", totalpages = 136 },
                new BookModel() { Id = 4, Title = "ASP.Net Core", Author = "Author 4", Description = "ASP.Net Core's Description", category = "Framework", language = "English", totalpages = 1169 },
                new BookModel() { Id = 5, Title = "Python", Author = "Author 5", Description = "Python's Description", category = "Concepts", language = "English", totalpages = 1613 }
            };
        }
    }
}
