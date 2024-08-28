using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Exceptions;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace Pops_bookshop.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookshopDbContext _context;

        public BookRepository(BookshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                List<Book> books = await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .ToListAsync();

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
                Book? book = await _context.Books
                    .Include(b => b.Authors)
                    .Include(b => b.Categories)
                    .Include(b => b.Reviews)
                    .Include(b => b.UsersWishlist)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                return book;
            }
            catch (SqlException)
            {
                throw new DatabaseException();
            }
        }
    }
}
