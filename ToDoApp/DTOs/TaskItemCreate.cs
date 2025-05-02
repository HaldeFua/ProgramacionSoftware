namespace ToDoApp.DTOs
{
    using System.ComponentModel.DataAnnotations;
    public class TaskItemCreate
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;

    }

}