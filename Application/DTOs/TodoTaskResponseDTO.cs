namespace api_csharp.Application.DTOs
{
    public class TodoTaskResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public TodoTaskResponseDTO(int id, string title, string description, bool active)
        {
            Id = id;
            Title = title;
            Description = description;
            Active = active;
        }
    }
}
