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
    public partial class ColaDeReproduccion : Page
    {
        private ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private List<ListaReproduccion> misListas = new List<ListaReproduccion>();
        private List<Cancion> todasLasCanciones = new List<Cancion>();
        private Principal ventanaPrincipal;

        public ColaDeReproduccion(List<Cancion> listaCanciones, int indiceCancionActual)
        {
            InitializeComponent();
            if (listaCanciones == null)
            {
                return;
            }
            this.todasLasCanciones.AddRange(listaCanciones);
            dgCanciones.ItemsSource = todasLasCanciones.GetRange(indiceCancionActual + 1, listaCanciones.Count - indiceCancionActual - 1);
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            dgCancionActual.ItemsSource = todasLasCanciones.GetRange(indiceCancionActual, 1);
            this.CargarMenuPlaylists();
        }

        private void CargarMenuPlaylists()
        {
            var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
            var menuCancionActual = this.FindResource("cmCancionActual") as ContextMenu;
            var menuPlaylistsCancionActual = menuCancionActual.Items.GetItemAt(menuCancionActual.Items.Count - 1) as MenuItem;
            var menuPlaylists = menuClickDerecho.Items.GetItemAt(menuClickDerecho.Items.Count - 1) as MenuItem;
            try
            {
                var respuesta = clienteListas.ConsultarMisListas(new MnjListas.IdUsuario { Id = ventanaPrincipal.getCuenta().Id });
                foreach (var lista in respuesta.Listas)
                {
                    var nuevaOpcion = new MenuItem();
                    nuevaOpcion.Header = lista.Nombre;
                    nuevaOpcion.Click += AgregarAPlaylist;
                    var nuevaOpcionRepetida = new MenuItem();
                    nuevaOpcionRepetida.Header = lista.Nombre;
                    nuevaOpcionRepetida.Click += AgregarAPlaylist;
                    menuPlaylists.Items.Add(nuevaOpcion);
                    menuPlaylistsCancionActual.Items.Add(nuevaOpcionRepetida);
                    misListas.Add(lista);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReproducirCancion(object sender, RoutedEventArgs e)
        {
            int indiceSeleccionada = 0;
            for (int i = 0; i < dgCanciones.Items.Count; i++)
            {
                var fila = dgCanciones.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver && fila.IsSelected)
                {
                    indiceSeleccionada = fila.GetIndex() + todasLasCanciones.Count - dgCanciones.Items.Count;
                    break;
                }
            }
            ventanaPrincipal.ReproducirCanciones(todasLasCanciones, false, indiceSeleccionada);
        }

        private void SacarDeLaLista(object sender, RoutedEventArgs e)
        {
            List<int> indicesSeleccionados = new List<int>();
            for (int i = 0; i < dgCanciones.Items.Count; i++)
            {
                var fila = dgCanciones.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsSelected)
                {
                    indicesSeleccionados.Add(fila.GetIndex() + todasLasCanciones.Count - dgCanciones.Items.Count);
                }
            }
            ventanaPrincipal.SacarDeLaColaDeReproduccion(indicesSeleccionados);
        }

        private void VerMenuClickDerecho(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                var fila = dataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver && !fila.IsSelected)
                {
                    dataGrid.SelectedItems.Clear();
                    fila.IsSelected = true;
                }
                if (fila.IsMouseOver && fila.IsSelected)
                {
                    ContextMenu menuClickDerecho;
                    menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
                    menuClickDerecho.PlacementTarget = dataGrid;
                    menuClickDerecho.IsOpen = true;
                    return;
                }
            }
        }

        private void VerClickDerechoCancion(object sender, MouseButtonEventArgs e)
        {
            var fila = dgCancionActual.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
            if (fila.IsMouseOver)
            {
                ContextMenu menuClickDerecho;
                menuClickDerecho = this.FindResource("cmCancionActual") as ContextMenu;
                menuClickDerecho.PlacementTarget = dgCancionActual;
                menuClickDerecho.IsOpen = true;
                return;
            }
        }

        private void AgregarAMeGusta(object sender, RoutedEventArgs e)
        {
            var opcionSeleccionada = sender as MenuItem;
            var idLista = ventanaPrincipal.getListaDefault(Propiedades.Default.ListaMeGusta).Id;
            this.AgregarCancionesALista(idLista, opcionSeleccionada);
        }

        private void AgregarAPlaylist(object sender, RoutedEventArgs e)
        {
            var opcionSeleccionada = sender as MenuItem;
            var menuCancionActual = this.FindResource("cmCancionActual") as ContextMenu;
            var menuClickDerecho = this.FindResource("cmClickDerecho") as ContextMenu;
            var opcionPlaylist = menuCancionActual.Items.GetItemAt(menuCancionActual.Items.Count - 1) as MenuItem;
            var menuPlaylists = menuClickDerecho.Items.GetItemAt(menuClickDerecho.Items.Count - 1) as MenuItem;
            MenuItem opcionAEnviar;
            if (opcionPlaylist.Items.Contains(opcionSeleccionada))
            {
                opcionAEnviar = opcionPlaylist;
            }
            else
            {
                opcionAEnviar = menuPlaylists;
            }
            var idLista = misListas.Find(l => l.Nombre.Equals(opcionSeleccionada.Header.ToString())).Id;
            this.AgregarCancionesALista(idLista, opcionAEnviar);
        }

        private void AgregarCancionesALista(int idLista, MenuItem opcionSeleccionada)
        {
            DataGrid dataGrid;
            var menuCancionActual = this.FindResource("cmCancionActual") as ContextMenu;
            if (menuCancionActual.Items.Contains(opcionSeleccionada))
            {
                dataGrid = dgCancionActual;
            }
            else
            {
                dataGrid = dgCanciones;
            }
            var listaAA = new ListaAA();
            listaAA.IdLista = idLista;
            listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
            listaAA.Agregar = true;
            if (dataGrid.Name.Equals("dgCancionActual"))
            {
                var cancion = (Cancion)dataGrid.Items.GetItemAt(0);
                listaAA.IdCanciones.Add(cancion.Id);
            }
            else
            {
                foreach (var cancion in dataGrid.SelectedItems.Cast<Cancion>())
                {
                    listaAA.IdCanciones.Add(cancion.Id);
                }
            }
            try
            {
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
                if (!respuesta.Respuesta)
                {
                    MessageBox.Show("Error al agregar la(s) canciones.", "Error" + respuesta.CodigoError, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
