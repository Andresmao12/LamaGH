using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Publicacione
{
    public int IdPublicacion { get; set; }

    public DateTime Fecha { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
