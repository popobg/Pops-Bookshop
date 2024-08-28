namespace Pops_bookshop.Repositories.Interfaces
{
    public interface IWishlistRepository
    {
        Task<bool> IsBookInUserWishlistAsync(int bookId, string userId);
    }
}
