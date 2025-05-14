using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Repository;
using ToDoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Tomamos el string de conexión de la configuración
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add Entity Framework Core with SQL Server
builder.Services.AddDbContext<ToDoAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskItemServices, TaskItemServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskItem}/{action=Index}/{id?}");


app.Run();
