namespace ToDoApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ToDoApp.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ToDoApp.Data;
    using ToDoApp.Mapper;
    using AutoMapper;
    using ToDoApp.DTOs;

    public class TaskItemController : Controller
    {
        private readonly ITaskItemServices _taskItemServices;
        private readonly IMapper _mapper;

        public TaskItemController(ITaskItemServices taskItemServices, IMapper mapper)
        {
            _taskItemServices = taskItemServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var taskItems = await _taskItemServices.GetAllTaskItemsAsync();
            var taskItemsDTOs = _mapper.Map<List<TaskItemDetail>>(taskItems);
            return View(taskItemsDTOs);
        }

        //GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }



    }
}