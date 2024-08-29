using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<Book>> GetCartAsync(string userId);
        Task AddToCartAsync(int bookId, ApplicationUser user);
        Task RemoveFromCartAsync(int bookId, ApplicationUser user);
    }
}
