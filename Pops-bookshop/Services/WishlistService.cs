using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Services.Interfaces;
using System.Net;

namespace Pops_bookshop.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IBookRepository _bookRepository;

        public WishlistService(IWishlistRepository wishlistRepository, IBookRepository bookRepository)
        {
            _wishlistRepository = wishlistRepository;
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetWishedBooksAsync(string userId)
        {
            try
            {
                List<Book> books = await _wishlistRepository.GetWishedBooksAsync(userId);

                return books;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task AddBookToWishlistAsync(int bookId, ApplicationUser user)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                if (book == null) throw new NullException();

                await _wishlistRepository.AddBookInUserWishlistAsync(book, user);
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

        public async Task RemoveBookFromWishlistAsync(int bookId, ApplicationUser user)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                if (book == null) throw new NullException();

                await _wishlistRepository.RemoveBookFromUserWishlistAsync(book, user);
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
