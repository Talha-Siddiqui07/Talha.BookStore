using System.ComponentModel.DataAnnotations;

namespace Talha.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter authors name")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        [Required(ErrorMessage = "Enter total pages of the book")]
        public int? totalpages { get; set; }

    }
}
