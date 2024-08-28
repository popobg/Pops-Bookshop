using System.Text.RegularExpressions;

namespace Pops_bookshop.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public List<Book> BooksOrdered { get; set; } = new List<Book>();
        public string? BuyerId { get; set; } = string.Empty;
        public ApplicationUser? Buyer { get; set; }
    }
}
