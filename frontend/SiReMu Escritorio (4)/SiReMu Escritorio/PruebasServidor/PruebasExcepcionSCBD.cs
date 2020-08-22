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
    /// Estas son las pruebas para cuando no se encuentra una conexion disponible a la base de datos desde el servidor
    /// Requisitos: la base de datos debe estar desconectada del servidor
    /// </summary>
    [TestClass]
    public class PruebasExcepcionSCBD {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private const string ExpectedAlbums = "Minutes to Midnight";
        private const string ExpectedCanciones = "Given Up";
        private const bool ExpectedTrue = true;
        private Grpc.Core.RpcException excepcionEsperada = null;
        [TestMethod]
        public void TestBuscarAlbumes() {
            try {
                var respuesta = clienteCanciones.BuscarAlbumes(new Busqueda { Nombre = "Minutes to Midnight" });
                Album albumRespuesta = new Album();
                foreach (var album in respuesta.Albums) {
                    albumRespuesta = album;
                }
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestBuscarCanciones() {
            try {
                var respuesta = clienteCanciones.BuscarCanciones(new Busqueda { Nombre = "Given Up" });
                Cancion cancionRespuesta = new Cancion();
                foreach (var cancion in respuesta.Canciones) {
                    cancionRespuesta = cancion;
                }
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarAlbums() {
            try {
                var respuesta = clienteCanciones.ConsultarAlbums(new MnjCanciones.IdUsuario { Id = 1 });
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarAlbumsPopulares() {
            try {
                var respuesta = clienteCanciones.ConsultarAlbumsPopulares(new MnjCanciones.IdUsuario { Id = 1 });
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarCancionesAlbum() {
            try {
                var respuesta = clienteCanciones.ConsultarCancionesAlbum(new Album { Id = 4 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarCancionesAleatorias() {
            try {
                var respuesta = clienteCanciones.ConsultarCancionesAleatorias(new MnjCanciones.IdUsuario { Id = 1 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarCancionesEnPromocion() {
            try {
                var respuesta = clienteCanciones.ConsultarCancionesEnPromocion(new MnjCanciones.IdUsuario { Id = 1 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarCancionesLista() {
            try {
                var respuesta = clienteCanciones.ConsultarCancionesLista(new MnjCanciones.IdLista { Id = 1 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarCancionesPopulares() {
            try {
                var respuesta = clienteCanciones.ConsultarCancionesPopulares(new MnjCanciones.IdUsuario { Id = 1 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarMisCanciones() {
            try {
                var respuesta = clienteCanciones.ConsultarMisCanciones(new MnjCanciones.IdUsuario { Id = 1 });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestGenerarRadio() {
            try {
                var respuesta = clienteCanciones.GenerarRadio(new Cancion { Genero = "Rock" });
                Cancion cancionRespuesta = new Cancion();
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        ///
        [TestMethod]
        public async System.Threading.Tasks.Task TestSubirCancionAsync() {
            try {
                Stream archivoStream;
                Cancion nuevaCancion = new Cancion();
                nuevaCancion.Nombre = "pruebaSubida";
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
                    Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
                }   
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestReproducirCancionAsync() {
            try {
                byte[] bytes = null;
                MemoryStream stream = new MemoryStream();
                using (var respuesta = clienteCanciones.ReproducirCancion(new CancionAG() { Cancion = new Cancion() { Id = 10 }, IdUsuario = 2 })) {
                    while (await respuesta.ResponseStream.MoveNext()) {
                        bytes = respuesta.ResponseStream.Current.Contenido.ToByteArray();
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestCrearAlbum() {
            try {
                Stream imgStream = new MemoryStream();
                var nuevoAlbum = new Album();
                nuevoAlbum.Nombre = "AlbumCreado";
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
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        //subir cancion
        //reproducirCancion
        //modificarAlbum
        //crear album

    }
}
