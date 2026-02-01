using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Business.DTOs
{
    // DTO para Login
    public class LoginDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; } = string.Empty;
    }

    // DTO para Usuario
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        [StringLength(200, ErrorMessage = "El nombre completo no puede exceder 200 caracteres")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de usuario no puede exceder 100 caracteres")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(9, ErrorMessage = "La contraseña debe tener al menos 9 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{9,}$",
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estatus es requerido")]
        public bool Estatus { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // DTO para Dashboard
    public class DashboardDTO
    {
        public int TotalUsuarios { get; set; }
        public int UsuariosActivos { get; set; }
        public int UsuariosInactivos { get; set; }
        public int UsuariosHoy { get; set; }
        public List<UsuarioRecienteDTO> UsuariosRecientes { get; set; } = new List<UsuarioRecienteDTO>();
    }

    public class UsuarioRecienteDTO
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public bool Estatus { get; set; }
    }
}