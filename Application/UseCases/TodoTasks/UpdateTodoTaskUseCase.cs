using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class UpdateTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;

        public UpdateTodoTaskUseCase(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId,TodoTaskUpdateDTO dto)
        {
            var data = new TodoTask(dto.Title, dto.Description, dto.Id);

            TodoTask todoTask = await _repository.Update(userId,data);

            return new TodoTaskResponseDTO(
                todoTask.Id,
                todoTask.Title,
                todoTask.Description,
                todoTask.Active
                );
        }
    }
}
