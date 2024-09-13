using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<UserModel> CreateAsync(UserModel user);
        Task<UserModel?> UpdateAsync(int id, UserModel user);
        Task<UserModel?> DeleteAsync(int id);
    }
}
