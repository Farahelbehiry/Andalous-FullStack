using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<PagedResult<TaskItemDto>> GetAll(TaskFilterParams filters);
        public Task<TaskItemDto> GetById(int id);
        public Task<TaskItemDto>Create(CreateTaskRequest task);
        public Task<TaskItemDto> Update(int id, UpdateTaskRequest updatedTask);
        public Task<bool> Delete(int id);
    }
}
