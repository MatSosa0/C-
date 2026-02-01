using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Data.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public bool Estatus { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}