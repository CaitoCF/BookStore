using BookStore.Models.Context;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.User.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserModel userRequest)
        {
            var user = userRequest;

            _context.User.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserModel userRequest)
        {
            var user = _context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = userRequest.Name;
            user.Login = userRequest.Login;
            user.Password = userRequest.Password;
            user.Admin = userRequest.Admin;

            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
