﻿using ProyectoApi.controller;
using ProyectoApi.model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Admin : Page {

        public Menu2 m;
        Usuario u;
        List<Usuario> usuarios = new List<Usuario>();
        ControllerApi c = new ControllerApi();
        ControllerBD cBd = new ControllerBD();
        int selected;

        public Admin(Usuario u, Menu2 m) {
            InitializeComponent();
            this.m = m;
            this.u = u;
        }

        /// <summary>
        /// Si existe un objeto "Menu2" en el padre del objeto actual, se elimina y se agrega al control "UControl".
        /// A continuación, obtiene las imágenes favoritas del usuario actual de la base de datos y establece la primera imagen como el fondo de la aplicación.
        /// </summary>
        private void Grid_LoadedAsync(object sender, RoutedEventArgs e) {
            combo.Items.Clear();
            if (m.Parent != null) {
                ((Grid)m.Parent).Children.Remove(m);
                UControl.Children.Add(m);
            } else {
                UControl.Children.Add(m);
            }

            usuarios = cBd.GetUsuarios();
            foreach (Usuario u in usuarios) {
                combo.Items.Add(u.Nick);

            }
            m.lablUserNick.Content = u.Nick;


        }

        public void SetLabel(Usuario a) {

            nombre.Text = a.Name;

            id.Text = a.Nick;

            email.Text = a.Email;

            NumFav.Text = cBd.ContarFavoritos(a.Id).ToString();
        }


        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnBorrarUser.IsEnabled = true;
            btnBorrarFavoritos.IsEnabled = true;
            selected = combo.SelectedIndex;
            SetLabel(usuarios[selected]);
        }

        private void btnBorrarUser_Click(object sender, RoutedEventArgs e) {
            cBd.DeleteUser(usuarios[selected].Id);
        }

        private void btnBorrarFavoritos_Click(object sender, RoutedEventArgs e) {
            cBd.DeleteFav(usuarios[selected].Id);
        }
    }
}
