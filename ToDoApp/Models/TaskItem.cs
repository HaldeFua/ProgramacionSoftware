using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }

    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
}

public enum TaskPriority
{
    [Display(Name = "Baja")]
    Low,

    [Display(Name = "Media")]
    Medium,

    [Display(Name = "Alta")]
    High
}
