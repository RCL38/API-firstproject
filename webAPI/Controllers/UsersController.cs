using Microsoft.AspNetCore.Mvc;

using Services;
using Entity;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;

        public UsersController(IUserService usersService)
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
        public async Task<IActionResult> Get(int id)
        {

            User user = await _usersService.GetUserById(id);
            if (user == null) return NoContent();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User added = await _usersService.AddUser(user);
            if (added == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = added.Id },
            added);
        }


        // POST api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Post([FromBody] UserLogIn loginUser)
        {
            User login = await _usersService.Login(loginUser);
            if (login == null) return NoContent();
            return Ok(login);
        }

        //[HttpPost("password")]
        //public IActionResult Post([FromBody] string password)
        //{
        //    return Ok(_usersService.CheckPassword(password));
        //}

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            User update = await _usersService.UpdateUser(id, user);
            if (update == null) return BadRequest();
            return Ok(update);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
