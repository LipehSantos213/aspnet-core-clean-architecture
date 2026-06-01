using api_csharp.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class RemoveTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;

        public RemoveTodoTaskUseCase(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<String> Execute(int userId, int id)
        {
            await _repository.Remove(userId, id);
            return "Tarefa deletada !";
        }
    }
}
