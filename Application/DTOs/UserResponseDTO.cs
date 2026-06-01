using api_csharp.Domain.ValueObjects;

namespace api_csharp.Application.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Email Email { get; set; }

        public UserResponseDTO(int id, string name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
