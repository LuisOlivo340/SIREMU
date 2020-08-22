using Grpc.Core;
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
    public partial class VerListaReproduccion : Page
    {
        private ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);

        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();
        private List<Cancion> listaCanciones = new List<Cancion>();
        private ListaReproduccion listaReproduccion;
        private Principal ventanaPrincipal;

        public VerListaReproduccion(ListaReproduccion listaR)
        {
            InitializeComponent();
            this.listaReproduccion = listaR;
            dgCanciones.ItemsSource = listaCanciones;
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            this.MostrarDatosLista();
            this.CargarCanciones();
            if (ventanaPrincipal.getListaDefault(listaReproduccion.Id) != null || listaReproduccion.IdCreador == ventanaPrincipal.getCuenta().Id)
            {
                this.CargarMenuMiLista();
                this.CargarMenuOpcionesMiLista();
            }
            this.CargarMenuPlaylists();
        }

        private void MostrarDatosLista()
        {
            lbLista.Content = listaReproduccion.Nombre;
            if (listaReproduccion.EsDefault)
            {
                btOpciones.Visibility = Visibility.Collapsed;
                return;
            }
            var stream = new MemoryStream(listaReproduccion.Ilustracion.ToByteArray());
            var imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.CacheOption = BitmapCacheOption.OnLoad;
            imagen.StreamSource = stream;
            imagen.EndInit();
            imgIlustracion.Source = imagen;
            lbAutor.Content = listaReproduccion.NombreCreador;
            lbLikes.Content = "Likes: " + listaReproduccion.Likes;
            tbDescripcion.Text = listaReproduccion.Descripcion;
        }

        private void CargarCanciones()
        {
            try
            {
                listaCanciones.Clear();
                var respuesta = clienteCanciones.ConsultarCancionesLista(new IdLista() { Id = listaReproduccion.Id, IdUsuario = ventanaPrincipal.getCuenta().Id });
                listaCanciones.AddRange(respuesta.Canciones);
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
                    if (lista.Id != listaReproduccion.Id)
                    {
                        var nuevaOpcion = new MenuItem();
                        nuevaOpcion.Header = lista.Nombre;
                        nuevaOpcion.Click += AgregarAPlaylist;
                        menuPlaylists.Items.Add(nuevaOpcion);
                        misListas.Add(lista);
                    }
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

        private void CargarMenuMiLista()
        {
            var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
            var nuevaOpcion = new MenuItem();
            if (listaReproduccion.Id == ventanaPrincipal.getListaDefault(Propiedades.Default.ListaMeGusta).Id)
            {
                nuevaOpcion.Header = "Ya no me gusta";
                nuevaOpcion.Icon = new PackIcon { Kind = PackIconKind.HeartBroken, Foreground = System.Windows.Media.Brushes.White };
                menuClickDerecho.Items.RemoveAt(2);
            }
            else
            {
                nuevaOpcion.Header = "Quitar de la lista";
                nuevaOpcion.Icon = new PackIcon { Kind = PackIconKind.Delete, Foreground = System.Windows.Media.Brushes.White };
            }
            nuevaOpcion.Click += QuitarCancionesDeLaLista;
            menuClickDerecho.Items.Insert(menuClickDerecho.Items.Count - 1, nuevaOpcion);
        }

        private void CargarMenuOpcionesMiLista()
        {
            if (listaReproduccion.EsDefault)
            {
                return;
            }
            var menuOpciones = this.FindResource("cmMenuOpciones") as ContextMenu;
            menuOpciones.Items.RemoveAt(menuOpciones.Items.Count - 1);
            var nuevaOpcion = new MenuItem();
            nuevaOpcion.Header = "Editar";
            nuevaOpcion.Click += EditarLista;
            nuevaOpcion.Icon = new PackIcon { Kind = PackIconKind.Edit, Foreground = System.Windows.Media.Brushes.White };
            menuOpciones.Items.Add(nuevaOpcion);
            nuevaOpcion = new MenuItem();
            nuevaOpcion.Header = "Eliminar";
            nuevaOpcion.Click += EliminarLista;
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

        private void ReproducirLista(object sender, RoutedEventArgs e)
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

        private void QuitarCancionesDeLaLista(object sender, RoutedEventArgs e)
        {
            var listaAA = new ListaAA();
            listaAA.IdLista = listaReproduccion.Id;
            listaAA.Agregar = false;
            this.AgregarQuitarCanciones(listaAA);
            this.NavigationService.Navigate(new VerListaReproduccion(listaReproduccion));
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

        private void MostrarOpciones(object sender, RoutedEventArgs e)
        {
            var menuClickDerecho = this.FindResource("cmMenuOpciones") as ContextMenu;
            menuClickDerecho.PlacementTarget = btOpciones;
            menuClickDerecho.IsOpen = true;
        }

        private void AgregarListaALaCola(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.ReproducirCanciones(listaCanciones, true, 0);
        }

        private void AgregaListaAMisMeGusta(object sender, RoutedEventArgs e)
        {
            var listaAA = new ListaAA();
            listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
            listaAA.IdLista = listaReproduccion.Id;
            listaAA.Agregar = true;
            try
            {
                var respuesta = clienteListas.AgregarListaAMeGusta(listaAA);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditarLista(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrarLista(listaReproduccion));
        }

        private void EliminarLista(object sender, RoutedEventArgs e)
        {
            try
            {
                var opcionAlerta = MessageBox.Show("¿Está seguro de que desea eliminar esta playlist?", "Eliminar playlist", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (opcionAlerta == MessageBoxResult.No)
                {
                    return;
                }
                var listaAG = new ListaAG();
                listaAG.IdUsuario = ventanaPrincipal.getCuenta().Id;
                listaAG.ListaAAgregar = new ListaReproduccion() { Id = listaReproduccion.Id };
                var resultado = clienteListas.EliminarListaReproduccion(listaAG);
                this.NavigationService.Navigate(new MisListasReproduccion());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
