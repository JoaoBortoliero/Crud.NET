using Crud.NET.Model;
using Crud.NET.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crud.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.SearchUser();
            return users.Any()
                ? Ok(users)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _repository.SearchUserById(id);
            return users != null
                ? Ok(users)
                : NotFound("User not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.CreateUser(user);
            return await _repository.SaveChangesAsync()
                ? Ok("Successfully registered user!")
                : BadRequest("Error registering user!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var userExists = await _repository.SearchUserById(id);
            if (user == null)
                return NotFound("User not found");

            userExists.Name = user.Name ?? userExists.Name;
            userExists.BirthDate = user.BirthDate != new DateTime()
                ? user.BirthDate 
                : userExists.BirthDate;
            _repository.UpdateUser(userExists);
            
            return await _repository.SaveChangesAsync()
                ? Ok("Successfully updated user!")
                : BadRequest("Error updating user!");
        }
    }
}