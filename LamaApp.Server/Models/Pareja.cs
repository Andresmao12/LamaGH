using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Pareja
{
    public int IdPareja { get; set; }

    public int Nombre { get; set; }

    public string Cedula { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
