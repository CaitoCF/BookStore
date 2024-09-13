using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.Interfaces;

namespace BookStore.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorModel authorRequest)
        {
            var author = authorRequest;

            await _authorRepository.CreateAsync(author);

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AuthorModel authorRequest)
        {
            var author = await _authorRepository.UpdateAsync(id, authorRequest);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var author = await _authorRepository.DeleteAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
