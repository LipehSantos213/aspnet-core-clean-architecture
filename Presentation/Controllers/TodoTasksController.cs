using api_csharp.Application.DTOs;
using api_csharp.Application.UseCases.TodoTasks;
using Microsoft.AspNetCore.Mvc;

namespace api_csharp.Presentation.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/tasks")]
    public class TodoTasksController : ControllerBase
    {
        private readonly CreateTodoTaskUseCase _createTodoTaskUseCase;
        private readonly UpdateTodoTaskUseCase _updateTodoTaskUseCase;
        private readonly GetAllTodoTaskUseCase _getAllTodoTaskUseCase;
        private readonly GetTodoTaskUseCase _getTodoTaskUseCase;
        private readonly RemoveTodoTaskUseCase _removeTodoTaskUseCase;
        private readonly UpdateStatusTodoTaskUseCase _updateStatusTodoTaskUseCase;

        public TodoTasksController(
            CreateTodoTaskUseCase createTodoTaskUseCase,
            UpdateTodoTaskUseCase updateTodoTaskUseCase,
            GetAllTodoTaskUseCase getAllTodoTaskUseCase,
            GetTodoTaskUseCase getTodoTaskUseCase,
            RemoveTodoTaskUseCase removeTodoTaskUseCase,
            UpdateStatusTodoTaskUseCase updateStatusTodoTaskUseCase
            )
        {
            _createTodoTaskUseCase = createTodoTaskUseCase;
            _updateTodoTaskUseCase = updateTodoTaskUseCase;
            _getAllTodoTaskUseCase = getAllTodoTaskUseCase;
            _getTodoTaskUseCase = getTodoTaskUseCase;
            _removeTodoTaskUseCase = removeTodoTaskUseCase;
            _updateStatusTodoTaskUseCase = updateStatusTodoTaskUseCase;
        }

        [HttpPost] // Rota: POST api/users/{userId}/tasks
        public async Task<IActionResult> Create([FromRoute] int userId, [FromBody] TodoTaskCreateDTO dto)
        {
                var task = await _createTodoTaskUseCase.Execute(userId, dto);
                return Ok(new { task });
        }

        [HttpPut] // Rota: PUT api/users/{userId}/tasks
        public async Task<IActionResult> Uptate([FromRoute] int userId, [FromBody] TodoTaskUpdateDTO dto)
        {
                var task = await _updateTodoTaskUseCase.Execute(userId, dto);
                return Ok(new { task });
        }

        [HttpPatch("{id:int}/active")]
        public async Task<IActionResult> Active([FromRoute] int userId, [FromRoute] int id)
        {
            var task = await _updateStatusTodoTaskUseCase.Execute(userId, id, true);
            return Ok(new {task});
        }

        [HttpPatch("{id:int}/disable")]
        public async Task<IActionResult> Disable([FromRoute] int userId, [FromRoute] int id)
        {
            var task = await _updateStatusTodoTaskUseCase.Execute(userId, id, false);
            return Ok(new { task });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int userId)
        {
                var tasks = await _getAllTodoTaskUseCase.Execute(userId);
                return Ok(new { tasks });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int userId, [FromRoute] int id)
        {
                var task = await _getTodoTaskUseCase.Execute(userId, id);
                return Ok(new { task });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int userId, [FromRoute] int id)
        {
                string message = await _removeTodoTaskUseCase.Execute(userId, id);
                return Ok(new { message });
        }
    }
}
