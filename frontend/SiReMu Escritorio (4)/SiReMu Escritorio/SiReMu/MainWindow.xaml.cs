using Grpc.Core;
using MnjCuentas;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SiReMu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);

        public MainWindow()
        {
            InitializeComponent();
            tbUsuario.Focus();
        }

        /// <summary>
        /// Llama al servidor para iniciar sesión con el correo y la contraseña y abre el menú principal.
        /// Abre la ventana de ingresar código de activación de cuenta si la cuenta no está activada.
        /// </summary>
        /// <param name="sender">Botón de iniciar sesión.</param>
        /// <param name="e">Evento Click.</param>
        /// <exception cref="System.ServiceModel.EndpointNotFoundException">
        /// Arrojada cuando no hay conexión con el servidor.
        /// </exception>
        private void Button_IniciarSesion(object sender, RoutedEventArgs e)
        {
            if (!this.ValidarCamposVacios())
            {
                return;
            }
            try
            {
                var respuesta = clienteCuentas.IniciarSesion(new Usuario() { Usuario_ = tbUsuario.Text, Contrasenia = passbContraseña.Password });
                Principal principal = new Principal(respuesta.Cuenta);
                if (!principal.PrepararSesion())
                {
                    throw new Exception();
                }
                principal.Show();
                principal.framePrincipal.Navigate(new MenuInicio("CancionesEnPromocion"));
                this.Close();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                MessageBox.Show(ex.Status.Detail+" Inténtelo de nuevo.", "Datos no válidos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Abre la ventana del registro para nuevos usuarios.
        /// </summary>
        /// <param name="sender">Botón de registrarse.</param>
        /// <param name="e">Evento de Click.</param>
        private void Button_Registrarse(object sender, RoutedEventArgs e)
        {
            new Registrarse().Show();
            this.Close();
        }

        /// <summary>
        /// Valida que los campos de correo y contraseña no estén vacíos y de ser el caso avisa al usuario. 
        /// </summary>
        /// <returns>Verdadero si los dos no están vacíos o falso si alguno lo está.</returns>
        public bool ValidarCamposVacios()
        {

            if (tbUsuario.Text == "")
            {
                MessageBox.Show("Ingresa el usuario");
                return false;
            }
            else if (passbContraseña.SecurePassword.Length == 0)
            {
                MessageBox.Show("Ingresa la contraseña");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Si el campo del correo del usuario esta vació hace visible el label del usuario.
        /// </summary>
        /// <param name="sender">Textbox del correo.</param>
        /// <param name="e">Evento de perder foco.</param>
        private void TextBox_Usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                lbUsuario.Visibility = Visibility.Visible;
                return;
            }
            var reemplazo = Regex.Replace(tbUsuario.Text, @"[^\w\s]+", "");
            if (!reemplazo.Equals(tbUsuario.Text))
            {
                MessageBox.Show("Solo se permiten espacios, letras y números", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbUsuario.Text = reemplazo;
            }
        }

        /// <summary>
        /// Si el campo de la contraseña del usuario esta vació hace visible el label de la contraseña.
        /// </summary>
        /// <param name="sender">Passwordbox de la contraseña.</param>
        /// <param name="e">Evento de perder foco.</param>
        private void PasswordBox_Contraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passbContraseña.Password == "")
            {
                lbContraseña.Visibility = Visibility.Visible;
                return;
            }
            if (Regex.IsMatch(passbContraseña.Password, @"[^A-Za-z0-9\u00F1\u00D1]+"))
            {
                passbContraseña.Clear();
                MessageBox.Show("Solo se permiten letras SIN acentos y números.", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                lbContraseña.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Oculta el label de la contraseña si se escribe en el campo de la contraseña.
        /// </summary>
        /// <param name="sender">Passwordbox de la contraseña.</param>
        /// <param name="e">Evento de letra presionada.</param>
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            lbContraseña.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Oculta el label del usuario si se escribe en el campo del correo del usuario.
        /// </summary>
        /// <param name="sender">Textbox del correo del usuario.</param>
        /// <param name="e">Evento de letra presionada.</param>
        private void TextBox_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            lbUsuario.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Pone el focus en el campo de la contraseña.
        /// </summary>
        /// <param name="sender">Label de la contraseña.</param>
        /// <param name="e">Evento de Click presionado.</param>
        private void Label_Contraseña_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passbContraseña.Focus();
        }

        /// <summary>
        /// Pone el focus en el campo del correo del usuario.
        /// </summary>
        /// <param name="sender">Label del correo del usuario.</param>
        /// <param name="e">Evento de Click presionado.</param>
        private void Label_Usuario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbUsuario.Focus();
        }

    }
}
