using Crud.NET.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.NET.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<Usuario> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}