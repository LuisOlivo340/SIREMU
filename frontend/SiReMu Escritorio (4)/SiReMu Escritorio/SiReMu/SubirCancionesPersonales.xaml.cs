using Google.Protobuf;
using Microsoft.Win32;
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
    public partial class SubirCancionesPersonales : Page
    {
        private List<CancionPP> cancionesElegidas = new List<CancionPP>();
        private Stream imgStream;
        private string extensionImagen;

        public SubirCancionesPersonales()
        {
            InitializeComponent();
            dgCanciones.ItemsSource = cancionesElegidas;
        }

        private void CargarCanciones(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            openFileDialog.Filter = "Archivos de áudio (*.aac *.mp3 *.m4a *.wav *.wma)|*.AAC;*.MP3;*.M4A;*.WAV;*.WMA";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Seleccione las canciones a subir";
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            try
            {
                if ((bool)openFileDialog.ShowDialog())
                {
                    this.CargarCanciones(openFileDialog.FileNames);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la canción. Inténtelo de nuevo.", "Error al cargar el archivo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCanciones(string[] archivos)
        {
            cancionesElegidas.Clear();
            var ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            int miId = ventanaPrincipal.getCuenta().Id;
            foreach (var archivo in archivos)
            {
                var tfile = TagLib.File.Create(archivo);
                if (!cancionesElegidas.Any(x => x.Cancion.Nombre.Equals(CambiarVacio(tfile.Tag.Title)))) 
                {
                    var album = new Album() { Nombre = CambiarVacio(tfile.Tag.Album), Compania = CambiarVacio(tfile.Tag.Publisher), EsPublico = false, FechaLanzamiento = CambiarFecha(tfile.Tag.Year) };
                    var cancion = new Cancion() { Nombre = CambiarVacio(tfile.Tag.Title), Genero = CambiarVacio(tfile.Tag.FirstGenre), Artista = CambiarVacio(tfile.Tag.FirstPerformer), Duracion = tfile.Properties.Duration.ToString(@"mm\:ss"), EsPublica = false, Album = album };
                    cancionesElegidas.Add(new CancionPP { IdUsuario = miId, Cancion = cancion, Extensionarchivo = archivo });
                }   
            }
            dgCanciones.Items.Refresh();
        }

        private void SubirCanciones(object sender, RoutedEventArgs e)
        {
            if (cancionesElegidas.Count == 0)
            {
                MessageBox.Show("No hay canciones cargadas para subirlas al servidor.", "No hay canciones cargadas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (imgStream == null)
            {
                MessageBox.Show("Es obligatorio elegir una imagen ya que se usará como la portada de los albumes de las canciones cargadas.", "Falta la imagen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            imgStream.Position = 0;
            ByteString imagenGRPC = ByteString.FromStream(imgStream);
            imgStream.Dispose();
            foreach (var cancion in cancionesElegidas)
            {
                cancion.Cancion.Album.Ilustracion = imagenGRPC;
                cancion.Cancion.Album.ExtensionIlustracion = extensionImagen;
                AdministradorCanciones.SubirCancionPersonal(cancion);
                this.NavigationService.Navigate(new MisCanciones());
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

        private string CambiarVacio(string dato)
        {
            if (dato == null)
            {
                dato = "Desconocido";
            }
            return dato;
        }

        private string CambiarFecha(uint anio)
        {
            string fechaLanzamiento;
            if (anio == 0 || anio > DateTime.Now.Year)
            {
                fechaLanzamiento = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                fechaLanzamiento = anio + "-01-01";
            }
            return fechaLanzamiento;
        }
    }
}
