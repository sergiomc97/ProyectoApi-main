using ProyectoApi.model;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Lógica de interacción para APOD.xaml
    /// </summary>
    public partial class Menu2 : UserControl {

        public Usuario usuario { get; set; }

        public delegate void MiEvento(Type tipoPagina);
        public event MiEvento? miEvento;



        public Menu2(Usuario u) {
            InitializeComponent();
            usuario = u;

        }



        private void apod_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(loginOK));
        }

        private void asteroides_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(Asteroids));
        }

        private void earth_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(EARTH));
        }

        private void epic_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(EPIC));
        }

        private void rover_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(ROVER));
        }

        private void salir_Click(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(Salida));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) {
            if (usuario.EsAdmin == 0) {
                ad.Visibility = Visibility.Visible;
            }
        }

        private void admin_Click(object sender, RoutedEventArgs e) {
            miEvento?.Invoke(typeof(Admin));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {

        }

        private void fav_Click(object sender, RoutedEventArgs e) {
            miEvento?.Invoke(typeof(Favoritos));
        }

        private void btnAcercaDe_Click(object sender, RoutedEventArgs e) {
            string url = "https://github.com/sergiomc97/ProyectoApi-main/blob/main/README.md";

            try {
                Process.Start(url);

            } catch {

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");

                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    Process.Start("xdg-open", url);
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                } else {
                    throw;
                }
            }
        }
    }
}
