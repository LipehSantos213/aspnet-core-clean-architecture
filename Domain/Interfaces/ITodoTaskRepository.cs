using api_csharp.Domain.Entities;
using System.Runtime.CompilerServices;

namespace api_csharp.Domain.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<TodoTask> Create(TodoTask task);

        Task<List<TodoTask>?> GetAll(int userId);

        Task<TodoTask> Update(TodoTask task);

        Task<TodoTask?> Get(int userId,int id);

        Task Remove(TodoTask todoTask);
    }
}
