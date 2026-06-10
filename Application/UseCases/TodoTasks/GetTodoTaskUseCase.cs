using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class GetTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;

        public GetTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService= userService;
        }

        public async Task<TodoTaskResponseDTO> Execute(int userId, int id)
        {
            await _userService.AsyncGetUser(userId);

            var data = await _repository.Get(userId, id);

            return data == null? throw new DomainException("Tarefa não encontrada !"):
                new TodoTaskResponseDTO(
                    data.Id,
                    data.Title,
                    data.Description,
                    data.Active
                );
        }
    }
}
