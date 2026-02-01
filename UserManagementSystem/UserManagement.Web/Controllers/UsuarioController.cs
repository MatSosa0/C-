using Microsoft.AspNetCore.Mvc;
using UserManagement.Business.DTOs;
using UserManagement.Business.Services;

namespace UserManagement.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            // Verificar autenticación
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var usuarios = await _usuarioService.ObtenerTodosAsync();
            return View(usuarios);
        }

        // GET: Usuario/Obtener/5
        [HttpGet]
        public async Task<IActionResult> Obtener(int id)
        {
            var usuario = await _usuarioService.ObtenerPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Json(usuario);
        }

        // POST: Usuario/Crear
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioDTO usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { 
                    exito = false, 
                    mensaje = "Datos inválidos",
                    errores = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var resultado = await _usuarioService.CrearAsync(usuarioDto);
            return Json(new { 
                exito = resultado.exito, 
                mensaje = resultado.mensaje,
                usuario = resultado.usuario
            });
        }

        // POST: Usuario/Actualizar
        [HttpPost]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioDTO usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { 
                    exito = false, 
                    mensaje = "Datos inválidos",
                    errores = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var resultado = await _usuarioService.ActualizarAsync(usuarioDto);
            return Json(new { 
                exito = resultado.exito, 
                mensaje = resultado.mensaje,
                usuario = resultado.usuario
            });
        }

        // POST: Usuario/Eliminar/5
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _usuarioService.EliminarAsync(id);
            return Json(new { 
                exito = resultado.exito, 
                mensaje = resultado.mensaje 
            });
        }
    }
}