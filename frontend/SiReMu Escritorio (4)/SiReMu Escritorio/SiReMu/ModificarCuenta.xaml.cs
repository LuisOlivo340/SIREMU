using Grpc.Core;
using MnjCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SiReMu
{
    /// <summary>
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class ModificarCuenta : Page
    {
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);
        private RadioButton generoEscogido;
        private Principal ventanaPrincipal;
        private Usuario miCuenta;

        public ModificarCuenta()
        {
            InitializeComponent();
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            miCuenta = ventanaPrincipal.getCuenta();
            this.MostrarDatos();
        }

        private void MostrarDatos()
        {
            tbNombre.Text = miCuenta.Nombre;
            tbApellidos.Text = miCuenta.Apellido;
            dpNacimiento.SelectedDate = DateTime.Parse(miCuenta.FechaNacimiento);
            switch (miCuenta.Genero)
            {
                case "Hombre":
                    generoEscogido = rbHombre;
                    break;
                case "Mujer":
                    generoEscogido = rbMujer;
                    break;
                default:
                    generoEscogido = rbOtro;
                    break;
            }
            generoEscogido.IsChecked = true;
            tbUsuario.Text = miCuenta.Usuario_;
            tbCorreo.Text = miCuenta.Correo;
            tbCreador.IsChecked = miCuenta.EsCreadorContenido;
        }

        private void GuardarCambiosClick(object sender, RoutedEventArgs e)
        {
            if (!this.ValidarCamposVacios())
            {
                return;
            }
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Id = miCuenta.Id;
            nuevoUsuario.Usuario_ = tbUsuario.Text;
            nuevoUsuario.Nombre = tbNombre.Text;
            nuevoUsuario.Apellido = tbApellidos.Text;
            var fechaNacimiento = dpNacimiento.SelectedDate.Value;
            nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
            nuevoUsuario.Correo = tbCorreo.Text;
            nuevoUsuario.Genero = generoEscogido.Content.ToString();
            nuevoUsuario.EsCreadorContenido = (bool)tbCreador.IsChecked;
            try
            {
                var respuesta = clienteCuentas.ModificarUsuario(nuevoUsuario);
                if (respuesta.Respuesta)
                {
                    MessageBox.Show("Los cambios de la cuenta han sido registrados con éxito.", "Cambios guardados con éxito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
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

        }

        private void CambiarContraClick(object sender, RoutedEventArgs e)
        {
            new CambiarContraseña().ShowDialog();
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

        private void GuardarGenero(object sender, RoutedEventArgs e)
        {
            generoEscogido = sender as RadioButton;
        }

        public bool ValidarCamposVacios()
        {
            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbCorreo.Text == "" || dpNacimiento.SelectedDate == null || tbUsuario.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios", "Faltan campos por llenar", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
