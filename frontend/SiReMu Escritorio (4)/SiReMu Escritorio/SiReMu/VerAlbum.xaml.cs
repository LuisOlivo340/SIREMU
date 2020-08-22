using MaterialDesignThemes.Wpf;
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
    public partial class VerAlbum : Page
    {
        private ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private Album miAlbum;
        private Principal ventanaPrincipal;
        private List<Cancion> listaCanciones = new List<Cancion>();
        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();

        public VerAlbum(Album album)
        {
            InitializeComponent();
            this.miAlbum = album;
            dgCanciones.ItemsSource = listaCanciones;
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            this.MostrarDatos();
            this.CargarCanciones();
            if (album.IdCreador == ventanaPrincipal.getCuenta().Id)
            {
                this.CargarMenuSecundarioMiAlbum();
                this.CargarMenuOpcionesMiAlbum();
            }
            this.CargarMenuPlaylists();
        }

        private void MostrarDatos()
        {
            lbAlbum.Content = miAlbum.Nombre;
            lbCreador.Content = miAlbum.NombreCreador;
            lbCompañia.Content = miAlbum.Compania;
            lbLanzamiento.Content = "Lanzado en: " + miAlbum.FechaLanzamiento;
            var stream = new MemoryStream(miAlbum.Ilustracion.ToByteArray());
            var imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.CacheOption = BitmapCacheOption.OnLoad;
            imagen.StreamSource = stream;
            imagen.EndInit();
            imgIlustracion.Source = imagen;
        }

        private void CargarCanciones()
        {
            try
            {
                listaCanciones.Clear();
                var respuesta = clienteCanciones.ConsultarCancionesAlbum(new Album() { Id = miAlbum.Id });
                foreach (var cancion in respuesta.Canciones)
                {
                    cancion.Album = miAlbum;
                    listaCanciones.Add(cancion);
                }
                dgCanciones.Items.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (listaCanciones.Count == 0)
            {
                btReproducir.IsEnabled = false;
                var menuOpciones = this.FindResource("cmMenuOpciones") as ContextMenu;
                var opcionCola = menuOpciones.Items.GetItemAt(0) as MenuItem;
                opcionCola.IsEnabled = false;
            }
        }

        private void CargarMenuPlaylists()
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
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (menuPlaylists.Items.Count == 0)
            {
                menuClickDerecho.Items.Remove(menuPlaylists);
            }
        }

        private void CargarMenuSecundarioMiAlbum()
        {
            var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
            var nuevaOpcion = new MenuItem();
            nuevaOpcion.Header = "Eliminar del álbum";
            nuevaOpcion.Icon = new PackIcon { Kind = PackIconKind.Delete, Foreground = System.Windows.Media.Brushes.White };
            nuevaOpcion.Click += EliminarCancionesAlbum;
            menuClickDerecho.Items.Insert(menuClickDerecho.Items.Count - 1, nuevaOpcion);
        }

        private void CargarMenuOpcionesMiAlbum()
        {
            var menuOpciones = this.FindResource("cmMenuOpciones") as ContextMenu;
            var nuevaOpcion = new MenuItem();
            nuevaOpcion.Header = "Eliminar";
            nuevaOpcion.Click += EliminarAlbum;
            nuevaOpcion.Icon = new PackIcon { Kind = PackIconKind.Delete, Foreground = System.Windows.Media.Brushes.White };
            menuOpciones.Items.Add(nuevaOpcion);
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
            ventanaPrincipal.ReproducirCanciones(listaCanciones, false, indiceSeleccionado);
        }

        private void ReproducirAlbum(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
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
                    return;
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
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarAPlaylist(object sender, RoutedEventArgs e)
        {
            var listaSeleccionada = sender as MenuItem;
            var listaAA = new ListaAA();
            listaAA.IdLista = misListas.Find(l => l.Nombre.Equals(listaSeleccionada.Header.ToString())).Id;
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarQuitarCanciones(ListaAA listaAA)
        {
            listaAA.Agregar = true;
            listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
            foreach (var cancion in dgCanciones.SelectedItems.Cast<Cancion>())
            {
                listaAA.IdCanciones.Add(cancion.Id);
            }
            try
            {
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
                if (!respuesta.Respuesta)
                {
                    MessageBox.Show("Error al conectar con la base de datos de SiReMu.", "Error" + respuesta.CodigoError, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarCancionesAlbum(object sender, RoutedEventArgs e)
        {
            
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

        private void MostrarOpciones(object sender, RoutedEventArgs e)
        {
            var menuClickDerecho = this.FindResource("cmMenuOpciones") as ContextMenu;
            menuClickDerecho.PlacementTarget = btOpciones;
            menuClickDerecho.IsOpen = true;
        }

        private void AgregarAlbumALaCola(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.ReproducirCanciones(listaCanciones, true, 0);
        }

        private void EliminarAlbum(object sender, RoutedEventArgs e)
        {

        }
    }
}
