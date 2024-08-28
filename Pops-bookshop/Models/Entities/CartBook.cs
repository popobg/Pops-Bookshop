namespace Pops_bookshop.Models.Entities
{
    public class CartBook
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
