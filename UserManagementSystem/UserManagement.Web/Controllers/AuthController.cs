using Microsoft.AspNetCore.Mvc;
using UserManagement.Business.DTOs;
using UserManagement.Business.Services;
using BCrypt.Net;  // <-- Agregar este using

namespace UserManagement.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var esValido = await _authService.ValidarCredencialesAsync(loginDto);

            if (esValido)
            {
                HttpContext.Session.SetString("Usuario", loginDto.NombreUsuario);
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View(loginDto);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}