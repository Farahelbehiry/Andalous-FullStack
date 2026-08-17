using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class TaskRepository:ITaskRepository
    {
        private static readonly List<TaskItem> _tasks = new();
        public TaskItem Create(TaskItem task)
        {
            _tasks.Add(task);
            return task;
        }

        public bool Delete(int id)
        {
            var task = GetById(id);
            if (task == null)
                return false;

            _tasks.Remove(task);
            return true;
        }

        public TaskItem GetById(int id)
        {
            return _tasks.FirstOrDefault(p => p.Id == id);
        }
        public TaskItem Update(int id, TaskItem updatedTask)
        {
            var task = GetById(id);
            if (task == null)
                return null;

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;
            return task;
        }
        public PagedResult<TaskItem> GetAll(TaskFilterParams filters)
        {
            var tasks = _tasks.AsEnumerable();

            if (!string.IsNullOrEmpty(filters.Search))
            {
                tasks = tasks.Where(t => t.Title.Contains(filters.Search, StringComparison.OrdinalIgnoreCase));
            }
            if (filters.IsCompleted.HasValue)
            {
                tasks = tasks.Where(t => t.IsCompleted == filters.IsCompleted);
            }
            int totalCount = tasks.Count();
            var allowedSort = new Dictionary<string, Func<TaskItem, object>>
            {
                ["title"] = t => t.Title,
                ["createdAt"] = t => t.CreatedAt,
                ["isCompleted"] = t => t.IsCompleted
            };

            if (allowedSort.TryGetValue(
                filters.SortBy != null ? filters.SortBy : "createdAt", out var keySelector))
            {
                tasks = filters.Order == "desc"
                    ? tasks.OrderByDescending(keySelector)
                    : tasks.OrderBy(keySelector);
            }
            tasks = tasks.OrderBy(allowedSort["createdAt"]);
            var data = tasks.Skip((filters.Page - 1) * filters.PageSize).Take(filters.PageSize).ToList();



            return new PagedResult<TaskItem>
            {
                Data = data,
                Page = filters.Page,
                PageSize = filters.PageSize,
                TotalCount = totalCount
            };
        }

        }
}
