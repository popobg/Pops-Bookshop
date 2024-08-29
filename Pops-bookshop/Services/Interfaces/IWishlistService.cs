using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;

namespace Pops_bookshop.Services.Interfaces
{
    public interface IWishlistService
    {
        Task<List<Book>> GetWishedBooksAsync(string userId);
        Task AddBookToWishlistAsync(int bookId, ApplicationUser user);
        Task RemoveBookFromWishlistAsync(int bookId, ApplicationUser user);
    }
}
