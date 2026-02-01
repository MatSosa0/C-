using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
        Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, int? idExcluir = null);
        Task<Usuario> CrearAsync(Usuario usuario);
        Task<Usuario> ActualizarAsync(Usuario usuario);
        Task<bool> EliminarAsync(int id);
        Task<Dictionary<string, int>> ObtenerEstadisticasAsync();
    }
}