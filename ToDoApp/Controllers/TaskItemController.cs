namespace ToDoApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ToDoApp.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ToDoApp.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemServices _taskItemServices;

        public TaskItemController(ITaskItemServices taskItemServices)
        {
            _taskItemServices = taskItemServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTaskItems()
        {
            var taskItems = await _taskItemServices.GetAllTaskItemsAsync();
            return Ok(taskItems);
        }
    }
}