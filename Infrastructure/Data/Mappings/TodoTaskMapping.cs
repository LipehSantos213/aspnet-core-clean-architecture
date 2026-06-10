using api_csharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_csharp.Infrastructure.Data.Mappings
{
    public class TodoTaskMapping : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            // Define o nome da tabela no banco
            builder.ToTable("TodoTask");

            // Define o 'Id' como chave primaria
            builder.HasKey(t => t.Id);

            // Configurando a propriedade 'Title'
            builder.Property(t => t.Title)
                .IsRequired() // NotNull
                .HasMaxLength(150); // --> VarChar(150)

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t => t.Active)
                .HasDefaultValue(true);

            // Configurando a Chave Estrangeira (Relacionamento)
            builder.HasOne(t=> t.User) // Uma tarefa tem um Usuário
                .WithMany(u=>u.Tasks)        // Um usuário tem muitas tarefas
                .HasForeignKey(t => t.UserId) // Chave estrangeira na tabela TodoTasks
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(); // Se apagar o usuário, apaga as tarefas dele
        }
    }
}
