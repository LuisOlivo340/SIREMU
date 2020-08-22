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

namespace SiReMu {
    /// <summary>
    /// Lógica de interacción para MenuInicio.xaml
    /// </summary>
    public partial class MenuInicio : Page {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private string busqueda;
        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();
        //private List<ListaReproduccion> listasEncontradas = new List<ListaReproduccion>();
        private List<Cancion> cancionesEncontradas = new List<Cancion>();
        private List<Cancion> cancionesEncontradasPopulares = new List<Cancion>();
        private List<Cancion> cancionesEncontradasAleatorias = new List<Cancion>();
        private List<Cancion> cancionesEncontradasBasado = new List<Cancion>();
        private List<Cancion> cancionesEncontradasHistorial = new List<Cancion>();
        private List<Album> albumesEncontrados = new List<Album>();
        private Principal ventanaPrincipal;

        public MenuInicio(string busqueda) {
            InitializeComponent();
            this.busqueda = busqueda;
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            if (/*!this.BuscarListas() || */!this.BuscarCanciones()/* || !BuscarAlbumes() || !this.CargarMenuPlaylists()*/) {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        ///agregar metdos de reproducir y de clic derecho y 
        private bool BuscarCanciones() {
            try {
                var respuestaPromocion = clienteCanciones.ConsultarCancionesEnPromocion(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });
                var cancionesAMostrar = new List<ElementoListView>();
                foreach (var cancion in respuestaPromocion.Canciones) {
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
                ///////////////////////////////////////////////////////////////
                var respuestaAleatorias = clienteCanciones.ConsultarCancionesAleatorias(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });//ConsultarCancionesEnPromocion(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });
                var cancionesAMostrarAleatorias = new List<ElementoListView>();
                string s = "";
                foreach (var cancion in respuestaAleatorias.Canciones) {
                    cancionesEncontradasAleatorias.Add(cancion);
                    var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    s += cancion.Nombre + " ";
                    cancionesAMostrarAleatorias.Add(new ElementoListView { IdElemento = cancion.Id, TituloPrincipal = cancion.Nombre, TituloSecundario = cancion.Artista, Ilustracion = imagen });
                }
                lvaleatorias.ItemsSource = cancionesAMostrarAleatorias;
                var respuestaCancionesPopulares = clienteCanciones.ConsultarCancionesPopulares(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });//ConsultarCancionesEnPromocion(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });
                var cancionesAMostrarPopulares = new List<ElementoListView>();
                foreach (var cancion in respuestaCancionesPopulares.Canciones) {
                    cancionesEncontradasPopulares.Add(cancion);
                    var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    cancionesAMostrarPopulares.Add(new ElementoListView { IdElemento = cancion.Id, TituloPrincipal = cancion.Nombre, TituloSecundario = cancion.Artista, Ilustracion = imagen });
                }
                lvcancionesPopulares.ItemsSource = cancionesAMostrarPopulares;
                //
                var respuesta = clienteCanciones.ConsultarAlbumsPopulares(new MnjCanciones.IdUsuario() { Id = ventanaPrincipal.getCuenta().Id });//.BuscarAlbumes(new Busqueda { Nombre = busqueda });
                var albumesAMostrar = new List<ElementoListView>();
                foreach (var album in respuesta.Albums) {
                    albumesEncontrados.Add(album);
                    var stream = new MemoryStream(album.Ilustracion.ToByteArray());
                    var imagen = new BitmapImage();
                    imagen.BeginInit();
                    imagen.CacheOption = BitmapCacheOption.OnLoad;
                    imagen.StreamSource = stream;
                    imagen.EndInit();
                    albumesAMostrar.Add(new ElementoListView { IdElemento = album.Id, TituloPrincipal = album.Nombre, TituloSecundario = album.NombreCreador, Ilustracion = imagen });
                }
                lvalbumsPopulares.ItemsSource = albumesAMostrar;
                //
                ///////////////////////////////////////////////////////////////
                var respuestaHistorial = clienteCanciones.ConsultarCancionesLista(new IdLista() { Id = ventanaPrincipal.getListaDefault("Mi historial").Id });
                if (respuestaHistorial.Canciones.Count == 0) {
                    lvvolver.Visibility = Visibility.Hidden;
                    volverSC.Visibility = Visibility.Hidden;
                    volverLB.Visibility = Visibility.Hidden;
                } else {
                    var cancionesAMostrarHistorial = new List<ElementoListView>();
                    int i = 0;
                    foreach (var cancion in respuestaHistorial.Canciones) {
                        i++;
                        if (i > 6) {
                            break;
                        }
                        cancionesEncontradasHistorial.Add(cancion);
                        var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = stream;
                        imagen.EndInit();
                        cancionesAMostrarHistorial.Add(new ElementoListView { IdElemento = cancion.Id, TituloPrincipal = cancion.Nombre, TituloSecundario = cancion.Artista, Ilustracion = imagen });
                    }
                    lvvolver.ItemsSource = cancionesAMostrarHistorial;
                }
                try {
                    var respuestaRadio = clienteCanciones.GenerarRadio(new Cancion { Id = respuestaHistorial.Canciones.First().Id, Nombre = respuestaHistorial.Canciones.First().Nombre, Genero = respuestaHistorial.Canciones.First().Genero });
                    var cancionesAMostrarRadio = new List<ElementoListView>();
                    foreach (var cancion in respuestaRadio.Canciones) {
                        cancionesEncontradasBasado.Add(cancion);
                        var stream = new MemoryStream(cancion.Album.Ilustracion.ToByteArray());
                        var imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.StreamSource = stream;
                        imagen.EndInit();
                        cancionesAMostrarRadio.Add(new ElementoListView { IdElemento = cancion.Id, TituloPrincipal = cancion.Nombre, TituloSecundario = cancion.Artista, Ilustracion = imagen });
                    }
                    lvbasado.ItemsSource = cancionesAMostrarRadio;
                } catch (System.InvalidOperationException ex) {
                    Console.WriteLine("Error: " + ex.Message);
                    lvbasado.Visibility = Visibility.Hidden;
                    basadoSC.Visibility = Visibility.Hidden;
                    basadoLB.Visibility = Visibility.Hidden;
                    return true;
                }
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return true;
        }

        private void MostrarLista(object sender, MouseButtonEventArgs e) {
            /*var celdaSeleccionada = (ElementoListView)lvListas.SelectedItem;
            if (celdaSeleccionada != null) {
                var listaSeleccionada = listasEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerListaReproduccion(listaSeleccionada));
            }*/
        }

        private void MostrarAlbum(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvalbumsPopulares.SelectedItem;
            if (celdaSeleccionada != null) {
                var albumSeleccionado = albumesEncontrados.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new VerAlbum(albumSeleccionado));
            }
        }

