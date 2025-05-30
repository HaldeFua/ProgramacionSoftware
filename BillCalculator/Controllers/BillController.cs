using Microsoft.AspNetCore.Mvc;
using BillCalculator.Models;

namespace BillCalculator.Controllers
{
    public class BillController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Bill model)
        {
            if (ModelState.IsValid)
            {
                return View(model); // Devuelve el modelo con los resultados calculados
            }

            return View();
        }
    }
}
