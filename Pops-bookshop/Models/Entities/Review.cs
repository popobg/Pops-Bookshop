namespace Pops_bookshop.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int rating { get; set; }
        public string comment { get; set; } = string.Empty;
        public string ReviewerId { get; set; }
        public ApplicationUser? Reviewer { get; set; }
        public int BookId { get; set; }
        public Book? BookReviewed { get; set; }
    }
}
