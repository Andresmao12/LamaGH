using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaApp.Shared
{
    public class Estadisticas
    {
        public int TotalUsuarios { get; set; }

        public int TotalCapitulos { get; set; }

        public List<CapituloSh> listaCapitulos  { get; set;}
        public string CapituloConMasUsuarios { get; set; }
        public string LugarConMasEventos { get; set; }

    }
}
