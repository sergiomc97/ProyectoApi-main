using ProyectoApi.controller;
using ProyectoApi.model;
using System;
using System.Windows.Navigation;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : NavigationWindow {
        Usuario u;
        public Menu2 m;
        loginOK l;
        Favoritos F;
        EARTH e;
        EPIC p;
        Asteroids a;
        ROVER r;
        Admin admin;
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

                login l = new login();
                l.Show();
                this.Close();

            }

        }
    }
}
