namespace ToDoApp.Data
{

    using Microsoft.EntityFrameworkCore;

    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options) { }

        public DbSet<TaskItemModel> TaskItems { get; set; } = null!;
    }

}