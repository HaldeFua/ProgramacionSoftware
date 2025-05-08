namespace ToDoApp.Data
{

    using Microsoft.EntityFrameworkCore;

    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
    }

}