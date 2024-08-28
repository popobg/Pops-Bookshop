﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Exceptions;
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
    }
}
