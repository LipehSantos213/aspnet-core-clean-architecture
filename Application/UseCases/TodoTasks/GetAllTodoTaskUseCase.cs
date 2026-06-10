using api_csharp.Application.DTOs;
using api_csharp.Application.Services;
using api_csharp.Domain.Entities;
using api_csharp.Domain.Exception;
using api_csharp.Domain.Interfaces;

namespace api_csharp.Application.UseCases.TodoTasks
{
    public class GetAllTodoTaskUseCase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly UserService _userService;

        public GetAllTodoTaskUseCase(
            ITodoTaskRepository repository,
            UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<List<TodoTaskResponseDTO>> Execute(int userId)
        {
            await _userService.AsyncGetUser(userId);

            List<TodoTask>? todoTasks = await _repository.GetAll(userId) ??
                throw new DomainException("Nenhuma tarefa encontrada !");

            if(todoTasks.Count == 0)
            {
                throw new DomainException("Nenhuma tarefa encontrada !");
            }

            List<TodoTaskResponseDTO> response = [];

            foreach (TodoTask item in todoTasks)
            {
                response.Add(new TodoTaskResponseDTO(item.Id, item.Title, item.Description, item.Active));
            }

            return response;
        }
    }
}
