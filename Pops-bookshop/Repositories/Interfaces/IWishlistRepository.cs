using Pops_bookshop.Models.Entities;
using System.Net;

namespace Pops_bookshop.Repositories.Interfaces
{
    public interface IWishlistRepository
    {
        Task<List<Book>> GetWishedBooksAsync(string userId);
        Task AddBookInUserWishlistAsync(Book book, ApplicationUser user);
        Task RemoveBookFromUserWishlistAsync(Book book, ApplicationUser user);
    }
}
