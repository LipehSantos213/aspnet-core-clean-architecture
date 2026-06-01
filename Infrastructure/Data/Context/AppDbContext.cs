using api_csharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace api_csharp.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        // O construtor recebe as configurações que virão lá do Program.cs (como a Connection String)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Mapeia suas Entidades para Tabelas no Banco
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Isso aqui diz pro EF Core ler as configurações de tabelas adicionais se você criar
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}