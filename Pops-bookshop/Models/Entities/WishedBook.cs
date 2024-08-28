namespace Pops_bookshop.Models.Entities
{
    // Join table between Book and User
    public class WishedBook
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
