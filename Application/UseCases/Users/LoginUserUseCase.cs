using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.Users
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _repository;

        public LoginUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public  async Task<UserResponseDTO> Execute(UserLoginDTO dto)
        {
            var data = new User(dto.Name, dto.Email);

            User user = await _repository.Login(data);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
                );
        }
    }
}
