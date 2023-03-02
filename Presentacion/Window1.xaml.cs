using ProyectoApi.controller;
using ProyectoApi.model;
using System;
using System.Windows.Navigation;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : NavigationWindow {
        private Usuario u;
        private Menu2 m;
        private loginOK l;
        private Favoritos F;
        private EARTH e;
        private EPIC p;
        private Asteroids a;
        private ROVER r;
        private Admin admin;

        /// <summary>
        /// Constructor de la clase <see cref="Window1"/>.
        /// </summary>
        /// <param name="u">Usuario que ha iniciado sesión.</param>
        public Window1(Usuario u) {
            InitializeComponent();
            this.u = u;
            m = new Menu2(u);
            F = new Favoritos(u, m);
            l = new loginOK(u, m);
            e = new EARTH(u, m);
            p = new EPIC(u, m);
            a = new Asteroids(u, m);
            r = new ROVER(u, m);
            this.admin = new Admin(u, m);
            m.miEvento += MiEventoEventHandler;
            this.Content = l;
        }

        /// <summary>
        /// Manejador del evento <see cref="Menu2.miEvento"/> que cambia el contenido de la ventana principal según la página solicitada.
        /// </summary>
        /// <param name="tipoPagina">Tipo de página solicitada.</param>
        public void MiEventoEventHandler(Type tipoPagina) {


            if (tipoPagina == typeof(loginOK)) {
                Navigate(l);

            } else if (tipoPagina == typeof(EARTH)) {
                Navigate(e);

            } else if (tipoPagina == typeof(EPIC)) {
                Navigate(p);

            } else if (tipoPagina == typeof(Asteroids)) {
                Navigate(a);

            } else if (tipoPagina == typeof(ROVER)) {
                Navigate(r);

            } else if (tipoPagina == typeof(Admin)) {
                Navigate(admin);

            } else if (tipoPagina == typeof(Favoritos)) {
                Navigate(F);
            } else if (tipoPagina == typeof(Salida)) {

                Login l = new();
                l.Show();
                this.Close();

            }

        }
    }
}
