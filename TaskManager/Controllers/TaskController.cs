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
                Title = "Mi primera Tarea",
                Descripcion = "Aprender ASP.NET Core MVC",
                IsCompleted = false
            };
            return View(task);
        }
    }
}