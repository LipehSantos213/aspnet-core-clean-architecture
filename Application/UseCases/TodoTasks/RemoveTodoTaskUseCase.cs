using api_csharp.Application.Services;
using api_csharp.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class RemoveTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;

        public RemoveTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<String> Execute(int userId, int id)
        {
            await _userService.AsyncGetUser(userId);
            await _repository.Remove(userId, id);
            return "Tarefa deletada !";
        }
    }
}
