using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Services.Interfaces;
using System.Net;

namespace Pops_bookshop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                List<Book> books = await _bookRepository.GetBooksAsync();

                return books;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }

        public async Task<Book?> GetBookByIdAsync(int bookId)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                return book;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }
    }
}
