using ProyectoApi.controller;
using ProyectoApi.model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Favoritos : Page {

        ControllerBD cBd = new ControllerBD();
        List<BitmapImage> fondos;
        int conta = 0;
        private ControllerApi c = new ControllerApi();
        Usuario u;
        Menu2 m;


        public Favoritos(Usuario u, Menu2 m) {
            InitializeComponent();
            this.u = u;
            this.m = m;
            fondos = new List<BitmapImage>();
        }



        private void Grid_LoadedAsync(object sender, RoutedEventArgs e) {
            if (m.Parent != null) {
                ((Grid)m.Parent).Children.Remove(m);
                UControl.Children.Add(m);
            } else {
                UControl.Children.Add(m);
            }

            fondos = cBd.ObtenerImagen(u);

            if (fondos.Count > 0) {
                c.SetBackground(fondos[0], grid);
            } else {
                MessageBox.Show("todavia no hay favoritos!");
            }
            m.lablUserNick.Content = u.Nick;

        }



        private void girar_Click(object sender, RoutedEventArgs e) {

            if (conta < fondos.Count - 1) {
                conta++;
                c.SetBackground(fondos[conta], grid);

            } else {
                conta = 0;
            }

        }
    }
}
