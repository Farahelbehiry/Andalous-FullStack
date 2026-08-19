using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetAll([FromQuery] TaskFilterParams filters)
        {
            return Ok(_taskService.GetAll(filters));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_taskService.GetById(id));
        }

        [HttpPost]
        public ActionResult Create(TaskItem task)
        {
            var created = _taskService.Create(task);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var updated = _taskService.Update(id, updatedTask);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return NoContent();
        }


    }
}
