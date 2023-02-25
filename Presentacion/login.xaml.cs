using ProyectoApi.controller;
using System.Windows;

namespace ProyectoApi.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class login : Window {

        private ControllerBD cb = new ControllerBD();

        public login() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (user.Text != string.Empty && pass.Text != string.Empty) {

                int id = cb.ComprobarCredenciales(user.Text, pass.Text);

                if (id >= 0) {

                    Window1 w = new Window1(cb.consulta(id));
                    w.Show();
                    this.Close();

                } else {
                    gridOK.Visibility = Visibility.Collapsed;
                    gridError.Visibility = Visibility.Visible;

                }
            }








        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {

        }


        private void Grid_Loaded(object sender, RoutedEventArgs e) {



        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {

            gridError.Visibility = Visibility.Collapsed;
            gridOK.Visibility = Visibility.Visible;

        }



        private void SignUp_Click(object sender, RoutedEventArgs e) {
            gridOK.Visibility = Visibility.Collapsed;
            gridSignUp.Visibility = Visibility.Visible;
        }

        private void registrarse_Click(object sender, RoutedEventArgs e) {
            //añadir a la base de datos
            if (NombreReg.Text != string.Empty && passReg.Text != string.Empty) {
                cb.Create(NombreReg.Text, emailReg.Text, NickReg.Text, passReg.Text, 1);
                gridSignUp.Visibility = Visibility.Collapsed;
                gridOK.Visibility = Visibility.Visible;
            } else {
                MessageBox.Show("Rellena los campos");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            gridSignUp.Visibility = Visibility.Collapsed;
            gridOK.Visibility = Visibility.Visible;
        }
    }
}
