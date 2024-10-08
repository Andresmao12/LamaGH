using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaAppVS.Shared.Models
{
    public class Pareja
    {

        public int ID_Pareja { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }

        //Relacion 1 -> 1
        public Usuario Usuario { get; set; }

    }
}
