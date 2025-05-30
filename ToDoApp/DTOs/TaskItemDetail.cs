using ToDoApp.Data;

namespace ToDoApp.DTOs
{
    public class TaskItemDetail
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}