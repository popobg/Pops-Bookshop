using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Repositories.Interfaces
{
    public interface IWishlistRepository
    {
        Task<bool> IsBookInUserWishlistAsync(int bookId, string userId);
        Task<List<Book>> GetWishedBooksAsync(string userId);
    }
}
