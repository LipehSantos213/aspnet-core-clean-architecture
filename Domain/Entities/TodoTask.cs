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

        public TodoTask(string title, string description, int id = 0, int userId = 0)
        {
            Validate(title, description);
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
        }

        private void Validate(string title, string descripion)
        {
            if(title.Length <= 5)
            {
                throw new DomainException("Titulo muito curta !");
            }else if(title.Length >= 301)
            {
                throw new DomainException("Titulo muito longa !");
            }

            if(descripion.Length >= 301)
            {
                throw new DomainException("Descrição muito longa");
            }else if(descripion.Length<=5)
            {
                throw new DomainException("Descrição muito curta");
            }
        }
    
        public void Disable()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }
    
        public void Update(string title, string description)
        {
            Validate(title, description);

            Title = title;
            Description = description;
        }
    }
}   
