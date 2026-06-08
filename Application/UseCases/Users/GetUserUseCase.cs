using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.Users
{
    public class GetUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly UserService _userService;

        public GetUserUseCase(
            IUserRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<UserResponseDTO> Execute(int userId)
        {
            User user =  await _userService.AsyncGetUser(userId);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
                );
        }
    }
}
