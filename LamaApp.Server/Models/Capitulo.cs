using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Capitulo
{
    public int IdCapitulo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
