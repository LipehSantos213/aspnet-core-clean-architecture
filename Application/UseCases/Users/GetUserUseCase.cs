using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.Users
{
    public class GetUserUseCase
    {
        private readonly IUserRepository _repository;

        public GetUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDTO> Execute(int userId)
        {
            User user =  await _repository.Get(userId);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
                );
        }
    }
}
