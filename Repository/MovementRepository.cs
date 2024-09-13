using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class MovementRepository : IMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovementModel> CreateAsync(MovementModel movementRequest)
        {
            await _context.Movement.AddAsync(movementRequest);
            await _context.SaveChangesAsync();

            return movementRequest;
        }

        public async Task<MovementModel?> DeleteAsync(int id)
        {
            var movement = await _context.Movement.FindAsync(id);

            if (movement == null)
            {
                return null;
            }

            _context.Movement.Remove(movement);
            await _context.SaveChangesAsync();

            return movement;
        }

        public async Task<List<MovementModel>> GetAllAsync()
        {
            return await _context.Movement.ToListAsync();
        }

        public async Task<MovementModel?> GetByIdAsync(int id)
        {
            return await _context.Movement.FindAsync(id);
        }

        public async Task<MovementModel?> UpdateAsync(int id, MovementModel movementRequest)
        {
            var movement = await _context.Movement.FindAsync(id);

            if (movement == null)
            {
                return null;
            }

            movement.IdBook = movementRequest.IdBook;
            movement.IdUser= movementRequest.IdUser;
            movement.Quantity = movementRequest.Quantity;
            movement.TotalPrice = movementRequest.TotalPrice;
            movement.Date = movementRequest.Date;

            await _context.SaveChangesAsync();

            return movement;
        }
    }
}
