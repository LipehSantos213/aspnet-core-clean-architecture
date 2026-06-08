using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;
using api_csharp.Domain.ValueObjects;

namespace api_csharp.Application.UseCases.Users
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly UserService _userService;

        public UpdateUserUseCase(
            IUserRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<UserResponseDTO> Execute(UserUpdateDTO dto)
        {
            await _userService.AsyncGetUser(dto.Id);

            var data = new User(dto.Name, dto.Email, id: dto.Id);

            User user = await _repository.Update(data);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
                );
        }
    }
}
