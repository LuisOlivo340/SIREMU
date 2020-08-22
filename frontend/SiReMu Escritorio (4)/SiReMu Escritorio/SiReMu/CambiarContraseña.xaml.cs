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
using System.Windows.Shapes;

namespace SiReMu
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class CambiarContraseña : Window
    {
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);
        public CambiarContraseña()
        {
            InitializeComponent();
            passbViejaContraseña.Focus();
        }

        private void CambiarContraseñaClick(object sender, RoutedEventArgs e)
        {
            if (!this.ValidarCamposVacios() || !this.CompararContraseñas())
            {
                return;
            }
            var ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            var cambioContraseña = new CambioContrasenas();
            cambioContraseña.IdUsuario = ventanaPrincipal.getCuenta().Id;
            cambioContraseña.ContrasenaAnterior = passbViejaContraseña.Password;
            cambioContraseña.NuevaContrasena = passbNuevaContraseña.Password;
            try
            {
                var respuesta = clienteCuentas.CambiarContrasena(cambioContraseña);
                if (respuesta.Respuesta)
                {
                    MessageBox.Show("La contraseña ha sido cambiada con éxito.", "Contraseña cambiada con éxito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                this.Close();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                MessageBox.Show(ex.Status.Detail + " Modifiquela e inténtelo de nuevo.", "Contraseña actual no válida", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelarClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool ValidarCamposVacios()
        {
            if (passbViejaContraseña.SecurePassword.Length == 0 || passbNuevaContraseña.SecurePassword.Length == 0 || passbConfirmarContraseña.SecurePassword.Length == 0)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Faltan campos por llenar", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (passbNuevaContraseña.SecurePassword.Length < 8)
            {
                MessageBox.Show("La contraseña debe ser igual mayor a 8 caracteres.", "Pocos caracteres", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
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
            if (!passbNuevaContraseña.Password.Equals(passbConfirmarContraseña.Password))
            {
                passbConfirmarContraseña.Clear();
                MessageBox.Show("Las nuevas contraseñas no coinciden. Reviselas e intente de nuevo.", "Las contraseñas no coinciden", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
