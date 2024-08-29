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

                // create the wishedBook entity and add it to the join table
                await CreateWishedBookAsync(book, user);
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
                    WishedBook? wishedBook = user.Wishlist.Find(w => w.BookId == book.Id);

                    if (wishedBook == null) throw new NullException();

                    // automatically delete the wishedBook entry
                    // from the WishedBook join table
                    user.Wishlist.Remove(wishedBook);

                    await _context.SaveChangesAsync();
                }
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
            catch (NullException)
            {
                throw new NullException();
            }
        }

        private async Task CreateWishedBookAsync(Book book, ApplicationUser user)
        {
            WishedBook wishedBook = new WishedBook()
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };

            await _context.WishedBooks.AddAsync(wishedBook);
            await _context.SaveChangesAsync();
        }
    }
}