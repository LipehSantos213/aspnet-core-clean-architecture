namespace api_csharp.Application.DTOs
{
    public class TodoTaskUpdateDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
