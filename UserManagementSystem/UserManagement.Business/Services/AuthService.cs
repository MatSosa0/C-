using System.Threading.Tasks;
using UserManagement.Business.DTOs;
using UserManagement.Data.Repositories;
using BCrypt.Net;

namespace UserManagement.Business.Services
{
    public interface IAuthService
    {
        Task<bool> ValidarCredencialesAsync(LoginDTO loginDto);
    }

    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> ValidarCredencialesAsync(LoginDTO loginDto)
        {
            var usuario = await _usuarioRepository.ObtenerPorNombreUsuarioAsync(loginDto.NombreUsuario);
            
            if (usuario == null || !usuario.Estatus)
                return false;

            return BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.Password);
        }
    }
}