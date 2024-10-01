namespace LamaAppVS.Models
{
    public class Evento
    {
        public int ID_Evento { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Ubicacion { get; set; }
        public string Creador { get; set; }
        public string Descripcion { get; set; }

        // Relación con Capítulo
        public int ID_Capitulo { get; set; }
        public Capitulo Capitulo { get; set; }

        // Relación con Inscripción
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
