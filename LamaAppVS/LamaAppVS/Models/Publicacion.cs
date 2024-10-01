namespace LamaAppVS.Models
{
    public class Publicacion
    {
        public int ID_Publicacion { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con Usuario
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
