using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.NombreUsuario).IsUnique();
                entity.Property(e => e.Estatus).HasDefaultValue(true);
                entity.Property(e => e.FechaAlta).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}