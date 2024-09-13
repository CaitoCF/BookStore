using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.Interfaces;

namespace BookStore.Controllers
{
    [Route("api/movement")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementRepository _movementRepository;

        public MovementController(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movements = await _movementRepository.GetAllAsync();

            return Ok(movements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var movement = await _movementRepository.GetByIdAsync(id);

            if (movement == null)
            {
                return null;
            }

            return Ok(movement);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovementModel movementRequest)
        {
            var movement = movementRequest;

            await _movementRepository.CreateAsync(movement);

            return CreatedAtAction(nameof(GetById), new { id = movement.Id }, movement);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MovementModel movementRequest)
        {
            var movement = await _movementRepository.UpdateAsync(id, movementRequest);

            if (movement == null)
            {
                return NotFound();
            }

            return Ok(movement);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var movement = await _movementRepository.DeleteAsync(id);

            if (movement == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
