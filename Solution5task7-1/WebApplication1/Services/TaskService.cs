using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private IMapper _mapper;
        public TaskService(ITaskRepository taskRepository,IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<TaskItemDto> Create(CreateTaskRequest taskrequest)
        {
            if (await _taskRepository.ExistsByTitle(taskrequest.Title))
                throw new ConflictException("A task with this title already exists.");

            var task = _mapper.Map<TaskItem>(taskrequest);
            var created = await _taskRepository.Create(task);

            return _mapper.Map<TaskItemDto>(created);
        }

        public async Task<bool> Delete(int id)
        {
            var deleted = await _taskRepository.Delete(id);
            if (!deleted)
                throw new NotFoundException($"TASK {id} not found");
            return true;
        }

        public async Task<TaskItemDto> GetById(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
                throw new NotFoundException($"TASK {id} not found");
            var x = _mapper.Map<TaskItemDto>(task);
            return x;
        }
        public async Task<TaskItemDto> Update(int id, UpdateTaskRequest updatedTask)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
                throw new NotFoundException($"TASK {id} not found");
            var z = _mapper.Map<TaskItemDto>(task);
            return z;
        }

        public async Task<PagedResult<TaskItemDto>> GetAll(TaskFilterParams filters)
        {
            var result = await _taskRepository.GetAll(filters);
            return _mapper.Map<PagedResult<TaskItemDto>>(result);


        }
    }

}
