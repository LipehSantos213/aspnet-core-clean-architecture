using api_csharp.Application.Services;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class RemoveTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;
        private readonly TodoTaskService _todoTaskService;

        public RemoveTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService,
            TodoTaskService todoTaskService)
        {
            _repository = repository;
            _userService = userService;
            _todoTaskService = todoTaskService;
        }

        public async Task<String> Execute(int userId, int id)
        {
            await _userService.AsyncGetUser(userId);
            var todoTask = await _todoTaskService.AsyncGetTodoTask(userId, id);

            await _repository.Remove(userId, id);
            return "Tarefa deletada !";
        }
    }
}
