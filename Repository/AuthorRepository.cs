using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AuthorModel> CreateAsync(AuthorModel authorRequest)
        {
            await _context.Author.AddAsync(authorRequest);
            await _context.SaveChangesAsync();

            return authorRequest;
        }

        public async Task<AuthorModel?> DeleteAsync(int id)
        {
            var author = await _context.Author.FindAsync(id);

            if (author == null)
            {
                return null;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<List<AuthorModel>> GetAllAsync()
        {
            return await _context.Author.ToListAsync();
        }

        public async Task<AuthorModel?> GetByIdAsync(int id)
        {
            return await _context.Author.FindAsync(id);
        }

        public async Task<AuthorModel?> UpdateAsync(int id, AuthorModel authorRequest)
        {
            var author = await _context.Author.FindAsync(id);

            if (author == null)
            {
                return null;
            }

            author.Name = authorRequest.Name;

            await _context.SaveChangesAsync();

            return author;
        }
    }
}
