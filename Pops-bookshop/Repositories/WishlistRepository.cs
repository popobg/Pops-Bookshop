using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using System.Net;

namespace Pops_bookshop.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly BookshopDbContext _context;

        public WishlistRepository(BookshopDbContext context)
        {
            _context = context;
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

        public async Task AddBookInUserWishlistAsync(Book book, ApplicationUser user)
        {
            try
            {
                // Book is already in the wishlist
                if (user.Wishlist.Any(w => w.BookId == book.Id)) return;

                WishedBook wishedBook = new WishedBook()
                {
                    UserId = user.Id,
                    User = user,
                    BookId = book.Id,
                    Book = book
                };

                user.Wishlist.Add(wishedBook);

                await _context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task RemoveBookFromUserWishlistAsync(Book book, ApplicationUser user)
        {
            try
            {


                if (user.Wishlist.Any(w => w.BookId == book.Id))
                {
                    user.Wishlist.Remove()
                    await _context.SaveChangesAsync();
                }
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }
    }
}
