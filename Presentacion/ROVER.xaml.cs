using Microsoft.Win32;
using ProyectoApi.controller;
using ProyectoApi.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ROVER : Page {

        /// <summary>
        /// Menú de la aplicación.
        /// </summary>
        public Menu2 m;

        /// <summary>
        /// Clave de la API de la NASA utilizada para obtener imágenes del rover Curiosity.
        /// </summary>
        private string key = "Hfdvt1904UaVxgf9yelYVSajHkBU47nO9Bz3mSLS";

        /// <summary>
        /// URL de la imagen seleccionada.
        /// </summary>
        private string UrlImagen;

        /// <summary>
        /// Imagen actual mostrada en la aplicación.
        /// </summary>
        public BitmapImage ImagenActual;

        /// <summary>
        /// Controlador de la API de la NASA.
        /// </summary>
        ControllerApi c = new ControllerApi();

        /// <summary>
        /// Controlador de la base de datos local.
        /// </summary>
        ControllerBD cBd = new ControllerBD();

        /// <summary>
        /// Lista de imágenes obtenidas de la API de la NASA.
        /// </summary>
        List<BitmapImage> fondos;

        /// <summary>
        /// Contador utilizado para navegar entre las imágenes.
        /// </summary>
        public int conta = 0;

        /// <summary>
        /// Usuario actual de la aplicación.
        /// </summary>
        public Usuario u;

        /// <summary>
        /// Constructor de la página ROVER.
        /// </summary>
        /// <param name="u">Usuario actual de la aplicación.</param>
        /// <param name="m">Menú de la aplicación.</param>
        public ROVER(Usuario u, Menu2 m) {
            InitializeComponent();
            this.m = m;
            this.u = u;
        }

        /// <summary>
        /// Si existe un objeto "Menu2" en el padre del objeto actual, se elimina y se agrega al control "UControl".
        /// A continuación, obtiene las imágenes favoritas del usuario actual de la base de datos y establece la primera imagen como el fondo de la aplicación.
        /// </summary>
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


        private  void Cambiar_Click(object sender, RoutedEventArgs e) {
            InitImages();
        }
        /// <summary>
        /// Este método inicializa las imágenes mostradas en la aplicación.
        /// Obtiene la fecha seleccionada por el usuario y utiliza una API de la NASA para obtener una lista de imágenes
        /// del rover Curiosity en Marte para esa fecha. A continuación, establece la imagen actual como el fondo de la aplicación.
        /// Si hay más de una imagen, habilita los botones "anterior" y "siguiente" para permitir al usuario navegar por las imágenes.
        /// Si solo hay una imagen, deshabilita los botones para evitar que el usuario navegue a una imagen inexistente.
        /// Si no hay imágenes para la fecha seleccionada, muestra un mensaje de error al usuario.
        /// </summary>

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

        private void MenuItem_Click(object sender, RoutedEventArgs e) {

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Guardar imagen como ";
            save.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (ImagenActual != null) {
                if (save.ShowDialog() == true) {
                    JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                    jpg.Frames.Add(BitmapFrame.Create(ImagenActual));
                    using (Stream stm = File.Create(save.FileName)) {
                        jpg.Save(stm);
                    }
                }
            }
        }
    }
}
