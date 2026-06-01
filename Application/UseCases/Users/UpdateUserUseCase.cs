using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;
using api_csharp.Domain.ValueObjects;

namespace api_csharp.Application.UseCases.Users
{
    public class UpdateUserUseCase
    {
        private IUserRepository _repository;

        public UpdateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDTO> Excute(UserUpdateDTO dto)
        {
            var data = new User(dto.Name, dto.Email);

            User user = await _repository.Update(data);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
                );
        }
    }
}
