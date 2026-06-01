using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class GetAllTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;

        public GetAllTodoTaskUseCase(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoTaskResponseDTO>> Execute(int userId)
        {
            var todoTasks = await _repository.GetAll(userId);
            List<TodoTaskResponseDTO> response = [];

            foreach (TodoTask item in todoTasks)
            {
                response.Add(new TodoTaskResponseDTO(item.Id, item.Title, item.Description, item.Active));
            }

            return response;
        }
    }
}
