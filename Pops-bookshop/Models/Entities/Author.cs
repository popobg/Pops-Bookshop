namespace Pops_bookshop.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public List<Book> BooksWritten { get; set; } = new List<Book>();
    }
}
