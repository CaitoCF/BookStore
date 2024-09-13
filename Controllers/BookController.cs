using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Interfaces;

namespace BookStore.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel bookRequest)
        {
            var book = bookRequest;

            await _bookRepository.CreateAsync(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookModel bookRequest)
        {
            var book = await _bookRepository.UpdateAsync(id, bookRequest);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id) {  
            var book = await _bookRepository.DeleteAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
