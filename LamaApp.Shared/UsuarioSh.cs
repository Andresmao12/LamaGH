using System.ComponentModel.DataAnnotations;

namespace LamaApp.Shared {

    public class UsuarioSh
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres.")]
        public string NombreUsuario { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
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

