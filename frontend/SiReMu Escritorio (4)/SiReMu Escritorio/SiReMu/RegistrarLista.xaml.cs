using Google.Protobuf;
using Grpc.Core;
using Microsoft.Win32;
using MnjListas;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class RegistrarLista : Page
    {
        private ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private ListaReproduccion miListaReproduccion;
        private Stream imgStream;
        private string extensionImagen;

        public RegistrarLista()
        {
            InitializeComponent();
            tbNombre.Focus();
        }

        public RegistrarLista(ListaReproduccion listaReproduccion)
        {
            InitializeComponent();
            this.miListaReproduccion = listaReproduccion;
            this.MostrarDatosLista();
            tbNombre.Focus();
        }

        private void MostrarDatosLista()
        {
            lbTitulo.Content = "Modificar lista";
            tbNombre.Text = miListaReproduccion.Nombre;
            tbDescripcion.Text = miListaReproduccion.Descripcion;
            cbPublica.IsChecked = miListaReproduccion.EsPublica;
            imgStream = new MemoryStream(miListaReproduccion.Ilustracion.ToByteArray());
            extensionImagen = miListaReproduccion.ExtensionIlustracion;
            var imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.CacheOption = BitmapCacheOption.OnLoad;
            imagen.StreamSource = imgStream;
            imagen.EndInit();
            imgIlustracion.Source = imagen;
            btCrearLista.Content = "Modificar lista";
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Salir();
        }

        private void Salir()
        {
            this.NavigationService.Navigate(new MisListasReproduccion());
        }

        private void CrearModificarLista(object sender, RoutedEventArgs e)
        {
            if (!ValidarCamposVacios())
            {
                return;
            }
            var nuevaLista = new ListaReproduccion();
            if (miListaReproduccion != null)
            {
                nuevaLista.Id = miListaReproduccion.Id;
            }
            nuevaLista.Nombre = tbNombre.Text;
            nuevaLista.Descripcion = tbDescripcion.Text;
            nuevaLista.EsPublica = (bool)cbPublica.IsChecked;
            imgStream.Position = 0;
            nuevaLista.Ilustracion = ByteString.FromStream(imgStream);
            nuevaLista.ExtensionIlustracion = extensionImagen;
            var ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            var listaAG = new ListaAG();
            listaAG.IdUsuario = ventanaPrincipal.getCuenta().Id;
            listaAG.ListaAAgregar = nuevaLista;
            try
            {
                if (miListaReproduccion == null)
                {
                    var respuesta = clienteListas.CrearListaReproduccion(listaAG);
                }
                else
                {
                    var respuesta = clienteListas.ModificarListaReproduccion(listaAG);
                }
                this.Salir();
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.AlreadyExists)
            {
                MessageBox.Show("Ya tiene una playlist registrada con ese nombre. Cambie el nombre e inténtelo de nuevo.", "Playlist ya registrada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarImagen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Archivos de imagen (*.jpg *.png)|*.JPG;*.PNG";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Seleccione una imágen";
            openFileDialog.RestoreDirectory = true;
            try
            {
                if ((bool)openFileDialog.ShowDialog())
                {
                    imgStream = openFileDialog.OpenFile();
                    if (imgStream.Length > Propiedades.Default.TamañoMaxImagen)
                    {
                        MessageBox.Show("La imágen excede el tamaño máximo permitido. La imágen debe pesar menos de 0.5MB", "Error al cargar la imagen", MessageBoxButton.OK, MessageBoxImage.Error);
                        imgStream.Dispose();
                        imgStream = null;
                        return;
                    }
                    extensionImagen = System.IO.Path.GetExtension(openFileDialog.FileName);
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.StreamSource = imgStream;
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.EndInit();
                    imgIlustracion.Source = imagen;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la imágen. Inténtelo de nuevo.", "Error al cargar el archivo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCamposVacios()
        {
            if (tbNombre.Text.Equals("") || tbDescripcion.Text.Equals("") || imgStream == null)
            {
                MessageBox.Show("Todos los datos son obligatorios.", "Campos faltantes", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ValidarTexto(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            var reemplazo = Regex.Replace(textbox.Text, @"[^\w\s.)#,*(-]+", "");
            if (!reemplazo.Equals(textbox.Text))
            {
                MessageBox.Show("Solo se permiten espacios, paréntesis, comas, guiones, puntos, asteriscos, letras y números", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textbox.Text = reemplazo;
            }
        }
    }
}
