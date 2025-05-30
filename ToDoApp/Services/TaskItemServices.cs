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
    Task<bool> UpdateTaskCompletionAsync(int id, bool isCompleted);
    Task<bool> CreateTaskItemAsync(TaskItem taskItem);
    Task<TaskItem> GetTaskItemByIdAsync(int id);
    Task<bool> DeleteTaskItemAsync(int id);
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

    public async Task<bool> UpdateTaskCompletionAsync(int id, bool isCompleted)
    {
        var task = await _taskItemRepository.GetTaskItemByIdAsync(id);
        if (task == null)
            return false;

        task.IsCompleted = isCompleted;
        await _taskItemRepository.UpdateTaskItemAsync(task);
        return true;
    }

    public async Task<bool> CreateTaskItemAsync(TaskItem taskItem)
    {
        if (taskItem == null)
            return false;

        await _taskItemRepository.AddTaskItemAsync(taskItem);
        return true;
    }

    public async Task<TaskItem> GetTaskItemByIdAsync(int id)
    {
        return await _taskItemRepository.GetTaskItemByIdAsync(id);
    }

    public async Task<bool> DeleteTaskItemAsync(int id)
    {
        var taskItem = await _taskItemRepository.GetTaskItemByIdAsync(id);
        if (taskItem == null)
            return false;

        await _taskItemRepository.DeleteTaskItemAsync(id);
        return true;
    }

}