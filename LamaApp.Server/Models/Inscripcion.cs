using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Inscripcion
{
    public int IdInscripcion { get; set; }

    public DateTime FechaCompra { get; set; }

    public int IdEvento { get; set; }

    public int IdUsuario { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
