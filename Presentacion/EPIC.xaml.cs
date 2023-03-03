using Microsoft.Win32;
using ProyectoApi.controller;
using ProyectoApi.model;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EPIC : Page {


        List<BitmapImage> fondos;
        public BitmapImage ImagenActual;
        int conta = 0;
        private ControllerApi c = new ControllerApi();
        ControllerBD cBd = new ControllerBD();
        Usuario u;
        Menu2 m;


        public EPIC(Usuario u, Menu2 m) {
            InitializeComponent();
            this.u = u;
            this.m = m;
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
            fondos = await c.GetImageList();
            ImagenActual = fondos[0];
            c.SetBackgroundStretch(ImagenActual, grid);
            m.lablUserNick.Content = u.Nick;

        }



        private void girar_Click(object sender, RoutedEventArgs e) {

            if (conta < fondos.Count - 1) {
                conta++;
                ImagenActual = fondos[conta];
                c.SetBackgroundStretch(ImagenActual, grid);

            } else {
                conta = 0;
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
