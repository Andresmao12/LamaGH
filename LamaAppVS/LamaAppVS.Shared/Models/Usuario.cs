namespace LamaAppVS.Shared.Models {

    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha_Registro { get; set; }

        // Relación con Capítulo
        public int ID_Capitulo { get; set; }
        public Capitulo Capitulo { get; set; }

        // Relación con Motocicleta
        public ICollection<Motocicleta> Motocicletas { get; set; }

        // Relación con Inscripción
        public ICollection<Inscripcion> Inscripciones { get; set; }

        // Relación con Publicación
        public ICollection<Publicacion> Publicaciones { get; set; }
    }


}

