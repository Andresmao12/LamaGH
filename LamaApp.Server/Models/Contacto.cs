using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public int Direccion { get; set; }

    public string Correo { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
