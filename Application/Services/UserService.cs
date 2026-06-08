using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AsyncGetUser(int userId)
        {
            if(userId == 0)
            {
                throw new DomainException("Forneça o 'Id' valido !");
            }
            return await _repository.Get(userId) ??
                throw new DomainException("Usuario não encontrado !");
        }
    
        public async Task<User?> AsyncGetUserByEmail(string email)
        {
            return await _repository.GetUserByEmail(email);
        }
    }
}
