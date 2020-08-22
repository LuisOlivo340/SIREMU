using MnjCanciones;
using MnjCuentas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public partial class MisAlbumes : Page
    {
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private List<Album> misAlbumes = new List<Album>();
        private Usuario miUsuario;

        public MisAlbumes()
        {
            InitializeComponent();
            var ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            this.miUsuario = ventanaPrincipal.getCuenta();
            this.CargarAlbumes();
        }

        private void CargarAlbumes()
        {
            try
            {
                var respuesta = clienteCanciones.ConsultarAlbums(new IdUsuario { Id = miUsuario.Id });
                var albumsAMostrar = new List<ElementoListView>();
                foreach (var album in respuesta.Albums)
                {
                    album.IdCreador = miUsuario.Id;
                    album.NombreCreador = miUsuario.Usuario_;
                    misAlbumes.Add(album);
                    var stream = new MemoryStream(album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    albumsAMostrar.Add(new ElementoListView { IdElemento = album.Id, TituloPrincipal = album.Nombre, TituloSecundario = album.Compania, Ilustracion = imagen });
                }
                lvAlbums.ItemsSource = albumsAMostrar;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MostrarAlbum(object sender, MouseButtonEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvAlbums.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var albumSeleccionado = misAlbumes.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerAlbum(albumSeleccionado));
            }
        }
    }
}
