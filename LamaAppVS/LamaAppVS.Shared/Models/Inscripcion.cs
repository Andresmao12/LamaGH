namespace LamaAppVS.Shared.Models
{

public class Inscripcion
    {
        public int ID_Inscripcion { get; set; }
        public DateTime Fecha_Compra { get; set; }

        // Relación con Evento
        public int ID_Evento { get; set; }
        public Evento Evento { get; set; }

        // Relación con Usuario
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }



}

