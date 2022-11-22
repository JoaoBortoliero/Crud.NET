using Crud.NET.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.NET.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}