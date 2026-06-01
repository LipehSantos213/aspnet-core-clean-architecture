using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;
using api_csharp.Infrastructure.Data.Context;

namespace api_csharp.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly AppDbContext _context;

        public TodoTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoTask> Create(TodoTask task)
        {
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
