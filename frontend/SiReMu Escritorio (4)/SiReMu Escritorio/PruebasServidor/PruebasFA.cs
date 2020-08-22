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
    /// Estas son las pruebas para los flujos alternos del servidor de Canciones
    /// Requistos: debe haber un usuario con id 1, uno con id 2, un album con id 4
    /// y deben estar registrados los archivos requeridos en los metodos: TestSubirCancionRepetidaAsync y
    /// TestCrearAlbumRepetido
    /// </summary>
    [TestClass]
    public class PruebasFA {
        Random random = new Random();
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private Grpc.Core.RpcException excepcionEsperada = null;

        [TestMethod]
        public async System.Threading.Tasks.Task TestSubirCancionRepetidaAsync() {
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
                    Assert.AreEqual("Ya existe una canción con ese nombre en el album.", excepcionEsperada.Status.Detail);
                }
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Ya existe una canción con ese nombre en el album.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestCrearAlbumRepetido() {
            try {
                Stream imgStream = new MemoryStream();
                var nuevoAlbum = new Album();
                nuevoAlbum.Nombre = "listaPueba No12466549";
                nuevoAlbum.Compania = "PruebasRecords";
                var fechaLanzamiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);//.SelectedDate.Value;
                nuevoAlbum.FechaLanzamiento = fechaLanzamiento.ToString("yyyy-MM-dd");
                imgStream = File.OpenRead("C:/Users/rockm/Pictures/trabajos/maxresdefault.jpg");
                imgStream.Position = 0;
                nuevoAlbum.Ilustracion = ByteString.FromStream(imgStream);
                nuevoAlbum.ExtensionIlustracion = ".jpg";
                nuevoAlbum.EsPublico = true;
                var albumAG = new AlbumAG();
                albumAG.IdUsuario = 1;
                albumAG.Album = nuevoAlbum;
                var respuesta = clienteCanciones.CrearAlbum(albumAG);
                Assert.AreEqual("El usuario ya tiene un album registrado con ese nombre.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("El usuario ya tiene un album registrado con ese nombre.", excepcionEsperada.Status.Detail);
            }
        }

    }
}
