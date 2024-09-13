using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookModel> CreateAsync(BookModel bookRequest)
        {
            await _context.Book.AddAsync(bookRequest);
            await _context.SaveChangesAsync();

            return bookRequest;
        }

        public async Task<BookModel?> DeleteAsync(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null) 
            {
                return null;
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<BookModel?> GetByIdAsync(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task<BookModel?> UpdateAsync(int id, BookModel bookRequest)
        {
            var book = await _context.Book.FindAsync(id);

            if (book== null)
            {
                return null;
            }

            book.Name = bookRequest.Name;
            book.IdAuthor = bookRequest.IdAuthor;
            book.Price = bookRequest.Price;

            await _context.SaveChangesAsync();

            return book;
        }
    }
}
