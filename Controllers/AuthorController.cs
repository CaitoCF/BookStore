using BookStore.Models.Context;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _context.Book.ToList();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var author = _context.Author.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuthorModel authorRequest)
        {
            var author = authorRequest;

            _context.Author.Add(author);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] AuthorModel authorRequest)
        {
            var author = _context.Author.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            author.Name = authorRequest.Name;

            _context.SaveChanges();

            return Ok(author);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var author = _context.Author.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            _context.SaveChanges();

            return Ok(author);
        }
    }
}
