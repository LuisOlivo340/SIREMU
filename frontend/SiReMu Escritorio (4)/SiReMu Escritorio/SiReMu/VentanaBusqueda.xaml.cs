using Grpc.Core;
using MnjCanciones;
using MnjListas;
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
    public partial class VentanaBusqueda : Page
    {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private string busqueda;
        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();
        private List<ListaReproduccion> listasEncontradas = new List<ListaReproduccion>();
        private List<Cancion> cancionesEncontradas = new List<Cancion>();
        private List<Album> albumesEncontrados = new List<Album>();
        private Principal ventanaPrincipal;

        public VentanaBusqueda(string busqueda)
        {
            InitializeComponent();
            this.busqueda = busqueda;
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            if (!this.BuscarListas() || !this.BuscarCanciones() || !BuscarAlbumes() || !this.CargarMenuPlaylists())
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool BuscarListas()
        {
            try
            {
                var respuesta = clienteListas.BuscarListas(new NombreLista { Nombre = busqueda });
                var listasAMostrar = new List<ElementoListView>();
                foreach (var lista in respuesta.Listas)
                {
                    listasEncontradas.Add(lista);
                    var stream = new MemoryStream(lista.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    listasAMostrar.Add(new ElementoListView { IdElemento = lista.Id, TituloPrincipal = lista.Nombre, TituloSecundario = lista.NombreCreador, Ilustracion = imagen });
                }
                lvListas.ItemsSource = listasAMostrar;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool BuscarAlbumes() {
            try
            {
                var respuesta = clienteCanciones.BuscarAlbumes(new Busqueda { Nombre = busqueda });
                var albumesAMostrar = new List<ElementoListView>();
                foreach (var album in respuesta.Albums)
                {
                    albumesEncontrados.Add(album);
                    var stream = new MemoryStream(album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    albumesAMostrar.Add(new ElementoListView { IdElemento = album.Id, TituloPrincipal = album.Nombre, TituloSecundario = album.NombreCreador, Ilustracion = imagen });
                }
                lvAlbums.ItemsSource = albumesAMostrar;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool BuscarCanciones()
        {
            try
            {
                var respuesta = clienteCanciones.BuscarCanciones(new Busqueda { Nombre = busqueda });
                var cancionesAMostrar = new List<ElementoListView>();
                foreach (var cancion in respuesta.Canciones)
                {
                    cancionesEncontradas.Add(cancion);
                    var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    cancionesAMostrar.Add(new ElementoListView { IdElemento = cancion.Id, TituloPrincipal = cancion.Nombre, TituloSecundario = cancion.Artista, Ilustracion = imagen });
                }
                lvCanciones.ItemsSource = cancionesAMostrar;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool CargarMenuPlaylists()
        {
            var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
            var menuPlaylists = menuClickDerecho.Items.GetItemAt(menuClickDerecho.Items.Count - 1) as MenuItem;
            try
            {
                var respuesta = clienteListas.ConsultarMisListas(new MnjListas.IdUsuario { Id = ventanaPrincipal.getCuenta().Id });
                foreach (var lista in respuesta.Listas)
                {
                    var nuevaOpcion = new MenuItem();
                    nuevaOpcion.Header = lista.Nombre;
                    nuevaOpcion.Click += AgregarAPlaylist;
                    menuPlaylists.Items.Add(nuevaOpcion);
                    misListas.Add(lista);
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (menuPlaylists.Items.Count == 0)
                {
                    menuClickDerecho.Items.Remove(menuPlaylists);
                }
            }
            return true;
        }

        private void MostrarLista(object sender, MouseButtonEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvListas.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var listaSeleccionada = listasEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerListaReproduccion(listaSeleccionada));
            }
        }

        private void MostrarAlbum(object sender, MouseButtonEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvAlbums.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var albumSeleccionado = albumesEncontrados.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerAlbum(albumSeleccionado));
            }
        }

        private void ReproducirCancion(object sender, MouseButtonEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }

        private void VerMenuClickDerecho(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < lvCanciones.Items.Count; i++)
            {
                var fila = lvCanciones.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver)
                {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvCanciones;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }

        private void AgregarALaCola(object sender, RoutedEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, true, 0);
            }
        }

        private void AgregarAMisMeGusta(object sender, RoutedEventArgs e)
        {
            var listaAA = new ListaAA();
            listaAA.IdLista = ventanaPrincipal.getListaDefault(Propiedades.Default.ListaMeGusta).Id;
            listaAA.Agregar = true;
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarAPlaylist(object sender, RoutedEventArgs e)
        {
            var listaSeleccionada = sender as MenuItem;
            var listaAA = new ListaAA();
            listaAA.IdLista = misListas.Find(l => l.Nombre.Equals(listaSeleccionada.Header.ToString())).Id;
            listaAA.Agregar = true;
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarQuitarCanciones(ListaAA listaAA)
        {
            listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada == null)
            {
                return;
            }
            var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
            listaAA.IdCanciones.Add(cancionSeleccionada.Id);
            try
            {
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerarEstacionRadio(object sender, RoutedEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new EstacionRadio(cancionSeleccionada));
            }
        }

        private void DescargarCanciones(object sender, RoutedEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var cancion = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var album = new Album() { Id = cancion.Album.Id, Nombre = cancion.Album.Nombre };
                var cancionAG = new CancionAG() { IdUsuario = ventanaPrincipal.getCuenta().Id, Cancion = new Cancion() { Id = cancion.Id, Nombre = cancion.Nombre, EsPublica = cancion.EsPublica, Album = album } };
                AdministradorCanciones.DescargarCancion(cancionAG);
            }
        }
    }

}
