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
using System.Reflection;

namespace ProyectoApi.controller {

    /// <summary>
    /// Esta clase gestiona la base de datos.
    /// </summary>
    public class ControllerBD {

        private SQLiteConnection conn;
        private SQLiteCommand comando;
        private SQLiteDataReader r;

        /// <summary>
        /// Este método establece la conexión a la base de datos SQLite.
        /// </summary>
        public void Conectar() {
            string CaminoBD = Path.GetDirectoryName(Environment.ProcessPath);
            string caminoarchivo = Path.Combine(CaminoBD, "Resources");
            string caminoCompleto = Path.Combine(caminoarchivo, "ProyectoApi.db");

            if (conn != null) {
                conn = null;
            }
            try {
                conn = new SQLiteConnection("Data Source=" + caminoCompleto + "; Version=3; New = False");
                conn.Open();
            } catch (Exception) {
                conn = new SQLiteConnection("Data Source= ..\\..\\..\\Resources\\ProyectoApi.db; Version=3 ;New = False");
                conn.Open();
            }

        }
        /// <summary>
        /// Este método consulta un usuario por su ID en la tabla User de la base de datos.
        /// </summary>
        /// <param name="id">El ID del usuario a consultar.</param>
        /// <returns>El objeto Usuario correspondiente al ID especificado.</returns>
        public Usuario Consulta(int id) {
            Conectar();
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

        /// <summary>
        /// Este método obtiene una lista de todos los usuarios almacenados en la tabla User de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario correspondientes a todos los usuarios de la tabla User.</returns>
        public List<Usuario> GetUsuarios() {
            List<Usuario> usuarios = new();
            Usuario u;
            Conectar();
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
        /// <summary>
        /// Este método cifra una contraseña utilizando el algoritmo SHA256.(sacado de stackoverflow)
        /// </summary>
        /// <param name="contrasena">La contraseña a cifrar.</param>
        /// <returns>La contraseña cifrada.</returns>
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
        /// <summary>
        /// Este método comprueba las credenciales de un usuario en la tabla User de la base de datos.
        /// </summary>
        /// <param name="usuario">El nombre de usuario a comprobar.</param>
        /// <param name="contrasena">La contraseña del usuario a comprobar.</param>
        /// <returns>El ID del usuario si las credenciales son correctas, -1 en caso contrario.</returns>
        public int ComprobarCredenciales(string usuario, string contrasena) {
            Conectar();
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
        /// <summary>
        /// Este método crea un nuevo registro de usuario en la tabla User de la base de datos.
        /// </summary>
        /// <param name="name">El nombre del usuario.</param>
        /// <param name="email">El correo electrónico del usuario.</param>
        /// <param name="nick">El nombre de usuario del usuario.</param>
        /// <param name="pass">La contraseña del usuario.</param>
        /// <param name="esAdmin">Un valor entero que indica si el usuario es administrador (1) o no (0).</param>

        public void Create(string name, string email, string nick, string pass, int esAdmin) {
            Conectar();
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
        /// <summary>
        /// Este método elimina un registro de usuario de la tabla User de la base de datos.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        public void DeleteUser(int id) {
            Conectar();
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
        /// <summary>
        /// Este método elimina los favoritos de un usuario de la tabla Favoritos de la base de datos.
        /// </summary>
        /// <param name="id">El ID del usuario cuyos favoritos se van a eliminar.</param>
        public void DeleteFav(int id) {
            Conectar();
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
        /// <summary>
        /// Este método cuenta el número de registros de favoritos en la tabla Favoritos de la base de datos correspondientes a un usuario específico.
        /// </summary>
        /// <param name="id">El ID del usuario cuyos favoritos se van a contar.</param>
        /// <returns>El número de registros de favoritos correspondientes al usuario especificado.</returns>
        public int ContarFavoritos(int id) {

            Conectar();
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
        /// <summary>
        /// Inserta una imagen en la base de datos de favoritos asociada a un usuario dado.
        /// </summary>
        /// <param name="img">La imagen a insertar.</param>
        /// <param name="u">El usuario asociado a la imagen.</param>
        public void InsertarImagen(BitmapImage img, Usuario u) {
            byte[] imagenBytes = ImageToByte(img);
            Conectar();
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

        /// <summary>
        /// Obtiene una lista de imágenes almacenadas en la base de datos de favoritos para un usuario dado.
        /// </summary>
        /// <param name="u">El usuario asociado a las imágenes.</param>
        /// <returns>Una lista de objetos BitmapImage que representan las imágenes obtenidas.</returns>

        public List<BitmapImage> ObtenerImagen(Usuario u) {
            Conectar();
            string consulta = "SELECT imagen FROM Favoritos WHERE user_id = @id";

            comando = new SQLiteCommand(consulta, conn);
            comando.Parameters.AddWithValue("@id", u.Id);
            List<BitmapImage> imagenes = new();




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
        /// <summary>
        /// Convierte una imagen BitmapImage a un arreglo de bytes. (sacado de stackoverflow)
        /// </summary>
        /// <param name="bitmap">La imagen a convertir.</param>
        /// <returns>Un arreglo de bytes que representa la imagen.</returns>
        public static byte[] ImageToByte(BitmapImage bitmap) {
            var encoder = new PngBitmapEncoder(); // or any other BitmapEncoder

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using var stream = new MemoryStream();
            encoder.Save(stream);
            return stream.ToArray();
        }
        /// <summary>
        /// Convierte un objeto Stream a un objeto BitmapImage.
        /// </summary>
        /// <param name="ms">El objeto Stream a convertir.</param>
        /// <returns>Un objeto BitmapImage que representa la imagen.</returns>
        public static BitmapImage ToImage(Stream ms) {

            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad; // here
            image.StreamSource = ms;
            image.EndInit();
            return image;

        }


    }

}

