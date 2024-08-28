using Microsoft.Data.SqlClient;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Services.Interfaces;

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
    }
}
