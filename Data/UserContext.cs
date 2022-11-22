using Crud.NET.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.NET.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<User>();
            usuario.ToTable("user");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Name).HasColumnName("name").IsRequired();
            usuario.Property(x => x.BirthDate).HasColumnName("birth_date");
        }
    }
}