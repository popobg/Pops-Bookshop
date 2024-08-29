using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Book>> GetCartAsync(string userId);
        Task AddToCartAsync(Book book, ApplicationUser user);
        Task RemoveFromCartAsync(Book book, ApplicationUser user);
    }
}
