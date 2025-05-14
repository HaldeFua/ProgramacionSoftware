namespace ToDoApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ToDoApp.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ToDoApp.Data;

    public class TaskItemController : Controller
    {
        private readonly ITaskItemServices _taskItemServices;

        public TaskItemController(ITaskItemServices taskItemServices)
        {
            _taskItemServices = taskItemServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }


    }
}