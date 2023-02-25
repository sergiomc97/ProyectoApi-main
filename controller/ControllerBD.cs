using ProyectoApi.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoApi.controller {
    public class ControllerBD {

        private SQLiteConnection conn;
        private SQLiteCommand comando;
        private SQLiteDataReader r;

        public void conectar() {
            if (conn != null) {
                conn = null;
            }
            try {
                conn = new SQLiteConnection("Data Source= ..\\..\\..\\Resources\\ProyectoApi.db; Version=3 ;New = False");
                conn.Open();
            } catch (Exception ex) {

                MessageBox.Show("error" + ex);
            }

        }
        public Usuario consulta(int id) {
            conectar();
            string consulta = "SELECT * FROM User WHERE id= @id";

            comando = new SQLiteCommand(consulta, conn);
            comando.Parameters.AddWithValue("@id", id);
            Usuario u = null;
            try {
                r = comando.ExecuteReader();
                while (r.Read()) {
                    int idU = r.GetInt32("id");
                    string name = r.GetString("name");
                    string email = r.GetString("email");
                    string nick = r.GetString("Nick");
                    string pass = r.GetString("Pass");
                    int admin = r.GetInt32("EsAdmin");
                    u = new Usuario(idU, name, email, nick, pass, admin);
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            } finally {
                comando.Dispose();
                conn.Close();
            }

            conn.Close();
            return u;

        }
        public List<Usuario> GetUsuarios() {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario u = null;
            conectar();
            string consulta = "SELECT * FROM User";

            comando = new SQLiteCommand(consulta, conn);

            try {
                r = comando.ExecuteReader();
                while (r.Read()) {

                    int idU = r.GetInt32("id");
                    string name = r.GetString("name");
                    string email = r.GetString("email");
                    string nick = r.GetString("Nick");
                    string pass = r.GetString("Pass");
                    int admin = r.GetInt32("EsAdmin");
                    u = new Usuario(idU, name, email, nick, pass, admin);
                    usuarios.Add(u);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                r.Close();
                comando.Dispose();
                conn.Close();

            }

            return usuarios;

        }

        public static string CifrarContrasena(string contrasena) {
            // Convertir la contraseña en una matriz de bytes
            byte[] contrasenaBytes = System.Text.Encoding.UTF8.GetBytes(contrasena);

            // Calcular el hash utilizando SHA256
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(contrasenaBytes);

            // Convertir el hash en una cadena hexadecimal
            string contrasenaCifrada = BitConverter.ToString(hashBytes).Replace("-", "");

            return contrasenaCifrada;
        }

        public int ComprobarCredenciales(string usuario, string contrasena) {
            conectar();
            int id = -1;
            string p = CifrarContrasena(contrasena);
            string consulta = "SELECT id FROM User WHERE Nick = @usuario and Pass = @pass";

            comando = new SQLiteCommand(consulta, conn);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@pass", p);
            try {
                r = comando.ExecuteReader();
                while (r.Read()) {
                    id = r.GetInt32(0);

                }

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            } finally {
                r.Close();
                comando.Dispose();
                conn.Close();
            }

            return id;

        }

        public void Create(string name, string email, string nick, string pass, int esAdmin) {
            conectar();
            string insertQuery = "INSERT INTO User VALUES (@1, @2, @3, @4, @5, @6)";

            comando = new SQLiteCommand(insertQuery, conn);
            comando.Parameters.AddWithValue("@1", null);
            comando.Parameters.AddWithValue("@2", name);
            comando.Parameters.AddWithValue("@3", email);
            comando.Parameters.AddWithValue("@4", nick);
            comando.Parameters.AddWithValue("@5", CifrarContrasena(pass));
            comando.Parameters.AddWithValue("@6", esAdmin);


            try {
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {

                comando.Dispose();
                conn.Close();

            }
        }
        public void DeleteUser(int id) {
            conectar();
            string insertQuery = "delete from User where id=@1";


            comando = new SQLiteCommand(insertQuery, conn);
            comando.Parameters.AddWithValue("@1", id);

            try {
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
                comando.Dispose();
            }
        }
        public void DeleteFav(int id) {
            conectar();
            string insertQuery = "delete from Favoritos where user_id=@1";

            comando = new SQLiteCommand(insertQuery, conn);
            comando.Parameters.AddWithValue("@1", id);

            try {
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
                comando.Dispose();
            }
        }

        public int ContarFavoritos(int id) {

            conectar();
            string consulta = "SELECT COUNT(imagen) FROM Favoritos WHERE user_id = @id";
            int numFav = 0;
            comando = new SQLiteCommand(consulta, conn);
            comando.Parameters.AddWithValue("@id", id);
            try {
                numFav = (int)(Int64)comando.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
                comando.Dispose();
            }



            return numFav;
        }

        public void InsertarImagen(BitmapImage img, Usuario u) {
            byte[] imagenBytes = ImageToByte(img);
            conectar();
            string consultaSql = "INSERT INTO Favoritos Values(@1, @2, @3)";

            comando = new SQLiteCommand(consultaSql, conn);
            comando.Parameters.AddWithValue("@1", null);
            comando.Parameters.AddWithValue("@2", u.Id);
            comando.Parameters.AddWithValue("@3", imagenBytes);


            try {
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
                comando.Dispose();
            }

        }

        public List<BitmapImage> ObtenerImagen(Usuario u) {
            conectar();
            string consulta = "SELECT imagen FROM Favoritos WHERE user_id = @id";

            comando = new SQLiteCommand(consulta, conn);
            comando.Parameters.AddWithValue("@id", u.Id);
            List<BitmapImage> imagenes = new List<BitmapImage>();




            try {
                r = comando.ExecuteReader();
                while (r.Read()) {
                    BitmapImage image = ToImage(r.GetStream("imagen"));

                    imagenes.Add(image);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                r.Close();
                conn.Close();
                comando.Dispose();
            }

            return imagenes;
        }

        public static byte[] ImageToByte(BitmapImage bitmap) {
            var encoder = new PngBitmapEncoder(); // or any other BitmapEncoder

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new MemoryStream()) {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        public BitmapImage ToImage(Stream ms) {

            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad; // here
            image.StreamSource = ms;
            image.EndInit();
            return image;

        }


    }

}

