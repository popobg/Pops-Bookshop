using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int bookId);
    }
}
