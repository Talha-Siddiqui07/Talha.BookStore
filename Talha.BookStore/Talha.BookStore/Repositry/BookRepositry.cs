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
                new BookModel() { Id = 1, Title = "Great Minds", Author = "Talha Siddiqui" },
                new BookModel() { Id = 2, Title = "JavaScript", Author = "Author 2" },
                new BookModel() { Id = 3, Title = "PHP", Author = "Author 3" },
                new BookModel() { Id = 4, Title = "ASP.Net Core", Author = "Author 4" },
                new BookModel() { Id = 5, Title = "Python", Author = "Author 5" }
            };
        }
    }
}
