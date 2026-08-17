using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class TaskService:ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public TaskItem Create(TaskItem task)
        {
            bool titleExists = false;
            foreach (var t in _taskRepository.GetAll(new TaskFilterParams { PageSize = int.MaxValue }).Data)
            {
                if (t.Title == task.Title)
                {
                    titleExists = true;
                    break;
                }
            }
            if (titleExists)
                throw new ConflictException("alreadu exists");

            return _taskRepository.Create(task);
        }

        public bool Delete(int id)
        {
            var deleted = _taskRepository.Delete(id);
            if (!deleted)
                throw new NotFoundException($"TASK {id} not found");
            return true;
        }

        public TaskItem GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
                throw new NotFoundException($"TASK {id} not found");
            return task;
        }
        public TaskItem Update(int id, TaskItem updatedTask)
        {
            var task = _taskRepository.Update(id, updatedTask);
            if (task == null)
                throw new NotFoundException($"TASK {id} not found");
            return task;
        }

        public PagedResult<TaskItem> GetAll(TaskFilterParams filters)
        {
            return _taskRepository.GetAll(filters);
        }
    }

}
