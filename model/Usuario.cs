namespace ProyectoApi.model {
    public class Usuario {
        /// <summary>
        /// Clase que representa a un usuario en el sistema.
        /// </summary>


        private int id;
        private string name;
        private string email;
        private string pass;
        private int esAdmin;

        /// <summary>
        /// Constructor que inicializa todas las propiedades del usuario.
        /// </summary>
        /// <param name="id">El identificador del usuario.</param>
        /// <param name="name">El nombre completo del usuario.</param>
        /// <param name="email">El correo electrónico del usuario.</param>
        /// <param name="nick">El apodo o nombre de usuario del usuario.</param>
        /// <param name="pass">La contraseña del usuario.</param>
        /// <param name="esAdmin">Un valor entero que indica si el usuario es un administrador (1) o no (0).</param>
        public Usuario(int id, string name, string email, string nick, string pass, int esAdmin) {
            this.id = id;
            this.name = name;
            this.email = email;
            this.Nick = nick;
            this.pass = pass;
            this.esAdmin = esAdmin;
        }

        /// <summary>
        /// Constructor que inicializa todas las propiedades del usuario, excepto el ID ya que es un valor que genera la base de datos (Autoincremental).
        /// </summary>
        /// <param name="name">El nombre completo del usuario.</param>
        /// <param name="email">El correo electrónico del usuario.</param>
        /// <param name="nick">El apodo o nombre de usuario del usuario.</param>
        /// <param name="pass">La contraseña del usuario.</param>
        /// <param name="esAdmin">Un valor entero que indica si el usuario es un administrador (1) o no (0).</param>
        
        public Usuario(string name, string email, string nick, string pass, int esAdmin) {

            this.name = name;
            this.email = email;
            this.Nick = nick;
            this.pass = pass;
            this.esAdmin = esAdmin;
        }

        public string Nick { get; set; }
        public string Pass { get => pass; set => pass = value; }
        public int EsAdmin { get => esAdmin; set => esAdmin = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
    }
}
