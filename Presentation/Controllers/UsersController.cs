using api_csharp.Application.DTOs;
using api_csharp.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace api_csharp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;

        public UsersController(CreateUserUseCase createUserUseCase, LoginUserUseCase loginUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _loginUserUseCase = loginUserUseCase;
        }

        [HttpPost] // Rota: POST api/users
        public async Task<IActionResult> Create([FromBody] UserCreateDTO dto)
        {
                var result = await _createUserUseCase.Execute(dto);

                return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }


        [HttpPost("login")] // Rota: POST api/users/login
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
                var user = await _loginUserUseCase.Execute(dto);
                return Ok(user);
        }
    }
}
