using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class UpdateTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;

        public UpdateTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId,TodoTaskUpdateDTO dto)
        {
            await _userService.AsyncGetUser(userId);

            var data = new TodoTask(dto.Title, dto.Description, dto.Id);

            var todoTaskUser = await _repository.Get(userId, dto.Id) ??
                throw new DomainException("Tarefa não encontrda !");

            TodoTask todoTask = await _repository.Update(data);

            return new TodoTaskResponseDTO(
                todoTask.Id,
                todoTask.Title,
                todoTask.Description,
                todoTask.Active
                );
        }
    }
}
