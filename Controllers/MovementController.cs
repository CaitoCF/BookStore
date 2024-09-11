using BookStore.Models.Context;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/movement")]
    [ApiController]
    public class MovementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movements = _context.Movement.ToList();

            return Ok(movements);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null)
            {
                return NotFound();
            }

            return Ok(movement);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovementModel movementRequest)
        {
            var movement = movementRequest;

            _context.Movement.Add(movement);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = movement.Id }, movement);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovementModel movementRequest)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null)
            {
                return NotFound();
            }

            movement.IdBook = movementRequest.IdBook;
            movement.IdUser = movementRequest.IdUser;
            movement.Quantity = movementRequest.Quantity;
            movement.TotalPrice = movementRequest.TotalPrice;
            movement.Date = movementRequest.Date;

            _context.SaveChanges();

            return Ok(movement);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null)
            {
                return NotFound();
            }

            _context.Movement.Remove(movement);
            _context.SaveChanges();

            return Ok(movement);
        }
    }
}
