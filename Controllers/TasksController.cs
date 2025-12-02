using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Models;
using TaskManagerBackend.Services;

namespace TaskManagerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll()
    {
        return Ok(_taskService.GetAll());
    }

    [HttpPost]
    public ActionResult<TaskItem> Create([FromBody] CreateTaskRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Title is required.");
        }

        var task = _taskService.Add(request.Title);
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStatus(int id, [FromBody] UpdateTaskRequest request)
    {
        var success = _taskService.UpdateStatus(id, request.Completed);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}

public class CreateTaskRequest
{
    public string Title { get; set; } = string.Empty;
}

public class UpdateTaskRequest
{
    public bool Completed { get; set; }
}
