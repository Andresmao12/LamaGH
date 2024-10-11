using System;
using System.Collections.Generic;

namespace LamaApp.Server.Models;

public partial class Motocicleta
{
    public int IdMotocicleta { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Cilindrada { get; set; }

    public string Placa { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
