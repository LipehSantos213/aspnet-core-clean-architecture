using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;
using api_csharp.Domain.ValueObjects;

namespace api_csharp.Application.UseCases.Users
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDTO> Execute(UserCreateDTO dto)
        {
            var emailExisting = await _repository.GetUserByEmail(dto.Email);

            if (emailExisting != null)
            {
                throw new DomainException("Email ~já cadastrado, tente outro !");
            }

            var data = new User(dto.Name, dto.Email);

            User user =  await _repository.Create(data);

            return new UserResponseDTO(
                user.Id,
                user.Name,
                user.Email
             );
        }
    }
}
