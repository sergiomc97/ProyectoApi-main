namespace ProyectoApi.model {
    public class Usuario {

        private int id;
        private string name;
        private string email;
        private string nick;
        private string pass;
        private int esAdmin;

        public Usuario(int id, string name, string email, string nick, string pass, int esAdmin) {
            this.id = id;
            this.name = name;
            this.email = email;
            this.nick = nick;
            this.pass = pass;
            this.esAdmin = esAdmin;
        }
        public Usuario(string name, string email, string nick, string pass, int esAdmin) {

            this.name = name;
            this.email = email;
            this.nick = nick;
            this.pass = pass;
            this.esAdmin = esAdmin;
        }

        public string Nick { get => nick; set => nick = value; }
        public string Pass { get => pass; set => pass = value; }
        public int EsAdmin { get => esAdmin; set => esAdmin = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
    }
}
