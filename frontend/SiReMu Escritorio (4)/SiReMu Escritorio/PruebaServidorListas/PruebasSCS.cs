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
    /// Estas son las Pruebas para el servidor de las listas cuando no se puede conectar al servidor
    /// Requisitos: Para ejecutar estas pruebas es necesario que el servidor no se encuentre actualmente activo
    /// </summary>
    [TestClass]
    public class PruebasSCS {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private List<ListaReproduccion> listasEncontradas = new List<ListaReproduccion>();
        private ListaReproduccion miListaReproduccion;
        private Grpc.Core.RpcException excepcionEsperada = null;
        [TestMethod]
        public void TestAgregarCanciones() {
            try {
                var listaAA = new ListaAA();
                listaAA.IdLista = 3;
                listaAA.Agregar = true;
                listaAA.IdUsuario = 1;
                listaAA.IdCanciones.Add(1);
                var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestAgregarListaAMeGusta() {
            try {
                var listaAA = new ListaAA();
                listaAA.IdUsuario = 1;
                listaAA.IdLista = 3;
                listaAA.Agregar = true;
                var respuesta = clienteListas.AgregarListaAMeGusta(listaAA);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestBuscarListas() {
            try {
                var respuesta = clienteListas.BuscarListas(new NombreLista { Nombre = "li" });
                var listasAMostrar = new List<ElementoListView>();
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarMisListas() {
            try {
                var respuesta = clienteListas.ConsultarMisListas(new MnjListas.IdUsuario { Id = 1 });
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarMisListasAgregadas() {
            try {
                var respuesta = clienteListas.ConsultarMisListasAgregadas(new MnjListas.IdUsuario { Id = 1 });//clienteCanciones.ConsultarMisCanciones(new MnjCanciones.IdUsuario() { Id = 1 });
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestConsultarMisListasDefault() {
            try {
                var respuesta = clienteListas.ConsultarMisListasDefault(new MnjListas.IdUsuario { Id = 1 });//clienteCanciones.ConsultarMisCanciones(new MnjCanciones.IdUsuario() { Id = 1 });
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestCrearListaReproduccion() {
            try {
                Stream imgStream = new MemoryStream();
                Random random = new Random();
                var nuevaLista = new ListaReproduccion();
                nuevaLista.Nombre = "listaPueba No" + random.Next(0, 100000000) + "QQ"; ;
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
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestModificarListaReproduccion() {
            try {
                Stream imgStream = new MemoryStream();
                Random random = new Random();
                var nuevaLista = new ListaReproduccion();
                nuevaLista.Id = 3;
                nuevaLista.Nombre = "listaPueba No" + random.Next(0, 100000000); ;
                nuevaLista.Descripcion = "Descripcion de prueba";
                nuevaLista.EsPublica = true;
                imgStream = File.OpenRead("C:/Users/rockm/Pictures/trabajos/maxresdefault.jpg");
                imgStream.Position = 0;
                nuevaLista.Ilustracion = ByteString.FromStream(imgStream);
                nuevaLista.ExtensionIlustracion = ".jpg";
                var listaAG = new ListaAG();
                listaAG.IdUsuario = 1;
                listaAG.ListaAAgregar = nuevaLista;
                var respuesta = clienteListas.ModificarListaReproduccion(listaAG);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestEliminarLista() {
            try {
                var listaAG = new ListaAG();
                listaAG.IdUsuario = 1;
                listaAG.ListaAAgregar = new ListaReproduccion() { Id = 31 };
                var resultado = clienteListas.EliminarListaReproduccion(listaAG);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
    }
}
