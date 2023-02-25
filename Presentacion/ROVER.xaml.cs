using ProyectoApi.controller;
using ProyectoApi.model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ROVER : Page {

        public Menu2 m;
        private string key = "Hfdvt1904UaVxgf9yelYVSajHkBU47nO9Bz3mSLS";
        public string imageUri = string.Empty;
        private string UrlImagen;
        public BitmapImage ImagenActual;
        ControllerApi c = new ControllerApi();
        ControllerBD cBd = new ControllerBD();
        List<BitmapImage> fondos;
        public int conta = 0;
        public Usuario u;


        public ROVER(Usuario u, Menu2 m) {
            InitializeComponent();
            this.m = m;
            this.u = u;

        }


        private void Grid_LoadedAsync(object sender, RoutedEventArgs e) {
            if (m.Parent != null) {
                ((Grid)m.Parent).Children.Remove(m);
                UControl.Children.Add(m);
            } else {
                UControl.Children.Add(m);
            }
            dt.SelectedDate = new DateTime(2015, 12, 29);
            InitImages();

        }


        private void sig_Click(object sender, RoutedEventArgs e) {

            if (conta < fondos.Count - 1) {
                conta++;
                c.SetBackground(fondos[conta], grid);

            } else {
                conta = 0;
            }

        }

        private void ant_Click(object sender, RoutedEventArgs e) {
            if (conta > 0) {
                conta--;
                c.SetBackground(fondos[conta], grid);
            }
        }


        private async void Cambiar_Click(object sender, RoutedEventArgs e) {
            InitImages();
        }
        private async void InitImages() {
            conta = 0;

            string selectedDate = dt.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            UrlImagen = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={selectedDate}&camera={rover.Text}&api_key={key}";
            fondos = await c.GetImageList(UrlImagen);


            if (fondos.Count > 1) {
                ant.IsEnabled = true;
                sig.IsEnabled = true;
                ImagenActual = fondos[conta];
                c.SetBackground(ImagenActual, grid);


            } else if (fondos.Count == 1) {
                ImagenActual = fondos[conta];
                c.SetBackground(ImagenActual, grid);
                ant.IsEnabled = false;
                sig.IsEnabled = false;
            } else {
                MessageBox.Show("En esta fecha no hay ninguna imagen");
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e) {
            cBd.InsertarImagen(ImagenActual, u);
        }
    }
}
