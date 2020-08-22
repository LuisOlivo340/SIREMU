using MnjCanciones;
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
    public partial class MusicaDescargada : Page
    {
        private string direccionMusicaDescargada;
        private List<Cancion> cancionesDescargadas = new List<Cancion>();
        private Principal ventanaPrincipal;

        public MusicaDescargada()
        {
            InitializeComponent();
            ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            dgCanciones.ItemsSource = cancionesDescargadas;
            direccionMusicaDescargada = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Propiedades.Default.CarpetaMusicaDescargada;
            this.VerificarCarpetaMusica();
            this.MostrarMusicaDescargada();
        }

        private void VerificarCarpetaMusica()
        {
            try
            {
                if (!Directory.Exists(direccionMusicaDescargada))
                {
                    Directory.CreateDirectory(direccionMusicaDescargada);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MostrarMusicaDescargada()
        {
            cancionesDescargadas.Clear();
            List<string> archivosMusica = new List<string>();
            try
            {
                archivosMusica.AddRange(Directory.GetFiles(direccionMusicaDescargada, "*.*", SearchOption.AllDirectories));
                foreach (var archivo in archivosMusica)
                {
                    var tfile = TagLib.File.Create(archivo);
                    var album = new Album() { Nombre = tfile.Tag.Album, ExtensionIlustracion = System.IO.Path.GetExtension(archivo) };
                    var cancion = new Cancion() { Nombre = tfile.Tag.Title, Genero = tfile.Tag.FirstGenre, Artista = tfile.Tag.FirstPerformer, Duracion = tfile.Properties.Duration.ToString(@"mm\:ss"), Album = album };
                    var carpeta = Directory.GetParent(archivo).Parent;
                    if (!carpeta.Name.Equals("Personales"))
                    {
                        cancion.EsPublica = true;
                    }
                    cancionesDescargadas.Add(cancion);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vuelva a entrar e inténtelo de nuevo.", "Error al cargar las canciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dgCanciones.Items.Refresh();
        }

        private void ReproducirMusica(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.ReproducirCanciones(cancionesDescargadas, false, 0);
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
            ventanaPrincipal.ReproducirCanciones(cancionesDescargadas, false, indiceSeleccionado);
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

        private void EliminarCanciones(object sender, RoutedEventArgs e)
        {
            string direccionArchivo;
            try
            {
                foreach (var cancion in dgCanciones.SelectedItems.Cast<Cancion>())
                {
                    direccionArchivo = direccionMusicaDescargada + "\\" + cancion.Album.Nombre + "\\" + cancion.Nombre + cancion.Album.ExtensionIlustracion;
                    if (File.Exists(direccionArchivo))
                    {
                        File.Delete(direccionArchivo);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vuelva a entrar e inténtelo de nuevo.", "Error al eliminar las canciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.NavigationService.Navigate(new MusicaDescargada());
        }
    }
}
