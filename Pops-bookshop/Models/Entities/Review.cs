namespace Pops_bookshop.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string ReviewerId { get; set; } = string.Empty;
        public ApplicationUser? Reviewer { get; set; }
        public int BookId { get; set; }
        public Book? BookReviewed { get; set; }
    }
}
