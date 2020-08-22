using Grpc.Core;
using MaterialDesignThemes.Wpf;
using MnjListas;
using MnjCanciones;
using MnjCuentas;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace SiReMu
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);

        private bool evitarCerrarCanal = false;
        private Usuario miCuenta;

        private WaveOut salidaAudio;
        private WaveStream waveStream;
        private DispatcherTimer timerCancionActual;
        private bool silencio = false;
        private bool repeticion = false;
        private bool evitarRepeticion = false;

        private List<ListaReproduccion> misListasDefault = new List<ListaReproduccion>();
        private List<Cancion> colaDeReproduccion = new List<Cancion>();
        private int indiceCancionActual = -1;

        public Principal(Usuario cuenta)
        {
            InitializeComponent();
            this.miCuenta = cuenta;
            chipUsuario.Content = miCuenta.Usuario_;
            if (miCuenta.EsCreadorContenido)
            {
                lbMenuCreador.Visibility = Visibility.Visible;
                menuCreador.Visibility = Visibility.Visible;
            }
        }

        public Usuario getCuenta() { return miCuenta; }
        public void setCuenta(Usuario cuenta) { miCuenta = cuenta; }
        public ListaReproduccion getListaDefault(string nombreLista)
        {
            return misListasDefault.Where(l => l.Nombre.Equals(nombreLista)).FirstOrDefault();
        }
        public ListaReproduccion getListaDefault(int idLista)
        {
            return misListasDefault.Where(l => l.Id == idLista).FirstOrDefault();
        }

        public bool PrepararSesion()
        {
            if (!CargarMisListasDefault())
            {
                return false;
            }
            return true;
        }

        private bool CargarMisListasDefault()
        {
            try
            {
                var respuesta = clienteListas.ConsultarMisListasDefault(new MnjListas.IdUsuario { Id = miCuenta.Id });
                misListasDefault.AddRange(respuesta.Listas);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void CerrarVentana(object sender, System.ComponentModel.CancelEventArgs e)
        {
            colaDeReproduccion.Clear();
            salidaAudio?.Stop();
            if (!evitarCerrarCanal)
            {
                Canales.CerrarCanales();
            }
            
        }

        private void NavegarCompleto(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (framePrincipal.CanGoBack)
            {
                framePrincipal.RemoveBackEntry();
            }
        }

        private async void ReproducirCancion()
        {
            byte[] bytes;
            MemoryStream stream = new MemoryStream();
            if (!repeticion || indiceCancionActual < 0 || evitarRepeticion)
            {
                indiceCancionActual++;
                evitarRepeticion = false;
            }
            var proximaCancion = colaDeReproduccion.ElementAt(indiceCancionActual);
            try
            {
                string rutaCancion = this.BuscarArchivoCancion(proximaCancion.EsPublica, proximaCancion.Nombre, proximaCancion.Album.Nombre);
                if (rutaCancion != null && !rutaCancion.Equals(""))
                {
                    FileStream fileStream = new FileStream(rutaCancion, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[1024 * 16];
                    while (fileStream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
                else
                {
                    using (var respuesta = clienteCanciones.ReproducirCancion(new CancionAG() { Cancion = new Cancion() { Id = proximaCancion.Id }, IdUsuario = miCuenta.Id }))
                    {
                        while (await respuesta.ResponseStream.MoveNext())
                        {
                            bytes = respuesta.ResponseStream.Current.Contenido.ToByteArray();
                            stream.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                waveStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new StreamMediaFoundationReader(stream)));
                waveStream.Position = 0;
                salidaAudio = new WaveOut();
                salidaAudio.PlaybackStopped += OnPlaybackStopped;
                salidaAudio.Init(waveStream);
                if (silencio)
                {
                    salidaAudio.Volume = 0;
                }
                else
                {
                    salidaAudio.Volume = (float)barraVolumen.Value / 100f;
                }
                this.PrepararUIReproduccion();
                this.IniciarTimer();
                salidaAudio.Play();
            } catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                MessageBox.Show("No se encontró la canción. Prueba con otra.", "Canción no encontrada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Luis: " + ex);
            }
        }

        private string BuscarArchivoCancion(bool esPublica, string nombre, string album)
        {
            string direccionAlbumDescargado = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Propiedades.Default.CarpetaMusicaDescargada;
            if (!esPublica)
            {
                direccionAlbumDescargado += "Personales\\";
            }
            direccionAlbumDescargado += album;
            try
            {
                return Directory.GetFiles(direccionAlbumDescargado, nombre + ".*", SearchOption.AllDirectories).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void IniciarTimer()
        {
            timerCancionActual = new DispatcherTimer();
            timerCancionActual.Interval = TimeSpan.FromSeconds(1);
            timerCancionActual.Tick += new EventHandler(TickCancionActual);
            timerCancionActual.Start();
        }

        private void PrepararUIReproduccion()
        {
            var duracion = colaDeReproduccion.ElementAt(indiceCancionActual).Duracion;
            TimeSpan duracionTiempo;
            TimeSpan.TryParseExact(duracion, @"mm\:ss", null, out duracionTiempo);
            barraCancion.Maximum = duracionTiempo.TotalSeconds;
            tbDuracion.Text = duracion;
            btPlay.Visibility = Visibility.Collapsed;
            btPausa.Visibility = Visibility.Visible;
            this.MostrarDatosCancionActual();
        }

        private void MostrarDatosCancionActual()
        {
            var cancionActual = colaDeReproduccion.ElementAt(indiceCancionActual);
            tbNombre.Text = cancionActual.Nombre;
            tbArtista.Text = cancionActual.Artista;
            if (cancionActual.Album.Id != 0)
            {
                var stream = new MemoryStream(cancionActual.Album.Ilustracion.ToByteArray());
                var imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.StreamSource = stream;
                imagen.EndInit();
                imgCancionActual.Source = imagen;
            }
        }

        private void TickCancionActual(object sender, EventArgs e)
        {
            tbTiempoActual.Text = waveStream.CurrentTime.ToString(@"mm\:ss");
            barraCancion.Value = waveStream.CurrentTime.TotalSeconds;
            var duracion = tbDuracion.Text;
            TimeSpan duracionTiempo;
            TimeSpan.TryParseExact(duracion, @"mm\:ss", null, out duracionTiempo);
            if (waveStream.CurrentTime.TotalSeconds > duracionTiempo.TotalSeconds)
            {
                salidaAudio.Stop();
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            timerCancionActual.Stop();
            barraCancion.Value = 0;
            waveStream.Dispose();
            salidaAudio.Dispose();
            salidaAudio = null;
            tbDuracion.Text = "";
            tbTiempoActual.Text = "";
            tbNombre.Text = "";
            tbArtista.Text = "";
            btPlay.Visibility = Visibility.Visible;
            btPausa.Visibility = Visibility.Collapsed;
            imgCancionActual.Source = null;
            if (colaDeReproduccion.Count > indiceCancionActual + 1 || (colaDeReproduccion.Count == indiceCancionActual + 1 && repeticion))
            {
                this.ReproducirCancion();
            }
        }

        private void ReordenarColaReproduccion(object sender, RoutedEventArgs e)
        {
            if (indiceCancionActual < 0)
            {
                return;
            }
            var cancionActual = colaDeReproduccion.ElementAt(indiceCancionActual);
            colaDeReproduccion.RemoveAt(indiceCancionActual);
            colaDeReproduccion.ReordenarLista();
            colaDeReproduccion.Insert(0, cancionActual);
            indiceCancionActual = 0;
            if (framePrincipal.Content != null && framePrincipal.Content.GetType().Equals(typeof(ColaDeReproduccion)))
            {
                this.VerColaDeReproduccion(indiceCancionActual);
            }
        }

        private void ReproducirAnterior(object sender, RoutedEventArgs e)
        {
            if (salidaAudio == null && indiceCancionActual >= 0)
            {
                indiceCancionActual--;
                this.ReproducirCancion();
            }
            else if (salidaAudio != null)
            {
                if (waveStream.CurrentTime.TotalSeconds > 10 || indiceCancionActual <= 0)
                {
                    indiceCancionActual--;
                    salidaAudio.Stop();
                }
                else
                {
                    indiceCancionActual--;
                    indiceCancionActual--;
                    salidaAudio.Stop();
                }
            }
            evitarRepeticion = true;
            if (framePrincipal.Content != null && framePrincipal.Content.GetType().Equals(typeof(ColaDeReproduccion)))
            {
                this.VerColaDeReproduccion(indiceCancionActual + 1);
            }
        }

        private void PausarCancion(object sender, RoutedEventArgs e)
        {
            timerCancionActual.Stop();
            salidaAudio.Pause();
            btPlay.Visibility = Visibility.Visible;
            btPausa.Visibility = Visibility.Collapsed;
        }

        private void PlayCancion(object sender, RoutedEventArgs e)
        {
            if (salidaAudio == null)
            {
                return;
            }
            timerCancionActual.Start();
            salidaAudio.Resume();
            btPausa.Visibility = Visibility.Visible;
            btPlay.Visibility = Visibility.Collapsed;
        }

        private void ReproducirSiguiente(object sender, RoutedEventArgs e)
        {
            if (colaDeReproduccion.Count <= indiceCancionActual + 1)
            {
                return;
            }
            salidaAudio?.Stop();
            evitarRepeticion = true;
            if (framePrincipal.Content != null && framePrincipal.Content.GetType().Equals(typeof(ColaDeReproduccion)))
            {
                this.VerColaDeReproduccion(indiceCancionActual + 1);
            }
        }

        private void RepetirCancion(object sender, RoutedEventArgs e)
        {
            if (repeticion)
            {
                btRepeticion.Content = new PackIcon { Kind = PackIconKind.RepeatOff, Foreground = System.Windows.Media.Brushes.White, Width = 30, Height = 30 };
                repeticion = false;
            }
            else
            {
                btRepeticion.Content = new PackIcon { Kind = PackIconKind.Repeat, Foreground = System.Windows.Media.Brushes.White, Width = 30, Height = 30 };
                repeticion = true;
            }
        }

        private void VerColaDeReproduccion(object sender, RoutedEventArgs e)
        {
            this.VerColaDeReproduccion(indiceCancionActual);
        }

        private void VerColaDeReproduccion(int posicionCancion)
        {
            if (salidaAudio == null)
            {
                framePrincipal.Navigate(new ColaDeReproduccion(null, posicionCancion));
            }
            else
            {
                framePrincipal.Navigate(new ColaDeReproduccion(colaDeReproduccion, posicionCancion));
            }
        }

        private void Silenciar(object sender, RoutedEventArgs e)
        {
            if (silencio)
            {
                btSonido.Content = new PackIcon { Kind = PackIconKind.VolumeHigh, Foreground = System.Windows.Media.Brushes.White, Width = 40, Height = 40 };
                if (salidaAudio != null)
                {
                    salidaAudio.Volume = (float)barraVolumen.Value / 100f;
                }
                silencio = false;
            }
            else
            {
                btSonido.Content = new PackIcon { Kind = PackIconKind.VolumeMute, Foreground = System.Windows.Media.Brushes.White, Width = 40, Height = 40 };
                if (salidaAudio != null)
                {
                    salidaAudio.Volume = 0;
                }
                silencio = true;
            }
        }

        private void CambiarVolumen(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (salidaAudio == null || silencio)
            {
                return;
            }
            salidaAudio.Volume = (float)barraVolumen.Value / 100f;
        }

        private void VerMisCanciones(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new MisCanciones());
        }

        private void VerMisPlaylists(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new MisListasReproduccion());
        }

        private void VerListaPorDefecto(object sender, RoutedEventArgs e)
        {
            var opcion = sender as MenuItem;
            framePrincipal.Navigate(new VerListaReproduccion(this.getListaDefault(opcion.Header.ToString())));
        }

        private void VerMusicaPersonal(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new MiMusicaPersonal());
        }

        private void VerMusicaDescargada(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new MusicaDescargada());
        }

        private void VerMisAlbumes(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new MisAlbumes());
        }

        private void SubirCancion(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new SubirCancion());
        }

        private void BuscarAlgo(object sender, RoutedEventArgs e)
        {
            this.Buscar();
        }

        private void BuscarAlgo(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.Buscar();
            }
        }

        private void Buscar()
        {
            var reemplazo = Regex.Replace(tbBusqueda.Text, @"[\s]+", "");
            if (reemplazo.Equals(""))
            {
                return;
            }
            framePrincipal.Navigate(new VentanaBusqueda(tbBusqueda.Text));
        }

        private void ModificarCuenta(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new ModificarCuenta());
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            evitarCerrarCanal = true;
            new MainWindow().Show();
            this.Close();
        }

        public void ReproducirCanciones(List<Cancion> canciones, bool agregarACola, int indiceCancionAReproducir)
        {
            if (canciones.Count == 0)
            {
                MessageBox.Show("La lista está vacía.", "No hay canciones", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (!agregarACola)
            {
                colaDeReproduccion.Clear();
                indiceCancionActual = indiceCancionAReproducir - 1;
            }
            evitarRepeticion = true;
            colaDeReproduccion.AddRange(canciones);
            if (salidaAudio == null)
            {
                this.ReproducirCancion();
            }
            else if (!agregarACola)
            {
                salidaAudio.Stop();
            }
            if (framePrincipal.Content != null && framePrincipal.Content.GetType().Equals(typeof(ColaDeReproduccion)))
            {
                this.VerColaDeReproduccion(indiceCancionActual + 1);
            }
        }

        public void SacarDeLaColaDeReproduccion(List<int> indices)
        {
            for (int i = 0; i < indices.Count; i++)
            {
                colaDeReproduccion.RemoveAt(indices.ElementAt(i) - i);
            }
            framePrincipal.Navigate(new ColaDeReproduccion(colaDeReproduccion, indiceCancionActual));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            framePrincipal.Navigate(new MenuInicio("CancionesEnPromocion"));
        }
    }
}
