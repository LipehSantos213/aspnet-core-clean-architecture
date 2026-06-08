using api_csharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_csharp.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Define o nome da tabela no PostgreSQL
            builder.ToTable("users");

            // Define o 'Id' como chave primaria
            builder.HasKey(u => u.Id);

            // Configuração da propriedade (coluna) 'Name' no banco
            builder.Property(u => u.Name)
                .IsRequired() // NotNull
                .HasMaxLength(100); // --> VarChar(100)

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Address)
                    .HasColumnName("Email") // Nome da coluna no banco
                    .IsRequired()
                    .HasMaxLength(150);
            });

            // Configuração para o EF conseguir ler propriedades com "private set"
            builder.Navigation(u => u.Email).IsRequired();
        }
    }
}
