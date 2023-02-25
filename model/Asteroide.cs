namespace ProyectoApi.model {
    public class Asteroide {

        private string name;
        private string id;
        private string km;
        private string peligroso;
        private string fecha;
        private string velocidad;
        private string cuerpoOr;
        private string numVeces;

        public Asteroide(string name, string id, string km, string peligroso, string fecha, string velocidad, string cuerpoOr, string numVeces) {
            this.name = name;
            this.id = id;
            this.km = km;
            this.peligroso = peligroso;
            this.fecha = fecha;
            this.velocidad = velocidad;
            this.cuerpoOr = cuerpoOr;
            this.numVeces = numVeces;

        }

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Km { get => km; set => km = value; }
        public string Peligroso { get => peligroso; set => peligroso = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Velocidad { get => velocidad; set => velocidad = value; }
        public string CuerpoOr { get => cuerpoOr; set => cuerpoOr = value; }
        public string NumVeces { get => numVeces; set => numVeces = value; }
    }
}