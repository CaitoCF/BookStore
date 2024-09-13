using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllAsync();
        Task<BookModel?> GetByIdAsync(int id);
        Task<BookModel> CreateAsync(BookModel book);
        Task<BookModel?> UpdateAsync(int id, BookModel book);
        Task<BookModel?> DeleteAsync(int id);
    }
}
