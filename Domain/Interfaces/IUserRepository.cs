using api_csharp.Domain.Entities;
using System.Runtime.CompilerServices;

namespace api_csharp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User?> Login(User user);

        Task<User> Update(User user);

        Task<User?> Get(int id);

        Task<User?> GetUserByEmail(string email);

        Task<string> Remove(User user);
    }
}
