using ProyectoApi.model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProyectoApi.controller {
    public class ControllerApi {


        private string key = "Hfdvt1904UaVxgf9yelYVSajHkBU47nO9Bz3mSLS";
        private JsonDocument? json;
        public string imageUri = string.Empty;
        private string date;
        private DateTime dt;



        public async Task<JsonDocument> GetJson(string consulta) {
            try {
                using var client = new HttpClient();
                var content = await client.GetStringAsync(consulta);
                return JsonDocument.Parse(content);

            } catch (Exception e) {
                MessageBox.Show("error desconocido" + e);
                return null;
            }

        }
        public async Task<List<string>> GetStrings() {

            List<string> imagenes = new List<string>();
            json = await GetJson($"https://api.nasa.gov/EPIC/api/natural?api_key={key}");
            int numImages = json.RootElement.GetArrayLength();
            date = json.RootElement[0].GetProperty("date").ToString();
            for (int i = 0; i < numImages; i++) {
                imagenes.Add(json.RootElement[i].GetProperty("image").ToString());

            }
            return imagenes;

        }


        public async Task<List<string>> GetStrings(string url) {
            List<string> imagenes = new List<string>();
            json = await GetJson(url);
            int num = json.RootElement.GetProperty("photos").GetArrayLength();

            for (int i = 0; i < num; i++) {
                imagenes.Add(json.RootElement.GetProperty("photos")[i].GetProperty("img_src").ToString());
                //date = jsonAPOD.RootElement[i].GetProperty("date").ToString();
            }

            return imagenes;

        }


        public async Task<List<BitmapImage>> GetImageList() {

            List<string> imagenes = await GetStrings();
            DateTime.TryParse(date, out dt);
            List<BitmapImage> fondos = new List<BitmapImage>();
            BitmapImage img = new BitmapImage();

            for (int i = 0; i < imagenes.Count; i++) {

                imageUri = $"https://epic.gsfc.nasa.gov/archive/natural/{dt.ToString("yyyy/MM/dd")}/jpg/{imagenes[i]}.jpg";
                img = GetImage(imageUri);
                fondos.Add(img);
            }
            return fondos;


        }
        public async Task<List<BitmapImage>> GetImageList(string url) {

            List<string> imagenes = await GetStrings(url);
            List<BitmapImage> fondos = new List<BitmapImage>();
            BitmapImage img = new BitmapImage();

            for (int i = 0; i < imagenes.Count; i++) {

                img = GetImage(imagenes[i]);
                fondos.Add(img);
            }

            return fondos;


        }

        public BitmapImage GetImage(string imageUri) {
            var bitmapImage = new BitmapImage(new Uri(imageUri));
            return bitmapImage;

        }

        public async Task<List<Asteroide>> GetAsteroids() {
            List<Asteroide> asteroides = new List<Asteroide>();
            Asteroide a;
            json = await GetJson($"http://api.nasa.gov/neo/rest/v1/neo/browse?page=0&size=20&api_key={key}");


            int numData = json.RootElement.GetProperty("near_earth_objects").GetArrayLength();



            for (int i = 0; i < numData; i++) {
                JsonElement el = json.RootElement.GetProperty("near_earth_objects")[i];


                a = new Asteroide(

                    el.GetProperty("name").ToString(),
                    el.GetProperty("id").ToString(),
                    el.GetProperty("estimated_diameter").GetProperty("kilometers").GetProperty("estimated_diameter_min").ToString(),
                    el.GetProperty("is_potentially_hazardous_asteroid").ToString(),
                    el.GetProperty("close_approach_data")[0].GetProperty("close_approach_date_full").ToString(),
                    el.GetProperty("close_approach_data")[0].GetProperty("relative_velocity").GetProperty("kilometers_per_hour").ToString(),
                    el.GetProperty("close_approach_data")[0].GetProperty("orbiting_body").ToString(),
                    el.GetProperty("close_approach_data").GetArrayLength().ToString()

                    );
                asteroides.Add(a);

            }
            return asteroides;

        }


        public void SetBackgroundStretch(BitmapImage img, Grid g) {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = img;
            myBrush.Stretch = Stretch.Uniform;
            g.Background = myBrush;

        }
        public void SetBackground(BitmapImage img, Grid g) {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = img;
            g.Background = myBrush;

        }

    }
}
