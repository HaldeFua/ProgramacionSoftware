namespace ToDoApp.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using ToDoApp.Data;

    public class TaskItemCreate
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    }

}