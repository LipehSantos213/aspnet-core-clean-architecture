using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;
using api_csharp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context; // Injeta o contexto do banco

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);       // Prepara para salvar o usuário
            await _context.SaveChangesAsync(); // Salva de fato no Postgres
            return user;
        }

        public async Task<User?> Get(int id)
        {
            // Busca o usuário pelo ID, ou retorna null se não achar
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> Login(User user)
        {
            // Busca o usuário que bate com o e-mail informado
            // Nota: Na vida real, você buscaria pelo e-mail e validaria o Hash da senha.
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.Address == user.Email.Address);
        }

        public async Task<User> Update(User user)
        {
            await _context.Users.Where(u=> u.Id == user.Id).ExecuteUpdateAsync(s => s
            .SetProperty(u => u.Name, user.Name)
            .SetProperty(u=> u.Email, user.Email)
            );
            //_context.Users.Update(user);
            //await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .Where(u => u.Email.Address == email)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}