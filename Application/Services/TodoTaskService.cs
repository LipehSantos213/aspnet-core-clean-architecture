using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.Services
{
    public class TodoTaskService
    {
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> AsyncGetTodoTask(int userId, int id)
        {
            TodoTask task = await _repository.Get(userId, id) ??
                throw new DomainException("Tarefa não encontrada !");
            return task;
        }
    }
}
