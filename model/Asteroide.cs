namespace ProyectoApi.model {
    public class Asteroide {
        /// <summary>
        /// Clase que representa a un Asteroide en el sistema.
        /// </summary>

        private string name;
        private string id;
        private string km;
        private string peligroso;

        /// <summary>
        /// Constructor que inicializa todas las propiedades del asteroide.
        /// </summary>
        /// <param name="name">El nombre del asteroide.</param>
        /// <param name="id">El identificador del asteroide.</param>
        /// <param name="km">El diámetro del asteroide en kilómetros.</param>
        /// <param name="peligroso">Un valor que indica si el asteroide es peligroso o no.</param>
        /// <param name="fecha">La fecha del descubrimiento del asteroide.</param>
        /// <param name="velocidad">La velocidad del asteroide en kilómetros por segundo.</param>
        /// <param name="cuerpoOr">El cuerpo celeste alrededor del cual orbita el asteroide.</param>
        /// <param name="numVeces">El número de veces que el asteroide ha sido observado.</param>

        public Asteroide(string name, string id, string km, string peligroso) {
            this.name = name;
            this.id = id;
            this.km = km;
            this.peligroso = peligroso;
          

        }

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Km { get => km; set => km = value; }
        public string Peligroso { get => peligroso; set => peligroso = value; }

    }
}