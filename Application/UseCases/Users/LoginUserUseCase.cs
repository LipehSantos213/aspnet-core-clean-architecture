using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.Users
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly UserService _userService;

        public LoginUserUseCase(
            IUserRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public  async Task<UserResponseDTO> Execute(UserLoginDTO dto)
        {
            var data = new User(dto.Name, dto.Email);

            User? user = await _repository.Login(data);

            return user == null? 
                throw new DomainException("Usuario não encontrado !"):
                new UserResponseDTO(
                    user.Id,
                    user.Name,
                    user.Email
                );
        }
    }
}
