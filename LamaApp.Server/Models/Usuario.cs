using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int IdContacto { get; set; }

    public int IdPareja { get; set; }

    public int IdCapitulo { get; set; }

    public int IdMotocicleta { get; set; }

    public virtual Capitulo IdCapituloNavigation { get; set; } = null!;

    public virtual Motocicleta IdUsuario1 { get; set; } = null!;

    public virtual Pareja IdUsuario2 { get; set; } = null!;

    public virtual Contacto IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
