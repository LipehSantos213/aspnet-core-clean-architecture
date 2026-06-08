using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class CreateTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;

        public CreateTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId,TodoTaskCreateDTO dto)
        {
            await _userService.AsyncGetUser(userId);

            var data = new TodoTask(dto.Title, dto.Description, userId:userId);

            TodoTask todoTask = await _repository.Create(data);

            return new TodoTaskResponseDTO(
                todoTask.Id,
                todoTask.Title,
                todoTask.Description,
                todoTask.Active
                );
        }
    }
}
