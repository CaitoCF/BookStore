using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IMovementRepository
    {
        Task<List<MovementModel>> GetAllAsync();
        Task<MovementModel?> GetByIdAsync(int id);
        Task<MovementModel> CreateAsync(MovementModel movement);
        Task<MovementModel?> UpdateAsync(int id, MovementModel movement);
        Task<MovementModel?> DeleteAsync(int id);
    }
}
