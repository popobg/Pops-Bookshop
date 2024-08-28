namespace Pops_bookshop.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ISBN { get; set; } = string.Empty ;
        public string? CoverImageUrl { get; set; } = null;
        public string? CoverImagePublicId { get; set; } = null;
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Order> Commands { get; set; } = new List<Order>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<WishedBook> UsersWishlist { get; set; } = new List<WishedBook>();
        public List<CartBook> UsersCart { get; set; } = new List<CartBook>();
    }
}
