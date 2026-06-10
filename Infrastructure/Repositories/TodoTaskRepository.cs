using api_csharp.Domain.Entities;
using api_csharp.Domain.Interfaces;
using api_csharp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

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
            await _context.TodoTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
    
        public async Task<List<TodoTask>?> GetAll(int userId)
        {
            List<TodoTask>? tasks = await _context.TodoTasks
                .Where(i=> i.UserId == userId).ToListAsync();

            return tasks;
        }
    
        public async Task<TodoTask> Update(TodoTask task)
        {
            await _context.TodoTasks.Where(i => i.UserId == task.UserId)
                .ExecuteUpdateAsync(s=> s
                .SetProperty(t=> t.Title, task.Title)
                .SetProperty(t=> t.Description, task.Description)
                );
            //_context.TodoTasks.Update(task);
            //await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TodoTask?> Get(int userId, int id)
        {
            TodoTask? task = await _context.TodoTasks.FirstOrDefaultAsync(i=> i.Id == id && i.UserId == userId);
            return task;
        }
    
        public async Task Remove(TodoTask todoTask)
        {
            _context.TodoTasks.Remove(todoTask);
            await _context.SaveChangesAsync();
        }
    }
}
