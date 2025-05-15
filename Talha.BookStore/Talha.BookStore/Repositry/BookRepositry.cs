using System.Reflection.Metadata.Ecma335;
using Talha.BookStore.Models;

namespace Talha.BookStore.Repositry
{
    public class BookRepositry
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSourse();
        }
        public BookModel GetBookById(int id)
        {
            return DataSourse().Where(x => x.Id == id).FirstOrDefault();
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
