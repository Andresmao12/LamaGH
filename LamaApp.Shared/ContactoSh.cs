using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaApp.Shared
{
    public class ContactoSh
    {
        public int IdContacto { get; set; }

        public string Direccion { get; set; }

        public string Correo { get; set; } = null!;

        public string Celular { get; set; } = null!;

    }
}
