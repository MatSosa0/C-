using Microsoft.AspNetCore.Mvc;
using UserManagement.Business.Services;

namespace UserManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public DashboardController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            // Verificar autenticación
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var dashboardData = await _usuarioService.ObtenerDatosdashboard();
            return View(dashboardData);
        }
    }
}