        private void ReproducirCancion(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }

        private void ReproducirCancionPopulares(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvcancionesPopulares.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradasPopulares.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }
        private void ReproducirCancionAleatorio(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvaleatorias.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradasAleatorias.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }
        private void ReproducirCancionBasado(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvbasado.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradasBasado.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }
        private void ReproducirCancionHistorial(object sender, MouseButtonEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvvolver.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradasHistorial.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, false, 0);
            }
        }

        private void VerMenuClickDerecho(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < lvCanciones.Items.Count; i++) {
                var fila = lvCanciones.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver) {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvCanciones;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }
        private void VerMenuClickDerechoPopulares(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < lvcancionesPopulares.Items.Count; i++) {
                var fila = lvcancionesPopulares.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver) {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvcancionesPopulares;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }
        private void VerMenuClickDerechoAleatorias(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < lvaleatorias.Items.Count; i++) {
                var fila = lvaleatorias.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver) {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvaleatorias;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }
        private void VerMenuClickDerechoBasado(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < lvbasado.Items.Count; i++) {
                var fila = lvbasado.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver) {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvbasado;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }
        private void VerMenuClickDerechoHistorial(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < lvvolver.Items.Count; i++) {
                var fila = lvvolver.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (fila.IsMouseOver) {
                    fila.IsSelected = true;
                    var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = lvvolver;
                    menuClickDerecho.IsOpen = true;
                    break;
                }
            }
        }

        private void AgregarALaCola(object sender, RoutedEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var listaCanciones = new List<Cancion>();
                listaCanciones.Add(cancionSeleccionada);
                ventanaPrincipal.ReproducirCanciones(listaCanciones, true, 0);
            }
        }

        private void AgregarAMisMeGusta(object sender, RoutedEventArgs e) {
            var listaAA = new ListaAA();
            listaAA.IdLista = ventanaPrincipal.getListaDefault(Propiedades.Default.ListaMeGusta).Id;
            listaAA.Agregar = true;
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarAPlaylist(object sender, RoutedEventArgs e) {
            var listaSeleccionada = sender as MenuItem;
            var listaAA = new ListaAA();
            listaAA.IdLista = misListas.Find(l => l.Nombre.Equals(listaSeleccionada.Header.ToString())).Id;
            listaAA.Agregar = true;
            this.AgregarQuitarCanciones(listaAA);
        }

        private void AgregarQuitarCanciones(ListaAA listaAA) {
            listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada == null) {
                return;
            }
            var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
            listaAA.IdCanciones.Add(cancionSeleccionada.Id);
            try {
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
            } catch (Exception) {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerarEstacionRadio(object sender, RoutedEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancionSeleccionada = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                this.NavigationService.Navigate(new EstacionRadio(cancionSeleccionada));
            }
        }

        private void DescargarCanciones(object sender, RoutedEventArgs e) {
            var celdaSeleccionada = (ElementoListView)lvCanciones.SelectedItem;
            if (celdaSeleccionada != null) {
                var cancion = cancionesEncontradas.Find(l => l.Id == celdaSeleccionada.IdElemento);
                var album = new Album() { Id = cancion.Album.Id, Nombre = cancion.Album.Nombre };
                var cancionAG = new CancionAG() { IdUsuario = ventanaPrincipal.getCuenta().Id, Cancion = new Cancion() { Id = cancion.Id, Nombre = cancion.Nombre, Album = album } };
                AdministradorCanciones.DescargarCancion(cancionAG);
            }
        }
    }

}
