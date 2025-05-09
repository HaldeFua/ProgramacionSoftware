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

}
