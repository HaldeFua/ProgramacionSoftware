using Microsoft.AspNetCore.Mvc;
using Chronometer.Models;

namespace Chronometer.Controllers
{
    public class StopwatchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new StopWatch();
            return View(model);
        }
    }
}