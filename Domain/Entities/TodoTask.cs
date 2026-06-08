using api_csharp.Domain.Exception;

namespace api_csharp.Domain.Entities
{
    public class TodoTask
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
        
        public bool Active { get; private set; }

        public User User { get; private set; } = null!;

        // Construtor privado para o EF Core
        private TodoTask() { }

        public TodoTask(
            string title,
            string description,
            int id = default,
            int userId = default,
            bool active = true)
        {
            Validate(title, description);
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Active = active;
        }

       

        private void Validate(string title, string description)
        {
            if(title.Length <= 5)
            {
                throw new DomainException("Titulo muito curta !");
            }else if(title.Length >= 301)
            {
                throw new DomainException("Titulo muito longa !");
            }

            if(description.Length >= 301)
            {
                throw new DomainException("Descrição muito longa");
            }else if(description.Length<=5)
            {
                throw new DomainException("Descrição muito curta");
            }
        }
    
        public void UpdateTodoTask(string title, string description)
        {
            Title = title ?? Title;
            Description = description ?? Description;
        }
        
        public void UpdateStatus(bool active)
        {
            if(Active == active)
            {
                string isStatus = active ? "ativado" : "desativado";
                throw new DomainException($"A tarefa já é {isStatus}");
            }

            Active = active;
        }
    }
}   
