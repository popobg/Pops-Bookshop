using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<bool> IsBookInUserWishlistAsync(int bookId, string userId)
        {
            try
            {
                return await _wishlistRepository.IsBookInUserWishlistAsync(bookId, userId);
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }
    }
}
