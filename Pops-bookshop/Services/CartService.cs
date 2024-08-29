using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookRepository _bookRepository;

        public CartService(ICartRepository cartRepository, IBookRepository bookRepository)
        {
            _cartRepository = cartRepository;
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetCartAsync(string userId)
        {
            try
            {
                List<Book> books = await _cartRepository.GetCartAsync(userId);

                return books;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task AddToCartAsync(int bookId, ApplicationUser user)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                if (book == null) throw new NullException();

                await _cartRepository.AddToCartAsync(book, user);
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

        public async Task RemoveFromCartAsync(int bookId, ApplicationUser user)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                if (book == null) throw new NullException();

                await _cartRepository.RemoveFromCartAsync(book, user);
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
    }
}
