using Google.Protobuf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MnjCanciones;
using MnjListas;
using SiReMu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace PruebaServidorListas {
    /// <summary>
    /// Estas son las pruebas para los flujos alternos de los metodos del servidor de listas
    /// Requisiros: debe haber una lista registrada con id 3 , un usuario con id 2 y uno con id 1 y debe estar registrado
    /// el archivo requerido en el metodo TestCrearListaReproduccionRegistradaRepetida
    /// </summary>
    [TestClass]
    public class PruebasFA {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private List<ListaReproduccion> listasEncontradas = new List<ListaReproduccion>();
        private ListaReproduccion miListaReproduccion;
        private Grpc.Core.RpcException excepcionEsperada = null;
        [TestMethod]
        public void TestAgregarCancionesUsuarioInvalido() {
            try {
                var listaAA = new ListaAA();
                listaAA.IdLista = 3;
                listaAA.Agregar = true;
                listaAA.IdUsuario = 2;
                listaAA.IdCanciones.Add(1);
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
                Assert.AreEqual("El usuario no tiene autorización para modificar el/los recursos solicitados.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("El usuario no tiene autorización para modificar el/los recursos solicitados.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestAgregarListaAMeGustaInexistente() {
            try {
                var listaAA = new ListaAA();
                listaAA.IdUsuario = 1;
                listaAA.IdLista = 502;
                listaAA.Agregar = true;
                var respuesta = clienteListas.AgregarListaAMeGusta(listaAA);
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Error al conectar con la base de datos de SiReMu.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestCrearListaReproduccionRegistradaRepetida() {
            try {
                Stream imgStream = new MemoryStream();
                Random random = new Random();
                var nuevaLista = new ListaReproduccion();
                nuevaLista.Nombre = "listaPueba No12466549";
                nuevaLista.Descripcion = "Descripcion de prueba";
                nuevaLista.EsPublica = true;
                imgStream = File.OpenRead("C:/Users/rockm/Pictures/trabajos/maxresdefault.jpg");
                imgStream.Position = 0;
                nuevaLista.Ilustracion = ByteString.FromStream(imgStream);
                nuevaLista.ExtensionIlustracion = ".jpg";
                var listaAG = new ListaAG();
                listaAG.IdUsuario = 2;
                listaAG.ListaAAgregar = nuevaLista;
                var respuesta = clienteListas.CrearListaReproduccion(listaAG);
                Assert.AreEqual("El usuario ya tiene una lista registrada con ese nombre.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("El usuario ya tiene una lista registrada con ese nombre.", excepcionEsperada.Status.Detail);
            }
        }
    }
}
