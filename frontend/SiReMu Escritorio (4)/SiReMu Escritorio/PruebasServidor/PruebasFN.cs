using Google.Protobuf;
using Grpc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MnjCanciones;
using MnjListas;
using SiReMu;
using System;
using System.Collections.Generic;
using System.IO;

namespace PruebasServidor {
    /// <summary>
    /// Estas son las pruebas para los flujos normales de los metodos del servidor de canciones
    /// Requisitos: debe haber un usuario con id 1, uno con id 2, un album con id 4
    /// y deben estar registrados los archivos requeridos en los metodos: TestSubirCancionAsync y
    /// TestCrearAlbum
    /// </summary>
    [TestClass]
    public class PruebasFN {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private const string ExpectedAlbums = "Minutes to Midnight";
        private const string ExpectedCanciones = "Given Up";
        private const bool ExpectedTrue = true;
        Random random = new Random();
        [TestMethod]
        public void TestBuscarAlbumes() {
            var respuesta = clienteCanciones.BuscarAlbumes(new Busqueda { Nombre = "Minutes to Midnight" });
            Album albumRespuesta = new Album();
            foreach (var album in respuesta.Albums) {
                albumRespuesta = album;
            }
            Assert.AreEqual(ExpectedAlbums, albumRespuesta.Nombre);
        }
        [TestMethod]
        public void TestBuscarCanciones() {
            var respuesta = clienteCanciones.BuscarCanciones(new Busqueda { Nombre = "Given Up" });
            Cancion cancionRespuesta = new Cancion();
            foreach (var cancion in respuesta.Canciones) {
                cancionRespuesta = cancion;
            }
            Assert.AreEqual(ExpectedCanciones, cancionRespuesta.Nombre);
        }
        [TestMethod]
        public void TestConsultarAlbums() {
            var respuesta = clienteCanciones.ConsultarAlbums(new MnjCanciones.IdUsuario { Id = 1 });
            Assert.AreEqual(ExpectedTrue, respuesta.Albums.Count > 0);
        }
        [TestMethod]
        public void TestConsultarAlbumsPopulares() {
            var respuesta = clienteCanciones.ConsultarAlbumsPopulares(new MnjCanciones.IdUsuario { Id = 1 });
            Assert.AreEqual(ExpectedTrue, respuesta.Albums.Count > 0);
        }
        [TestMethod]
        public void TestConsultarCancionesAlbum() {
            var respuesta = clienteCanciones.ConsultarCancionesAlbum(new Album { Id = 4 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestConsultarCancionesAleatorias() {
            var respuesta = clienteCanciones.ConsultarCancionesAleatorias(new MnjCanciones.IdUsuario { Id = 1 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestConsultarCancionesEnPromocion() {
            var respuesta = clienteCanciones.ConsultarCancionesEnPromocion(new MnjCanciones.IdUsuario { Id = 1 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestConsultarCancionesLista() {
            var respuesta = clienteCanciones.ConsultarCancionesLista(new MnjCanciones.IdLista { Id = 1 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestConsultarCancionesPopulares() {
            var respuesta = clienteCanciones.ConsultarCancionesPopulares(new MnjCanciones.IdUsuario { Id = 1 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestConsultarMisCanciones() {
            var respuesta = clienteCanciones.ConsultarMisCanciones(new MnjCanciones.IdUsuario { Id = 1 });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public void TestGenerarRadio() {
            var respuesta = clienteCanciones.GenerarRadio(new Cancion { Genero = "Rock" });
            Cancion cancionRespuesta = new Cancion();
            Assert.AreEqual(ExpectedTrue, respuesta.Canciones.Count > 0);
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestSubirCancionAsync() {
            Stream archivoStream;
            Cancion nuevaCancion = new Cancion();
            nuevaCancion.Nombre = "pruebaSubidaNo"+random.Next(1,1000000000);
            nuevaCancion.EsPublica = true;
            nuevaCancion.Genero = "Rock";
            nuevaCancion.Artista = "ArtistaEnPrueba";
            nuevaCancion.Album = new Album() { Id = 7, Nombre = "albumPruebaCanciones" };
            
            archivoStream = null;
            var tfile = TagLib.File.Create("C:/Users/rockm/Downloads/musica p agregar/Canciones a subir/Coldplay - A Sky Full Of Stars (Official Video).mp3");
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
            archivoStream = File.Open("C:/Users/rockm/Downloads/musica p agregar/Canciones a subir/Coldplay - A Sky Full Of Stars (Official Video).mp3", FileMode.Open);
            using (var call = clienteCanciones.SubirCancion()) {
                CancionPP pedazo = new CancionPP();
                pedazo.IdUsuario = 2;
                pedazo.Extensionarchivo = ".mp3";
                pedazo.Cancion = nuevaCancion;
                await call.RequestStream.WriteAsync(pedazo);
                int totalBytesLeidos = 0;
                int bytesLeidos = 0;
                Byte[] buffer;
                archivoStream.Position = 0;
                while (archivoStream.Length > totalBytesLeidos) {
                    if (archivoStream.Length - totalBytesLeidos < Propiedades.Default.BufferLecturaCancion) {
                        buffer = new byte[archivoStream.Length - totalBytesLeidos];
                    } else {
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
                Assert.AreEqual(respuesta.Respuesta, true);
            }
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestReproducirCancionAsync() {
            byte[] bytes=null;
            MemoryStream stream = new MemoryStream();
            using (var respuesta = clienteCanciones.ReproducirCancion(new CancionAG() { Cancion = new Cancion() { Id = 10 }, IdUsuario = 2 })) {
                while (await respuesta.ResponseStream.MoveNext()) {
                    bytes = respuesta.ResponseStream.Current.Contenido.ToByteArray();
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            Assert.AreEqual(bytes.Length>0,true);
        }
        [TestMethod]
        public void TestCrearAlbum() {
            Stream imgStream= new MemoryStream();
            var nuevoAlbum = new Album();
            nuevoAlbum.Nombre = "AlbumCreadoNo" + random.Next(1,100000000) ;
            nuevoAlbum.Compania = "PruebasRecords";
            var fechaLanzamiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);//.SelectedDate.Value;
            nuevoAlbum.FechaLanzamiento = fechaLanzamiento.ToString("yyyy-MM-dd");
            imgStream = File.OpenRead("C:/Users/rockm/Pictures/trabajos/maxresdefault.jpg");
            imgStream.Position = 0;
            nuevoAlbum.Ilustracion = ByteString.FromStream(imgStream);
            nuevoAlbum.ExtensionIlustracion = ".jpg";
            nuevoAlbum.EsPublico = true;
            var albumAG = new AlbumAG();
            albumAG.IdUsuario = 2;
            albumAG.Album = nuevoAlbum;
            var respuesta = clienteCanciones.CrearAlbum(albumAG);
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestDescargarCancion() {
            Cancion cancion = new Cancion();
            cancion.Id = 1;
            var respuesta = clienteCanciones.DescargarCancion(new CancionAG { Cancion=cancion, IdUsuario = 1 });
            Assert.AreEqual(respuesta.ResponseStream!=null, true);
        }
    }
}
