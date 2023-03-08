﻿using Microsoft.Win32;
using ProyectoApi.controller;
using ProyectoApi.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class loginOK : Page {

        public APOD ap;
        public Menu2 m;
        private string key = "Hfdvt1904UaVxgf9yelYVSajHkBU47nO9Bz3mSLS";
        private JsonDocument? jsonAPOD;
        public Usuario u { get; set; }
        ControllerApi c = new ControllerApi();
        ControllerBD cBd = new ControllerBD();
        public BitmapImage ImagenActual;

        public loginOK(Usuario u, Menu2 m) {
            InitializeComponent();
            ap = control;
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
                UContenedor.Children.Add(m);
            } else {
                UContenedor.Children.Add(m);
            }
            jsonAPOD = await c.GetJson($"https://api.nasa.gov/planetary/apod?&api_key={key}");
            ImagenActual = c.GetImage(jsonAPOD.RootElement.GetProperty("hdurl").ToString());
            c.SetBackground(ImagenActual, grid);
            SetText();
            m.lablUserNick.Content = u.Nick;


        }

        private async void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {

            string selectedDate = dt.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            jsonAPOD = await c.GetJson($"https://api.nasa.gov/planetary/apod?date={selectedDate}&api_key={key}");

            ImagenActual = c.GetImage(jsonAPOD.RootElement.GetProperty("hdurl").ToString());
            c.SetBackground(ImagenActual, grid);
            SetText();


        }




        public void SetText() {


            try {

                JsonElement el = jsonAPOD.RootElement;
                ap.fecha.Text = el.GetProperty("date").ToString();
                ap.explanation.Text = el.GetProperty("explanation").ToString();
                autor.Text = el.GetProperty("copyright").ToString();
                ap.Author.Text = el.GetProperty("copyright").ToString();

            } catch (KeyNotFoundException) {

                autor.Text = "Sin autor";
                ap.Author.Text = "Sin autor";
            }

        }

        private void btn5_Click(object sender, RoutedEventArgs e) {
            cBd.InsertarImagen(ImagenActual, u);
            MessageBox.Show("Añadido a favoritos");
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
