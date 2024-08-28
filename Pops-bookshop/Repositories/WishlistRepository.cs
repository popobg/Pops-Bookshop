using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;

namespace Pops_bookshop.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly BookshopDbContext _context;

        public WishlistRepository(BookshopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsBookInUserWishlistAsync(int bookId, string userId)
        {
            try
            {
                bool IsBookInWishlist = await _context.Users
                                .Where(u => u.Id == userId)
                                .Include(u => u.Wishlist)
                                .AnyAsync(u => u.Wishlist.Any(w => w.BookId == bookId));

                return IsBookInWishlist;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task<List<Book>> GetWishedBooksAsync(string userId)
        {
            try
            {
                List<Book> books = await _context.Books
                                .Where(b => b.UsersWishlist.Any(w => w.UserId == userId))
                                .ToListAsync();

                return books;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }
    }
}
