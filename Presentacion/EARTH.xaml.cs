using ProyectoApi.controller;
using ProyectoApi.model;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EARTH : Page {

        public Menu2 m;
        private string key = "Hfdvt1904UaVxgf9yelYVSajHkBU47nO9Bz3mSLS";
        private string keyBing = "AqPv3Znu - 9fQnnBNfYhnL5gPyK10tQ5tz6HWeaJzYxnoSr9SbH6Y1DWEwrW6C9nX";
        BitmapImage img;
        private JsonDocument? jsonBing = null;
        ControllerApi c = new ControllerApi();
        ControllerBD cBd = new ControllerBD();
        private string UrlImagen;
        public string? Lat;
        public string? Longi;
        Usuario u;


        public EARTH(Usuario u, Menu2 m) {
            InitializeComponent();
            this.m = m;
            this.u = u;

        }


        private async void Grid_LoadedAsync(object sender, RoutedEventArgs e) {
            if (m.Parent != null) {
                ((Grid)m.Parent).Children.Remove(m);
                UControl.Children.Add(m);
            } else {
                UControl.Children.Add(m);
            }
            UrlImagen = $"https://api.nasa.gov/planetary/earth/imagery?lon=86.9250261&lat=27.98785&date=2019-01-01&dim=0.5&api_key={key}";
            img = c.GetImage(UrlImagen);
            c.SetBackground(img, grid);
            m.lablUserNick.Content = u.Nick;


        }

        public void parseJson(JsonDocument js) {

            jsonBing = js;
            JsonElement jsE = jsonBing.RootElement.GetProperty("resourceSets")[0].GetProperty("resources");
            int numIndex = jsE.GetArrayLength();

            for (int i = 0; i < numIndex; i++) {
                list.Items.Add(jsE[i].GetProperty("name"));
            }

        }

        private async void busq_Click(object sender, RoutedEventArgs e) {

            jsonBing = await c.GetJson($"http://dev.virtualearth.net/REST/v1/Locations?query={textBusq.Text}&maxResults=20&key={keyBing}&output=json");
            parseJson(jsonBing);
        }


        private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (jsonBing != null) {

                int selectedIndex = list.SelectedIndex;
                JsonElement elemento = jsonBing.RootElement.GetProperty("resourceSets")[0].GetProperty("resources")[selectedIndex].GetProperty("point").GetProperty("coordinates");
                Lat = elemento[0].ToString();
                Longi = elemento[1].ToString();
                UrlImagen = $"https://api.nasa.gov/planetary/earth/imagery?lon={Longi}&lat={Lat}&date=2019-01-01&dim=0.3&api_key={key}";
                img = c.GetImage(UrlImagen);
                c.SetBackground(img, grid);


            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e) {
            cBd.InsertarImagen(img, u);
        }
    }
}
