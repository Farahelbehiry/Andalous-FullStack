using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/tasks")]

    public class TasksController:ControllerBase
    {
        private ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] TaskFilterParams filters)
        {
            return Ok(await _taskService.GetAll(filters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _taskService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskRequest taskrequest)
        {
            var created =await _taskService.Create(taskrequest);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskRequest updatedTask)
        {
            var updated =await  _taskService.Update(id, updatedTask);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.Delete(id);
            return NoContent();
        }
    }
}
