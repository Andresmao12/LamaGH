using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Evento
{
    public int IdEvento { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string Creador { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int IdCapitulo { get; set; }

    public virtual Capitulo IdCapituloNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
