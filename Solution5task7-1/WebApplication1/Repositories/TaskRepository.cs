using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Repositories
{
    public class TaskRepository:ITaskRepository
    {
        // private static readonly List<TaskItem> _tasks = new();
        private readonly AppDbContext _dbcontext;

        public TaskRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<TaskItem> Create(TaskItem task)
        {
            _dbcontext.TaskItem.Add(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await GetById(id);
            if (task == null)
                return false;

            _dbcontext.TaskItem.Remove(task);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<TaskItem?>GetById(int id)
        {
            //return _tasks.FirstOrDefault(p => p.Id == id);
            //var task = await _dbcontext.TaskItem.FindAsync(id);
           // return task;

            var query = _dbcontext.TaskItem.AsQueryable();
            query = query.Include(t=>t.User).Where(t=>t.Id == id);
            var task = await query.FirstOrDefaultAsync();
            return task;
            
        }
        public async Task<TaskItem?> Update(int id, TaskItem updatedTask)
        {
            var task = await _dbcontext.TaskItem.FindAsync(id);
            if (task == null)
                return null;

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;

            await _dbcontext.SaveChangesAsync();
            return task;
        }
        public async Task<PagedResult<TaskItem>> GetAll(TaskFilterParams filters)
        {
            var query = _dbcontext.TaskItem.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Search))
            {
                // query = query.Where(t => t.Title.Contains(filters.Search, StringComparison.OrdinalIgnoreCase));
                query = query.Where(t =>EF.Functions.Like(t.Title, $"%{filters.Search}%"));
            }
            if (filters.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == filters.IsCompleted.Value);
            }
            int totalCount = await query.CountAsync();


            var data = await query.OrderByDescending(t => t.CreatedAt).Skip((filters.Page - 1) * filters.PageSize).Take(filters.PageSize).ToListAsync();

            return new PagedResult<TaskItem>
            {
                Data = data,
                Page = filters.Page,
                PageSize = filters.PageSize,
                TotalCount = totalCount
            };
        }
        public async Task<bool> ExistsByTitle(string title)
        {

            return await _dbcontext.TaskItem.AnyAsync(t => t.Title == title);
        }
    }



    /*
     * 
     *  var allowedSort = new Dictionary<string, Func<TaskItem, object>>
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
     */
}
