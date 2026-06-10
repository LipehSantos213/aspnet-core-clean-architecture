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
            var todoTask = await _repository.Get(userId, id) ?? 
                throw new DomainException("Tarefa não encontrada !");

            await _repository.Remove(userId, id);
            return "Tarefa deletada !";
        }
    }
}
