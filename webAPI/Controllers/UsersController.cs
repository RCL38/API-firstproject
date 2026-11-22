using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User? user = _usersService.GetById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            User? newUser = _usersService.SignUp(user);
            if (newUser == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = newUser.userId }, newUser);
        }

        // POST api/User/login
        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLogIn loginUser)
        {
            User? user = _usersService.Login(loginUser);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost("password")]
        public IActionResult Post([FromBody] string password)
        {
            return Ok(_usersService.CheckPassword(password));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            User? updatedUser = _usersService.Update(id, user);
            if (updatedUser == null)
                return NoContent();
            return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}