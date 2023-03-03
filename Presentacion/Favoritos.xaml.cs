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
    public partial class Favoritos : Page {

        ControllerBD cBd = new ControllerBD();
        List<BitmapImage> fondos;
        BitmapImage imagenActual;
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

            fondos = cBd.ObtenerImagen(u);

            switch (fondos.Count) {
                case 0:
                    MessageBox.Show("todavia no hay favoritos");
                    break;
                case 1:
                    imgActual.Source = imagenActual;
                    Siguiente.IsEnabled= false;
                    anterior.IsEnabled= false;
                    break;
                case >2:
                    imgActual.Source = fondos[0];
                    imgSig.Source = fondos[1];
                    break;


            }
            m.lablUserNick.Content = u.Nick;

        }


        private void MenuItem_Click(object sender, RoutedEventArgs e) {

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Guardar imagen como ";
            save.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (imagenActual != null) {
                if (save.ShowDialog() == true) {
                    JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                    jpg.Frames.Add(BitmapFrame.Create(imagenActual));
                    using (Stream stm = File.Create(save.FileName)) {
                        jpg.Save(stm);
                    }
                }
            }
        }

        private void anterior_Click(object sender, RoutedEventArgs e) {
            if (conta > 0) {
                conta--;
                imgActual.Source = fondos[conta];
                if (conta > 0) {
                    imgAnt.Source = fondos[conta - 1];
                } else {
                    imgAnt.Source = null;
                }
                imgSig.Source = fondos[conta + 1];
            }
        }

        private void Siguiente_Click(object sender, RoutedEventArgs e) {
            if (conta < fondos.Count - 1) {
                conta++;
                imgActual.Source = fondos[conta];
                imgAnt.Source = fondos[conta - 1];
                if (conta < fondos.Count - 1) {
                    imgSig.Source = fondos[conta + 1];
                } else {
                    imgSig.Source = null;
                }
            }
        }
    }
}
