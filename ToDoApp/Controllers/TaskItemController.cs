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

        [HttpPost]
        public async Task<IActionResult> UpdateCompletion(int id, bool completed)
        {
            bool updated = await _taskItemServices.UpdateTaskCompletionAsync(id, completed);
            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemCreate dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // vuelve a la vista con los errores de validación
            }

            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                CreatedAt = DateTime.Now,
                IsCompleted = false
            };

            await _taskItemServices.CreateTaskItemAsync(task);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _taskItemServices.DeleteTaskItemAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}