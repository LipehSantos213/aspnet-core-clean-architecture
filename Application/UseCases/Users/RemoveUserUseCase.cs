using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.Users
{
    public class RemoveUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly UserService _userService;

        public RemoveUserUseCase(
            IUserRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<string> Execute(int userId)
        {
            User user = await _userService.AsyncGetUser(userId);

            return await _repository.Remove(user);
        }
    }
}
