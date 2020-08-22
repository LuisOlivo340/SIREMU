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
    public partial class MisCanciones : Page
    {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private List<Cancion> cancionesEncontradas = new List<Cancion>();
        private List<Cancion> listaOriginal = new List<Cancion>();
        private List<ElementoListView> albumsAMostrar = new List<ElementoListView>();
        private Principal ventanaPrincipal;
        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();

        public MisCanciones()
        {
            InitializeComponent();
            dgCanciones.ItemsSource = cancionesEncontradas;
            lvAlbums.ItemsSource = albumsAMostrar;
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            if (!this.CargarCanciones() || !this.CargarMenuPlaylists())
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CargarCanciones()
        {
            List<string> artistas = new List<string>();
            List<string> generos = new List<string>();
            cancionesEncontradas.Clear();
            try
            {
                var respuesta = clienteCanciones.ConsultarMisCanciones(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });
                foreach (var cancion in respuesta.Canciones)
                {
                    cancionesEncontradas.Add(cancion);
                    if (!albumsAMostrar.Any(x => x.IdElemento == cancion.Album.Id))
                    {
                        var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = stream;
                        imagen.EndInit();
                        albumsAMostrar.Add(new ElementoListView { IdElemento = cancion.Album.Id, TituloPrincipal = cancion.Album.Nombre, TituloSecundario = cancion.Album.Compania, Ilustracion = imagen });
                    }
                    if (!artistas.Any(x => x.Equals(cancion.Artista)))
                    {
                        artistas.Add(cancion.Artista);
                    }
                    if (!generos.Any(x => x.Equals(cancion.Genero)))
                    {
                        generos.Add(cancion.Genero);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cancionesEncontradas.Count == 0)
                {
                    btReproducir.IsEnabled = false;
                }
            }
            listaOriginal.AddRange(cancionesEncontradas);
            dgCanciones.Items.Refresh();
            lvAlbums.Items.Refresh();
            artistas.Sort();
            artistas.Insert(0, "Todos");
            cbArtistas.ItemsSource = artistas;
            cbArtistas.SelectedIndex = 0;
            cbArtistas.SelectionChanged += FiltrarCanciones;
            generos.Sort();
            generos.Insert(0, "Todos");
            cbGeneros.ItemsSource = generos;
            cbGeneros.SelectedIndex = 0;
            cbGeneros.SelectionChanged += FiltrarCanciones;
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

        private void ReproducirEstacion(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.ReproducirCanciones(cancionesEncontradas, false, 0);
        }

        private void ReproducirCancion(object sender, RoutedEventArgs e)
        {
            int indiceSeleccionado = 0;
            for (int i = 0; i < dgCanciones.Items.Count; i++)
            {
                var fila = dgCanciones.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver && fila.IsSelected)
                {
                    indiceSeleccionado = fila.GetIndex();
                    break;
                }
            }
            ventanaPrincipal.ReproducirCanciones(cancionesEncontradas, false, indiceSeleccionado);
        }

        private void VerMenuClickDerecho(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < dgCanciones.Items.Count; i++)
            {
                var fila = dgCanciones.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver && !fila.IsSelected)
                {
                    dgCanciones.SelectedItems.Clear();
                    fila.IsSelected = true;
                }
                if (fila.IsMouseOver && fila.IsSelected)
                {
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = dgCanciones;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }

        private void AgregarALaCola(object sender, RoutedEventArgs e)
        {
            var listaTemporal = dgCanciones.SelectedItems.Cast<Cancion>().ToList();
            ventanaPrincipal.ReproducirCanciones(listaTemporal, true, 0);
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
            foreach (var cancion in dgCanciones.SelectedItems.Cast<Cancion>())
            {
                listaAA.IdCanciones.Add(cancion.Id);
            }
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
            var cancionElegida = (Cancion)dgCanciones.SelectedItem;
            if (cancionElegida != null)
            {
                this.NavigationService.Navigate(new EstacionRadio(cancionElegida));
            }
        }

        private void DescargarCanciones(object sender, RoutedEventArgs e)
        {
            foreach (var cancion in dgCanciones.SelectedItems.Cast<Cancion>())
            {
                var album = new Album() { Id = cancion.Album.Id, Nombre = cancion.Album.Nombre };
                var cancionAG = new CancionAG() { IdUsuario = ventanaPrincipal.getCuenta().Id, Cancion = new Cancion() { Id = cancion.Id, Nombre = cancion.Nombre, EsPublica = cancion.EsPublica, Album = album } };
                AdministradorCanciones.DescargarCancion(cancionAG);
            }
        }

        private void VerAlbumes(object sender, RoutedEventArgs e)
        {
            if (btVerAlbumes.Content.Equals("Albums"))
            {
                dgCanciones.Visibility = Visibility.Collapsed;
                lvAlbums.Visibility = Visibility.Visible;
                btVerAlbumes.Content = "Canciones";
                panelCanciones.Visibility = Visibility.Collapsed;
            }
            else
            {
                lvAlbums.Visibility = Visibility.Collapsed;
                dgCanciones.Visibility = Visibility.Visible;
                btVerAlbumes.Content = "Albums";
                panelCanciones.Visibility = Visibility.Visible;
            }
        }

        private void FiltrarCanciones(object sender, SelectionChangedEventArgs e)
        {
            cancionesEncontradas.Clear();
            if (cbArtistas.SelectedItem.ToString().Equals("Todos") && cbGeneros.SelectedItem.ToString().Equals("Todos"))
            {
                cancionesEncontradas.AddRange(listaOriginal);
            }
            else if (cbArtistas.SelectedItem.ToString().Equals("Todos"))
            {
                cancionesEncontradas.AddRange(listaOriginal.Where(x => x.Genero.Equals(cbGeneros.SelectedItem.ToString())));
            }
            else if (cbGeneros.SelectedItem.ToString().Equals("Todos"))
            {
                cancionesEncontradas.AddRange(listaOriginal.Where(x => x.Artista.Equals(cbArtistas.SelectedItem.ToString())));
            }
            else
            {
                cancionesEncontradas.AddRange(listaOriginal.Where(x => x.Artista.Equals(cbArtistas.SelectedItem.ToString()) && x.Genero.Equals(cbGeneros.SelectedItem.ToString())));
            }
            dgCanciones.Items.Refresh();
        }

        private void SubirCancionesPersonales(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SubirCancionesPersonales());
        }

        private void MostrarAlbum(object sender, MouseButtonEventArgs e)
        {
            var celdaSeleccionada = (ElementoListView)lvAlbums.SelectedItem;
            if (celdaSeleccionada != null)
            {
                var cancion = cancionesEncontradas.Find(l => l.Album.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerAlbum(cancion.Album));
            }
        }
    }
}
