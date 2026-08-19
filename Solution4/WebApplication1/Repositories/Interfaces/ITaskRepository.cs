using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public PagedResult<TaskItem> GetAll(TaskFilterParams filters);
        public TaskItem GetById(int id);
        public TaskItem Create(TaskItem task);
        public TaskItem Update(int id, TaskItem updatedTask);
        public bool Delete(int id);
    }
}
