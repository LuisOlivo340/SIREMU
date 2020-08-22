using Google.Protobuf;
using Grpc.Core;
using Microsoft.Win32;
using MnjCanciones;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class SubirCancion : Page
    {
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private Stream archivoStream;
        private string extensionArchivo;
        private string rutaArchivo;
        private int miId;
        private List<Album> misAlbumes = new List<Album>();

        public SubirCancion()
        {
            InitializeComponent();
            var ventanaPrincipal = Application.Current.Windows.OfType<Principal>().FirstOrDefault();
            this.miId = ventanaPrincipal.getCuenta().Id;
            this.CargarAlbumes();
            cbGeneros.ItemsSource = GenerosMusicales.getGenerosMusicales();
            cbGeneros.SelectedIndex = 0;
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MisAlbumes());
        }

        private void CargarAlbumes()
        {
            try
            {
                var listaAlbums = clienteCanciones.ConsultarAlbums(new IdUsuario { Id = miId });
                misAlbumes.AddRange(listaAlbums.Albums);
                foreach (var album in misAlbumes)
                {
                    cbAlbumes.Items.Add(album.Nombre);
                }
                if (misAlbumes.Count == 0)
                {
                    MessageBox.Show("Necesita tener algún álbum creado para subir una canción a él.", "No tiene álbumes creados", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    cbAlbumes.SelectedItem = misAlbumes.First().Nombre;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarCancion(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            openFileDialog.Filter = "Archivos de audio (*.aac *.mp3 *.m4a *.wav *.wma)|*.AAC;*.MP3;*.M4A;*.WAV;*.WMA";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Seleccione una canción";
            openFileDialog.RestoreDirectory = true;
            try
            {
                if ((bool)openFileDialog.ShowDialog())
                {
                    if (archivoStream != null)
                    {
                        archivoStream.Dispose();
                        archivoStream = null;
                    }
                    archivoStream = openFileDialog.OpenFile();
                    if (archivoStream.Length > Propiedades.Default.TamañoMaxCancion)
                    {
                        MessageBox.Show("El archivo excede el tamaño máximo permitido. La canción debe pesar menos de 100MB", "Error al cargar la canción", MessageBoxButton.OK, MessageBoxImage.Error);
                        archivoStream.Dispose();
                        archivoStream = null;
                        return;
                    }
                    extensionArchivo = System.IO.Path.GetExtension(openFileDialog.SafeFileName);
                    tbArchivo.Text = openFileDialog.SafeFileName;
                    rutaArchivo = openFileDialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la canción. Inténtelo de nuevo.", "Error al cargar el archivo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ValidarTexto(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            var reemplazo = Regex.Replace(textbox.Text, @"[^\w\s.)#,*(-]+", "");
            if (!reemplazo.Equals(textbox.Text))
            {
                MessageBox.Show("Solo se permiten espacios, paréntesis, comas, guiones, puntos, asteriscos, letras y números", "Caracteres inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textbox.Text = reemplazo;
            }
        }

        private async void RegistrarCancion(object sender, RoutedEventArgs e)
        {
            var albumSeleccionado = misAlbumes.Where(a => a.Nombre.Equals(cbAlbumes.SelectedItem.ToString())).FirstOrDefault();
            if (albumSeleccionado == null || !ValidarCamposVacios())
            {
                MessageBox.Show("Todos los datos son obligatorios.", "Campos faltantes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Cancion nuevaCancion = new Cancion();
            nuevaCancion.Nombre = tbNombre.Text;
            nuevaCancion.EsPublica = true;
            nuevaCancion.Genero = cbGeneros.SelectedItem.ToString();
            nuevaCancion.Artista = tbArtista.Text;
            nuevaCancion.Album = new Album() { Id = albumSeleccionado.Id, Nombre = albumSeleccionado.Nombre };
            try
            {
                archivoStream.Dispose();
                archivoStream = null;
                var tfile = TagLib.File.Create(rutaArchivo);
                tfile.Tag.Title = nuevaCancion.Nombre;
                tfile.Tag.Album = nuevaCancion.Album.Nombre;
                tfile.Tag.Performers = null;
                tfile.Tag.Performers = new string[1] { nuevaCancion.Artista };
                tfile.Tag.Genres = null;
                tfile.Tag.Genres = new string[1] { nuevaCancion.Genero };
                nuevaCancion.Duracion = tfile.Properties.Duration.ToString(@"mm\:ss");
                tfile.Save();
                tfile.Dispose();
                tfile = null;
                archivoStream = File.Open(rutaArchivo, FileMode.Open);
                using (var call = clienteCanciones.SubirCancion())
                {
                    CancionPP pedazo = new CancionPP();
                    pedazo.IdUsuario = miId;
                    pedazo.Extensionarchivo = extensionArchivo;
                    pedazo.Cancion = nuevaCancion;
                    await call.RequestStream.WriteAsync(pedazo);
                    int totalBytesLeidos = 0;
                    int bytesLeidos = 0;
                    Byte[] buffer;
                    archivoStream.Position = 0;
                    while (archivoStream.Length > totalBytesLeidos)
                    {
                        if (archivoStream.Length - totalBytesLeidos < Propiedades.Default.BufferLecturaCancion)
                        {
                            buffer = new byte[archivoStream.Length - totalBytesLeidos];
                        }
                        else
                        {
                            buffer = new byte[Propiedades.Default.BufferLecturaCancion];
                        }
                        bytesLeidos = archivoStream.Read(buffer, 0, buffer.Length);
                        totalBytesLeidos += bytesLeidos;
                        pedazo = new CancionPP() { Contenido = ByteString.CopyFrom(buffer) };
                        await call.RequestStream.WriteAsync(pedazo);
                    }
                    archivoStream.Dispose();
                    await call.RequestStream.CompleteAsync();
                    var respuesta = await call.ResponseAsync;
                }
                this.NavigationService.Navigate(new VerAlbum(albumSeleccionado));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.AlreadyExists)
            {
                MessageBox.Show("Ya tiene una canción registrada con ese nombre en el album seleccionado. Cambie el nombre e inténtelo de nuevo.", "Canción ya registrada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (RpcException)
            {
                MessageBox.Show("Error al conectar con el servidor de SiReMu. Revise su conexión a internet e inténtelo de nuevo más tarde.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la canción. Revise el archivo de la canción e inténtelo de nuevo.", "Error con el archivo de la canción", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCamposVacios()
        {
            if (tbNombre.Text.Equals("") || tbArtista.Text.Equals("") || archivoStream == null)
            {
                return false;
            }
            return true;
        }

        private void CrearAlbum(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrarAlbum());
        }
    }
}
