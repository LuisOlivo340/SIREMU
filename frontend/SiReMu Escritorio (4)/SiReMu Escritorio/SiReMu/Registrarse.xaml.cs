using Grpc.Core;
using MnjCuentas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SiReMu
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Registrarse : Window
    {
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);
        private RadioButton generoEscogido;

        public Registrarse()
        {
            InitializeComponent();
            tbNombre.Focus();
            generoEscogido = rbOtro;
            rbOtro.IsChecked = true;
        }

        private void RegistrarClick(object sender, RoutedEventArgs e)
        {
            if (!this.ValidarCamposVacios() || !this.CompararContraseñas())
            {
                return;
            }
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Usuario_ = tbUsuario.Text;
            nuevoUsuario.Nombre = tbNombre.Text;
            nuevoUsuario.Apellido = tbApellidos.Text;
            var fechaNacimiento = dpNacimiento.SelectedDate.Value;
            nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
            nuevoUsuario.Contrasenia = passbContraseña.Password;
            nuevoUsuario.Correo = tbCorreo.Text;
            nuevoUsuario.Genero = generoEscogido.Content.ToString();
            try
            {
                var respuesta = clienteCuentas.RegistrarUsuario(nuevoUsuario);
                Principal principal = new Principal(respuesta.Cuenta);
                if (!principal.PrepararSesion())
                {
                    throw new Exception();
                }
                principal.Show();
                this.Close();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.AlreadyExists)
            {
                MessageBox.Show(ex.Status.Detail + " Modifiquelo e inténtelo de nuevo.", "Datos no válidos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelarClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        public bool ValidarCamposVacios()
        {
            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbCorreo.Text == "" || dpNacimiento.SelectedDate == null || tbUsuario.Text == "" || 
                passbContraseña.SecurePassword.Length == 0 || passbConfirmarContraseña.SecurePassword.Length == 0)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Faltan campos por llenar", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (passbContraseña.SecurePassword.Length < 8)
            {
                MessageBox.Show("La contraseña debe ser igual o mayor a 8 caracteres.", "Pocos caracteres", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }

        private void ValidarTexto(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            var reemplazo = Regex.Replace(textbox.Text, @"[^\w\s]+", "");
            if (!reemplazo.Equals(textbox.Text))
            {
                MessageBox.Show("Solo se permiten espacios, letras y números", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textbox.Text = reemplazo;
            }
        }

        private void ValidarCorreo(object sender, RoutedEventArgs e)
        {
            String expresion = @"[a-z\d_-]+(?:\.[a-z0-9_-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            if (Regex.Replace(tbCorreo.Text, expresion, "", RegexOptions.IgnoreCase).Length != 0)
            {
                tbCorreo.Clear();
                MessageBox.Show("Solo se permiten letras, números, puntos y guiones. Escribe el correo con el formato: alguien_123@ejemplo.com", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ValidarContraseña(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (Regex.IsMatch(passwordBox.Password, @"[^A-Za-z0-9\u00F1\u00D1]+"))
            {
                passwordBox.Clear();
                MessageBox.Show("Solo se permiten letras SIN acentos y números.", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private bool CompararContraseñas()
        {
            if (!passbContraseña.Password.Equals(passbConfirmarContraseña.Password))
            {
                passbConfirmarContraseña.Clear();
                MessageBox.Show("Las contraseñas no coinciden. Reviselas e intente de nuevo.", "Las contraseñas no coinciden", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ValidarNumero(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            var reemplazo = Regex.Replace(textbox.Text, @"[^\d]+", "");
            if (!reemplazo.Equals(textbox.Text))
            {
                MessageBox.Show("Solo se permiten NÚMEROS", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textbox.Text = reemplazo;
            }
        }

        private void GuardarGenero(object sender, RoutedEventArgs e)
        {
            generoEscogido = sender as RadioButton;
        }
    }
}
