using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Context;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios
                .OrderByDescending(u => u.FechaAlta)
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }
        public async Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, int? idExcluir = null)
        {
            if (idExcluir.HasValue)
            {
                return await _context.Usuarios
                    .AnyAsync(u => u.NombreUsuario == nombreUsuario && u.Id != idExcluir.Value);
            }

            return await _context.Usuarios
                .AnyAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<Usuario> CrearAsync(Usuario usuario)
        {
            usuario.FechaAlta = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ActualizarAsync(Usuario usuario)
        {
            usuario.FechaModificacion = DateTime.Now;
            _context.Entry(usuario).State = EntityState.Modified;
            _context.Entry(usuario).Property(u => u.FechaAlta).IsModified = false;
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, int>> ObtenerEstadisticasAsync()
        {
            var totalUsuarios = await _context.Usuarios.CountAsync();
            var usuariosActivos = await _context.Usuarios.CountAsync(u => u.Estatus);
            var usuariosInactivos = await _context.Usuarios.CountAsync(u => !u.Estatus);
            var usuariosHoy = await _context.Usuarios
                .CountAsync(u => u.FechaAlta.Date == DateTime.Today);

            return new Dictionary<string, int>
            {
                { "TotalUsuarios", totalUsuarios },
                { "UsuariosActivos", usuariosActivos },
                { "UsuariosInactivos", usuariosInactivos },
                { "UsuariosHoy", usuariosHoy }
            };
        }
    }
}