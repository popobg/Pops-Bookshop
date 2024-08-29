using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;

namespace Pops_bookshop.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BookshopDbContext _context;

        public CartRepository(BookshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetCartAsync(string userId)
        {
            try
            {
                List<Book> books = await _context.Books
                                .Where(b => b.UsersCart.Any(w => w.UserId == userId))
                                .ToListAsync();

                return books;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task AddToCartAsync(Book book, ApplicationUser user)
        {
            try
            {
                // Book is already in the wishlist
                if (user.Cart.Any(w => w.BookId == book.Id)) return;

                // create the cartBook entity and add it to the join table
                //await CreateCartBookAsync(book, user);

                CartBook cart = new CartBook()
                {
                    UserId = user.Id,
                    User = user,
                    BookId = book.Id,
                    Book = book
                };

                user.Cart.Add(cart);
                book.UsersCart.Add(cart);

                await _context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task RemoveFromCartAsync(Book book, ApplicationUser user)
        {
            try
            {
                if (user.Cart.Any(c => c.BookId == book.Id))
                {
                    CartBook? cartBook = user.Cart.Find(w => w.BookId == book.Id);

                    if (cartBook == null) throw new NullException();

                    // automatically delete the wishedBook entry
                    // from the cartBook join table
                    user.Cart.Remove(cartBook);

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

        private async Task CreateCartBookAsync(Book book, ApplicationUser user)
        {
            CartBook cart = new CartBook()
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
    }
}