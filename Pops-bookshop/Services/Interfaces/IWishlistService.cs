using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;

namespace Pops_bookshop.Services.Interfaces
{
    public interface IWishlistService
    {
        Task<bool> IsBookInUserWishlistAsync(int bookId, string userId);
        Task<List<Book>> GetWishedBooksAsync(string userId);
    }
}
