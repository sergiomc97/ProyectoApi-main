using ProyectoApi.controller;
using ProyectoApi.model;
using System.Collections.Generic;
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





        /// <summary>
        /// funcion que devuelve el json de la peticion
        /// </summary>
        /// <remarks>
        /// There isn't a way to add XML comments for properties
        /// created for positional records, yet. The language
        /// design team is still considering what tags should
        /// be supported, and where. Currently, you can use
        /// the "param" tag to describe the parameters to the
        /// primary constructor.
        /// </remarks>
        /// <param name="consulta">
        /// url de consulta
        /// </param>



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
        }
    }
}
