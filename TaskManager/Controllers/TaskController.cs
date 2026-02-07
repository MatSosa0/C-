using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            var task = new TaskItem
            {
                Id = 1,
                Title = "Tarea cambiada",
                Descripcion = "Probando flujo controller + View",
                CreatedAd = DateTime.Now,
                IsCompleted = true
            
            };

            return View(task);
        }
    }
}