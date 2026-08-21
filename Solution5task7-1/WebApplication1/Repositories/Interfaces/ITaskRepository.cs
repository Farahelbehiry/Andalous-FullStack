using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<PagedResult<TaskItem>> GetAll(TaskFilterParams filters);
        public Task<TaskItem?> GetById(int id);
        public Task<TaskItem> Create(TaskItem task);
        public Task<TaskItem> Update(int id, TaskItem updatedTask);
        public Task<bool> Delete(int id);

        public Task<bool> ExistsByTitle(string title);
    }
}
