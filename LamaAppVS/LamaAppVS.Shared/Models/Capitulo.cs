namespace LamaAppVS.Shared.Models
{

    public class Capitulo
    {
        public int ID_Capitulo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        // Relación con Usuario
        public ICollection<Usuario> Usuarios { get; set; }

        // Relación con Evento
        public ICollection<Evento> Eventos { get; set; }
    }


}

