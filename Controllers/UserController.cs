using Crud.NET.Model;
using Microsoft.AspNetCore.Mvc;

namespace Crud.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private static new List<User> User() 
        {
            return new List<User> {
                new User {
                    Nome = "João", 
                    Id = 1,
                    DataNascimento = new DateTime(1999, 09, 11)}
            };
        }  
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(User());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = User();
            users.Add(user);
            return Ok(user);
        }
    }

    
}