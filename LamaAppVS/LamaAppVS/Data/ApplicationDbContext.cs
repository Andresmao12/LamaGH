//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace LamaAppVS.Data
//{
//    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
//    {
//    }
//}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LamaAppVS.Shared.Models;

namespace LamaAppVS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Se definen DbSet para cada entidad que se van a manejar en el CRUD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Inscripcion> Inscripcions { get; set; }
        public DbSet<Motocicleta> Motocicletas { get; set; }
        public DbSet<Publicacion> Publicacions { get; set; }
    }

}
