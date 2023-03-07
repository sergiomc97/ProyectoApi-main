using ProyectoApi.controller;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window {

        private ControllerBD cb = new();

        public Login() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            InicioSesion();
        }
        private void InicioSesion() {

            if (user.Text != string.Empty && pass.Password != string.Empty)
            {

                int id = cb.ComprobarCredenciales(user.Text, pass.Password);

                if (id >= 0)
                {

                    Window1 w = new(cb.Consulta(id));
                    w.Show();
                    this.Close();

                }
                else
                {
                    gridOK.Visibility = Visibility.Collapsed;
                    gridError.Visibility = Visibility.Visible;

                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {

            gridError.Visibility = Visibility.Collapsed;
            gridOK.Visibility = Visibility.Visible;

        }



        private void SignUp_Click(object sender, RoutedEventArgs e) {
            gridOK.Visibility = Visibility.Collapsed;
            gridSignUp.Visibility = Visibility.Visible;
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e) {
            int esAdmin = 0;
            if ((bool)checkAdmin.IsChecked) {
                esAdmin = 1;
            }
            if (passReg.Password == passreg2.Password) {
                //añadir a la base de datos
                if (NombreReg.Text != string.Empty && passReg.Password != string.Empty) {
                    cb.Create(NombreReg.Text, emailReg.Text, NickReg.Text, passReg.Password, esAdmin);
                    gridSignUp.Visibility = Visibility.Collapsed;
                    gridOK.Visibility = Visibility.Visible;
                } else {
                    MessageBox.Show("Rellena los campos");
                }
            } else {
                MessageBox.Show("Las contraseñas no coinciden");
            
            }
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            gridSignUp.Visibility = Visibility.Collapsed;
            gridOK.Visibility = Visibility.Visible;
        }


        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter){
                InicioSesion();
            }
        }
    }
}
