using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Business.DTOs;
using UserManagement.Data.Entities;
using UserManagement.Data.Repositories;
using BCrypt.Net;

namespace UserManagement.Business.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerTodosAsync();
        Task<UsuarioDTO> ObtenerPorIdAsync(int id);
        Task<(bool exito, string mensaje, UsuarioDTO usuario)> CrearAsync(UsuarioDTO usuarioDto);
        Task<(bool exito, string mensaje, UsuarioDTO usuario)> ActualizarAsync(UsuarioDTO usuarioDto);
        Task<(bool exito, string mensaje)> EliminarAsync(int id);
        Task<DashboardDTO> ObtenerDatosdashboard();
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerTodosAsync()
        {
            var usuarios = await _usuarioRepository.ObtenerTodosAsync();
            return usuarios.Select(u => MapearADTO(u));
        }

        public async Task<UsuarioDTO> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            return usuario != null ? MapearADTO(usuario) : null;
        }

        public async Task<(bool exito, string mensaje, UsuarioDTO usuario)> CrearAsync(UsuarioDTO usuarioDto)
        {
            // Validar si el nombre de usuario ya existe
            if (await _usuarioRepository.ExisteNombreUsuarioAsync(usuarioDto.NombreUsuario))
            {
                return (false, "El nombre de usuario ya existe", null);
            }

            var usuario = new Usuario
            {
                NombreCompleto = usuarioDto.NombreCompleto,
                NombreUsuario = usuarioDto.NombreUsuario,
                Password = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password),
                Correo = usuarioDto.Correo,
                Estatus = usuarioDto.Estatus,
                FechaAlta = DateTime.Now
            };

            var usuarioCreado = await _usuarioRepository.CrearAsync(usuario);
            return (true, "Usuario creado exitosamente", MapearADTO(usuarioCreado));
        }

        public async Task<(bool exito, string mensaje, UsuarioDTO usuario)> ActualizarAsync(UsuarioDTO usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.ObtenerPorIdAsync(usuarioDto.Id);
            if (usuarioExistente == null)
            {
                return (false, "Usuario no encontrado", null);
            }

            // Validar si el nombre de usuario ya existe (excluyendo el usuario actual)
            if (await _usuarioRepository.ExisteNombreUsuarioAsync(usuarioDto.NombreUsuario, usuarioDto.Id))
            {
                return (false, "El nombre de usuario ya existe", null);
            }

            usuarioExistente.NombreCompleto = usuarioDto.NombreCompleto;
            usuarioExistente.NombreUsuario = usuarioDto.NombreUsuario;
            
            // Solo actualizar la contraseña si se proporciona una nueva
            if (!string.IsNullOrEmpty(usuarioDto.Password))
            {
                usuarioExistente.Password = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);
            }

            usuarioExistente.Correo = usuarioDto.Correo;
            usuarioExistente.Estatus = usuarioDto.Estatus;

            var usuarioActualizado = await _usuarioRepository.ActualizarAsync(usuarioExistente);
            return (true, "Usuario actualizado exitosamente", MapearADTO(usuarioActualizado));
        }

        public async Task<(bool exito, string mensaje)> EliminarAsync(int id)
        {
            var resultado = await _usuarioRepository.EliminarAsync(id);
            return resultado 
                ? (true, "Usuario eliminado exitosamente") 
                : (false, "No se pudo eliminar el usuario");
        }

        public async Task<DashboardDTO> ObtenerDatosdashboard()
        {
            var estadisticas = await _usuarioRepository.ObtenerEstadisticasAsync();
            var todosUsuarios = await _usuarioRepository.ObtenerTodosAsync();

            var usuariosRecientes = todosUsuarios
                .OrderByDescending(u => u.FechaAlta)
                .Take(5)
                .Select(u => new UsuarioRecienteDTO
                {
                    NombreCompleto = u.NombreCompleto,
                    NombreUsuario = u.NombreUsuario,
                    FechaAlta = u.FechaAlta,
                    Estatus = u.Estatus
                })
                .ToList();

            return new DashboardDTO
            {
                TotalUsuarios = estadisticas["TotalUsuarios"],
                UsuariosActivos = estadisticas["UsuariosActivos"],
                UsuariosInactivos = estadisticas["UsuariosInactivos"],
                UsuariosHoy = estadisticas["UsuariosHoy"],
                UsuariosRecientes = usuariosRecientes
            };
        }

        private UsuarioDTO MapearADTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                NombreUsuario = usuario.NombreUsuario,
                Correo = usuario.Correo,
                Estatus = usuario.Estatus,
                FechaAlta = usuario.FechaAlta,
                FechaModificacion = usuario.FechaModificacion
            };
        }
    }
}