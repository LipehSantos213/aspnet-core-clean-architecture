using api_csharp.Application.DTOs;
using api_csharp.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace api_csharp.Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly GetUserUseCase _getUserUseCase;
        private readonly UpdateUserUseCase _updateUserUseCase;
        private readonly RemoveUserUseCase _removeUserUseCase;

        public UsersController(
            CreateUserUseCase createUserUseCase,
            LoginUserUseCase loginUserUseCase,
            GetUserUseCase getUserUseCase,
            UpdateUserUseCase updateUserUseCase,
            RemoveUserUseCase removeUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _loginUserUseCase = loginUserUseCase;
            _getUserUseCase = getUserUseCase;
            _updateUserUseCase = updateUserUseCase;
            _removeUserUseCase = removeUserUseCase;
        }

        [HttpPost] // Rota: POST api/users
        public async Task<IActionResult> Create([FromBody] UserCreateDTO dto)
        {
                var result = await _createUserUseCase.Execute(dto);

                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var user = await _getUserUseCase.Execute(id);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDTO dto)
        {
            var user = await _updateUserUseCase.Execute(dto);

            return Ok(user);
        }

        [HttpPost("login")] // Rota: POST api/users/login
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
                var user = await _loginUserUseCase.Execute(dto);
                return Ok(user);
        }

        [HttpDelete("{id:int}/logout")]
        public async Task<IActionResult> Logout([FromRoute] int id)
        {
            var response = await _removeUserUseCase.Execute(id);
            return Ok(new { response });
        }
    }
}
