using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateAsync(UserModel userRequest)
        {
            await _context.User.AddAsync(userRequest);
            await _context.SaveChangesAsync();

            return userRequest;
        }

        public async Task<UserModel?> DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<UserModel?> UpdateAsync(int id, UserModel userRequest)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            user.Name = userRequest.Name;
            user.Login = userRequest.Login;
            user.Password = userRequest.Password;
            user.Admin = userRequest.Admin;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
