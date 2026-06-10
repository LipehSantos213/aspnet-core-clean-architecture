using api_csharp.Application.DTOs;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class UpdateStatusTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;

        public UpdateStatusTodoTaskUseCase(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId, int id, bool value)
        {
            TodoTask todoTask = await _repository.Get(userId, id) ??
                throw new DomainException("Tarefa não encontrada !");

            if(todoTask.Active == value)
            {
                string status = value ? "ativada" : "desativada";
                throw new DomainException($"A tarefa já esta {status}");
            }

            todoTask.UpdateStatus(value);

            await _repository.Update(todoTask);

            return new TodoTaskResponseDTO(
                todoTask.Id,
                todoTask.Title,
                todoTask.Description,
                !todoTask.Active
                );
        }
    }
}
