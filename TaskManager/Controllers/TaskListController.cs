using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskListController : Controller
    {
        public IActionResult Index()
        {
            var model = new TaskListItem
            {
                Tasks = new List<TaskItem>
                {
                    new TaskItem
                    {
                        Id = 1,
                        Title = "Tarea cambiada",
                        Descripcion = "Probando flujo controller + View",
                        CreatedAd = DateTime.Now,
                        IsCompleted = true
                    },
                    new TaskItem
                    {
                        Id = 2,
                        Title = "Segundo elemento de la lista",
                        Descripcion = "Probando flujo controller + View",
                        CreatedAd = DateTime.Now,
                        IsCompleted = true 
                    }
                }
                
            
            };

            return View(model);
        }
    }
}