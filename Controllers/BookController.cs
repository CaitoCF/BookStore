using BookStore.Models.Context;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Book.ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookModel bookRequest)
        {
            var book = bookRequest;

            _context.Book.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BookModel bookRequest)
        {
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = bookRequest.Name;
            book.IdAuthor = bookRequest.IdAuthor;
            book.Price = bookRequest.Price;

            _context.SaveChanges();

            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id) {  
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            _context.SaveChanges();

            return Ok(book);
        }
    }
}
