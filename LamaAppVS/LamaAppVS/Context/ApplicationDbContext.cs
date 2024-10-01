using LamaAppVS.Models;
using Microsoft.EntityFrameworkCore;

namespace LamaAppVS.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Motocicleta> Motocicletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones uno a muchos
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Motocicletas)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.ID_Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Inscripciones)
                .WithOne(i => i.Usuario)
                .HasForeignKey(i => i.ID_Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Publicaciones)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.ID_Usuario);

            modelBuilder.Entity<Capitulo>()
                .HasMany(c => c.Usuarios)
                .WithOne(u => u.Capitulo)
                .HasForeignKey(u => u.ID_Capitulo);

            modelBuilder.Entity<Capitulo>()
                .HasMany(c => c.Eventos)
                .WithOne(e => e.Capitulo)
                .HasForeignKey(e => e.ID_Capitulo);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Inscripciones)
                .WithOne(i => i.Evento)
                .HasForeignKey(i => i.ID_Evento);
        }
    }
}
