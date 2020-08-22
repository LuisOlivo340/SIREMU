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
    public partial class MisListasReproduccion : Page
    {
        private ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);

        private Principal ventanaPrincipal;

        public MisListasReproduccion()
        {
            InitializeComponent();
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            this.CargarListas();
        }

        private void CargarListas()
        {
            var listasAgregadas = new List<ListaReproduccion>();
            var misListas = new List<ListaReproduccion>();
            try
            {
                var respuesta = clienteListas.ConsultarMisListas(new MnjListas.IdUsuario { Id = ventanaPrincipal.getCuenta().Id });
                misListas.AddRange(respuesta.Listas);
                var respuestaAgregadas = clienteListas.ConsultarMisListasAgregadas(new MnjListas.IdUsuario { Id = ventanaPrincipal.getCuenta().Id });
                listasAgregadas.AddRange(respuestaAgregadas.Listas);
                dgMisListas.ItemsSource = misListas;
                dgListasAgregadas.ItemsSource = listasAgregadas;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VerLista(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                var fila = dataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver)
                {
                    var listaSeleccionada = (ListaReproduccion)dataGrid.Items.GetItemAt(i);
                    this.NavigationService.Navigate(new VerListaReproduccion(listaSeleccionada));
                    return;
                }
            }
        }

        private void ReproducirMiLista(object sender, RoutedEventArgs e)
        {
            var lista = (ListaReproduccion)dgMisListas.SelectedItem;
            this.ReproducirCancionesLista(lista);
        }

        private void ReproducirLista(object sender, RoutedEventArgs e)
        {
            var lista = (ListaReproduccion)dgListasAgregadas.SelectedItem;
            this.ReproducirCancionesLista(lista);
        }

        private void ReproducirCancionesLista(ListaReproduccion listaR)
        {
            var canciones = new List<Cancion>();
            try
            {
                var respuesta = clienteCanciones.ConsultarCancionesLista(new IdLista() { Id = listaR.Id});
                canciones.AddRange(respuesta.Canciones);
                ventanaPrincipal.ReproducirCanciones(canciones, false, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VerMenuClickDerecho(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                var fila = dataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (fila.IsMouseOver)
                {
                    dataGrid.SelectedItem = dataGrid.Items.GetItemAt(i);
                    ContextMenu menuClickDerecho;
                    if (dataGrid.Name.Equals("dgMisListas"))
                    {
                        menuClickDerecho = this.FindResource("cmMenuMisListas") as ContextMenu;
                    }
                    else
                    {
                        menuClickDerecho = this.FindResource("cmMenuListasAgregadas") as ContextMenu;
                    }
                    menuClickDerecho.PlacementTarget = dataGrid;
                    menuClickDerecho.IsOpen = true;
                    return;
                }
            }
        }

        private void CrearLista(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrarLista());
        }

        private void EditarLista(object sender, RoutedEventArgs e)
        {
            var lista = (ListaReproduccion)dgMisListas.SelectedItem;
            this.NavigationService.Navigate(new RegistrarLista(lista));
        }

        private void EliminarLista(object sender, RoutedEventArgs e)
        {
            var lista = (ListaReproduccion)dgMisListas.SelectedItem;
            try
            {
                var opcionAlerta = MessageBox.Show("¿Está seguro de que desea eliminar esta playlist?", "Eliminar playlist", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (opcionAlerta == MessageBoxResult.No)
                {
                    return;
                }
                var listaAG = new ListaAG();
                listaAG.IdUsuario = ventanaPrincipal.getCuenta().Id;
                listaAG.ListaAAgregar = new ListaReproduccion() { Id = lista.Id };
                var resultado = clienteListas.EliminarListaReproduccion(listaAG);
                this.NavigationService.Navigate(new MisListasReproduccion());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarListaAgregada(object sender, RoutedEventArgs e)
        {
            var lista = (ListaReproduccion)dgListasAgregadas.SelectedItem;
            try
            {
                var listaAA = new ListaAA();
                listaAA.IdUsuario = ventanaPrincipal.getCuenta().Id;
                listaAA.IdLista = lista.Id;
                listaAA.Agregar = false;
                var resultado = clienteListas.AgregarListaAMeGusta(listaAA);
                this.NavigationService.Navigate(new MisListasReproduccion());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
