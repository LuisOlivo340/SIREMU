using Google.Protobuf;
using Grpc.Core;
using MnjCanciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiReMu
{
    public static class AdministradorCanciones
    {
        public static async void DescargarCancion(CancionAG cancionAG)
        {
            ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
            string direccionAlbumDescargado = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Propiedades.Default.CarpetaMusicaDescargada;
            if (!cancionAG.Cancion.EsPublica)
            {
                direccionAlbumDescargado += "Personales\\";
            }
            direccionAlbumDescargado += cancionAG.Cancion.Album.Nombre;
            byte[] bytes;
            FileStream fileStream = null;
            try
            {
                if (!Directory.Exists(direccionAlbumDescargado))
                {
                    Directory.CreateDirectory(direccionAlbumDescargado);
                }
                using (var respuesta = clienteCanciones.DescargarCancion(cancionAG))
                {
                    bool encabezado = true;
                    while (await respuesta.ResponseStream.MoveNext())
                    {
                        if (encabezado)
                        {
                            string direccionCancion = direccionAlbumDescargado + "\\" + cancionAG.Cancion.Nombre + respuesta.ResponseStream.Current.Extensionarchivo;
                            if (File.Exists(direccionCancion))
                            {
                                File.Delete(direccionCancion);
                            }
                            fileStream = new FileStream(direccionCancion, FileMode.Create, FileAccess.Write);
                            encabezado = false;
                        }
                        else
                        {
                            bytes = respuesta.ResponseStream.Current.Contenido.ToByteArray();
                            fileStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async void SubirCancionPersonal(CancionPP cancionPP)
        {
            ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
            var albumAG = new AlbumAG();
            albumAG.IdUsuario = cancionPP.IdUsuario;
            albumAG.Album = cancionPP.Cancion.Album;
            try
            {
                var respuesta = clienteCanciones.CrearAlbum(albumAG);
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode != StatusCode.AlreadyExists)
                {
                    return;
                }
            }
            try
            {
                Stream archivoStream = File.Open(cancionPP.Extensionarchivo, FileMode.Open);
                cancionPP.Cancion.Album = new Album() { Id = cancionPP.Cancion.Album.Id, Nombre = cancionPP.Cancion.Album.Nombre };
                using (var call = clienteCanciones.SubirCancion())
                {
                    cancionPP.Extensionarchivo = System.IO.Path.GetExtension(cancionPP.Extensionarchivo);
                    await call.RequestStream.WriteAsync(cancionPP);
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
                        cancionPP = new CancionPP() { Contenido = ByteString.CopyFrom(buffer) };
                        await call.RequestStream.WriteAsync(cancionPP);
                    }
                    archivoStream.Dispose();
                    await call.RequestStream.CompleteAsync();
                    var respuesta = await call.ResponseAsync;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
