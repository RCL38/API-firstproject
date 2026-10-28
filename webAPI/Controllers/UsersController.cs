using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        private readonly string filePath = "users.txt";

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
            if (!System.IO.File.Exists(filePath))
                return NoContent();

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        return Ok(user);
                }
            }
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);

            
            return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }
        // POST api/User/login
        [HttpPost("login")]
        //Two different actions are both called Post. A name that says what it does is clearer here, for example Login
        public IActionResult Post([FromBody] UserLogIn loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password == loginUser.password)
                        return Ok(user);
                }
            }
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //Parameters are camelCase with a capital letter for each new word, for example userWithUpdate
        public IActionResult Put(int id, [FromBody] User userwithupdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }

            if (textToReplace != string.Empty)
            {
                userwithupdate.userId = id; 
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userwithupdate));
                System.IO.File.WriteAllText(filePath, text);
                return Ok(userwithupdate);
            }
            return NoContent();
        }
        // DELETE api/<UsersController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
