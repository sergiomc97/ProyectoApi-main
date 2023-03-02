using ProyectoApi.model;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Clase que representa el control de usuario del menú de la aplicación.
    /// </summary>
    public partial class Menu2 : UserControl {

        /// <summary>
        /// Propiedad que almacena el objeto de usuario actual.
        /// </summary>
        public Usuario usuario { get; set; }

        /// <summary>
        /// Delegado que define la firma del método de controlador de eventos de <see cref="MiEvento"/>.
        /// </summary>
        /// <param name="tipoPagina">El tipo de página a mostrar.</param>
        public delegate void MiEvento(Type tipoPagina);

        /// <summary>
        /// Evento que se desencadena cuando se hace clic en un elemento del menú.
        /// </summary>
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
            if (usuario.EsAdmin == 1) {
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
            string ruta_trabajo = Path.GetDirectoryName(Environment.ProcessPath);
            string url2 =ruta_trabajo+@"\\Documentacion\\Documentation1.chm";
           
            
            try {
                Process.Start(url);
                Process.Start(url2);


            } catch {

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {

                    url = url.Replace("&", "^&");
                    url2 = url2.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    Process.Start(new ProcessStartInfo(url2) { UseShellExecute = true });

                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {

                    Process.Start("xdg-open", url);
                    Process.Start("xdg-open", url2);

                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {

                    Process.Start("open", url);
                    Process.Start("open", url2);

                } else {
                    throw;
                }
            }



        }

    }
}
