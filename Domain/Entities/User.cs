using api_csharp.Domain.Exception;
using api_csharp.Domain.ValueObjects;

namespace api_csharp.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Email Email { get; private set; }

        public List<TodoTask> Tasks { get; } = new();

        // Construtor privado para o EF Core
        private User() { }

        // Construtor utilizado na aplicação
        public User(string name, string email, int id=0)
        {
            ValidateName(name);
            Id = id;
            Name = name;
            Email = new Email(email);
        }

        private void ValidateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new DomainException("Digite o nome novamente !");
            }
        }    
    }
}
