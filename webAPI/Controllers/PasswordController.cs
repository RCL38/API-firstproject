using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
     

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
           
        }

        // POST api/<UsersController>
        [HttpPost]
        //The assignment asks this controller to take the password service's interface and call it: where is the password service? It doesn't exist yet, ask where it should be used
        public IActionResult Post([FromBody] string password)
        {
            var results = Zxcvbn.Core.EvaluatePassword(password);
            return Ok(results.Score);

        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userwithupdate)
        {
            
            
        }
        // DELETE api/<UsersController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
