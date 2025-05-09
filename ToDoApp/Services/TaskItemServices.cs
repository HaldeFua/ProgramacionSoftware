namespace ToDoApp.Services;

using ToDoApp.Models;
using ToDoApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;

public interface ITaskItemServices
{
    Task<List<TaskItem>> GetAllTaskItemsAsync();
}

public class TaskItemServices : ITaskItemServices
{
    private readonly ITaskItemRepository _taskItemRepository;

    public TaskItemServices(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<List<TaskItem>> GetAllTaskItemsAsync()
    {
        return await _taskItemRepository.GetAllTaskItemsAsync();
    }
}