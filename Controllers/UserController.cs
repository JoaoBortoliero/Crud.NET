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

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.CreateUser(user);
            return await _repository.SaveChangesAsync()
                ? Ok("Usuário cadastrado com sucesso!")
                : BadRequest("Erro ao cadastrar usuário!");
        }
    }


}