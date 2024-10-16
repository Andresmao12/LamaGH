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

    // Relaciones corregidas
    public virtual Capitulo Capitulo { get; set; } = null!;
    public virtual Motocicleta Motocicleta { get; set; } = null!;
    public virtual Pareja Pareja { get; set; } = null!;
    public virtual Contacto Contacto { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();
}