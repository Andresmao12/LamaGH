namespace LamaAppVS.Shared.Models
{
    public class Motocicleta
    {
        public int ID_Motocicleta { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Cilindrada { get; set; }
        public string Placa { get; set; }

        // Relación con Usuario
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }


}


