using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ITaskService
    {
        public PagedResult<TaskItem> GetAll(TaskFilterParams filters);
        public TaskItem GetById(int id);
        public TaskItem Create(TaskItem task);
        public TaskItem Update(int id, TaskItem updatedTask);
        public bool Delete(int id);
    }
}
