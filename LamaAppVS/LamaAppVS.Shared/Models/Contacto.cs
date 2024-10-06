using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaAppVS.Shared.Models
{
    public class Contacto
    {

        public int ID_Contacto { get; set; }
        public int Direccion { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        //Relacion 1 -> 1
        public Usuario Usuario { get; set; }
    }
}
