using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/tasks")]
    public class TasksV2Controller:ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksV2Controller(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery] TaskFilterParams filters)
        {
            var result = _taskService.GetAll(filters);

            var reshaped = new
            {
                data = result.Data.Select(t => new
                {
                    id = t.Id,
                    title = t.Title,
                    status = t.IsCompleted ? "completed" : "pending",
                    dueDate = (DateTime?)null,
                    createdAt = t.CreatedAt
                }),
               
            };

            return Ok(reshaped);
        }


    }
}
