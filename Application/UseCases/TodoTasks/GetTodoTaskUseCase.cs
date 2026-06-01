using api_csharp.Application.DTOs;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class GetTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;

        public GetTodoTaskUseCase(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId, int id)
        {
            var data = await _repository.Get(userId, id);

            return new TodoTaskResponseDTO(
                data.Id,
                data.Title,
                data.Description,
                data.Active
                );
        }
    }
}
