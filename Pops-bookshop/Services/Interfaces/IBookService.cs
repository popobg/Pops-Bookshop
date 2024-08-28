using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int bookId);
    }
}
