namespace ToDoApp.DTOs
{
    using System.ComponentModel.DataAnnotations;
    public class TaskItemCreate
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Title { get; set; } = string.Empty;

    }

}