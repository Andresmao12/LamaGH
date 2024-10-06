namespace LamaAppVS.Shared.Models {

    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public DateTime Fecha_Registro { get; set; }

        //Relaciones
        public int ID_Contacto { get; set; }
        public int ID_Pareja { get; set; }
        public int ID_Capitulo { get; set; }
        public int ID_Motocicleta { get; set; }


        //Relaciones 1 -> 1
        public Contacto Contacto { get; set; }
        public Pareja Pareja { get; set; }
        public Motocicleta Motocicleta { get; set; }

        //Relacicones 1 -> *

        // Relación con Inscripción
        public ICollection<Inscripcion> Inscripciones { get; set; }

        // Relación con Publicación
        public ICollection<Publicacion> Publicaciones { get; set; }

        //Relacion con capitulo
        public Capitulo Capitulo { get; set; }
    }


}

