namespace LamaApp.Shared {

    public class UsuarioSh
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Cedula { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdContacto { get; set; }

        public int IdPareja { get; set; }

        public int IdCapitulo { get; set; }

        public int IdMotocicleta { get; set; }


        public ContactoSh? Contacto { get; set; }

        public ParejaSh? Pareja { get; set; }

        public CapituloSh? Capitulo { get; set; } 

        public MotocicletaSh? Motocicleta { get; set; } 

    }




}

