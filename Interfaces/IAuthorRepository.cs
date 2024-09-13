using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorModel>> GetAllAsync();
        Task<AuthorModel?> GetByIdAsync(int id);
        Task<AuthorModel> CreateAsync(AuthorModel author);
        Task<AuthorModel?> UpdateAsync(int id, AuthorModel author);
        Task<AuthorModel?> DeleteAsync(int id);
    }
}
