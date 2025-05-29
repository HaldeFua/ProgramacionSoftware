namespace ToDoApp.Repository;

using ToDoApp.Data;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskItemRepository
{
    Task<List<TaskItem>> GetAllTaskItemsAsync();
    Task<TaskItem> GetTaskItemByIdAsync(int id);
    Task UpdateTaskItemAsync(TaskItem taskItem);
    Task AddTaskItemAsync(TaskItem taskItem);
    Task DeleteTaskItemAsync(int id);

}

public class TaskItemRepository : ITaskItemRepository
{
    private readonly ToDoAppContext _context;

    public TaskItemRepository(ToDoAppContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllTaskItemsAsync()
    {
        return await _context.TaskItems.ToListAsync();
    }

    public async Task<TaskItem> GetTaskItemByIdAsync(int id)
    {
        return await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateTaskItemAsync(TaskItem taskItem)
    {
        _context.TaskItems.Update(taskItem);
        await _context.SaveChangesAsync();
    }

    public async Task AddTaskItemAsync(TaskItem taskItem)
    {
        await _context.TaskItems.AddAsync(taskItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskItemAsync(int id)
    {
        var taskItem = await GetTaskItemByIdAsync(id);
        if (taskItem != null)
        {
            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
        }
    }
}
