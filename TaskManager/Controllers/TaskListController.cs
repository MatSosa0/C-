using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Data;
namespace TaskManager.Controllers
{
    public class TaskListController : Controller
    {
        private readonly AppDbContext _context;
        public TaskListController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }
    }
}