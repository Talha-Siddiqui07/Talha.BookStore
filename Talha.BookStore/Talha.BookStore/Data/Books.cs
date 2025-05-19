namespace Talha.BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public int totalpages { get; set; }
        public DateTime? createdon { get; set; }
        public DateTime? updatedon { get; set; }
    }
}
