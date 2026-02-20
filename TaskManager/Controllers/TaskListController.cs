using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Data;
using System.Security.Cryptography.X509Certificates;
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

        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }
    }
}