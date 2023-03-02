using ProyectoApi.controller;
using ProyectoApi.model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Asteroids : Page {

        public Menu2 m;
        public string imageUri = string.Empty;
        Usuario u;
        int conta = 1;
        List<Asteroide> asteroides = new();
        ControllerApi c = new();

        public Asteroids(Usuario u, Menu2 m) {
            InitializeComponent();
            this.m = m;
            this.u = u;
        }

        /// <summary>
        /// Si existe un objeto "Menu2" en el padre del objeto actual, se elimina y se agrega al control "UControl".
        /// A continuación, obtiene las imágenes favoritas del usuario actual de la base de datos y establece la primera imagen como el fondo de la aplicación.
        /// </summary>
        private async void Grid_LoadedAsync(object sender, RoutedEventArgs e) {

            if (m.Parent != null) {
                ((Grid)m.Parent).Children.Remove(m);
                UControl.Children.Add(m);
            } else {
                UControl.Children.Add(m);
            }

            asteroides = await c.GetAsteroids();
            SetLabel(asteroides[0]);
            m.lablUserNick.Content = u.Nick;


        }

        public void SetLabel(Asteroide a) {

            if (a.Peligroso == "True") {
                peligrosoGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B25964");

            } else {
                peligrosoGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#56B7D3");
            }

            nombre.Text = a.Name;

            id.Text = a.Id;

            distancia.Text = a.Km;

            peligroso.Text = a.Peligroso;

            fecha.Text = a.Fecha;

            velocidad.Text = a.Velocidad;

            cuerpoOrbit.Text = a.CuerpoOr;

            veces.Text = a.NumVeces;

        }



        private void Siguiente_Click(object sender, RoutedEventArgs e) {

            if (conta < asteroides.Count) {
                SetLabel(asteroides[conta]);
                conta++;
            }

        }
    }
}
