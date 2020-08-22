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
    /// Estas son las pruebas para el servidor para probar los flujos normales de los metodos del servidor
    /// Requisitos: Debe haber una lista de reproduccion creada con el nombre: lista
    /// Debe haber un usaurio registrado con el id 1
    /// Deben estar registrados los archivos de los metodos "TestCrearListaReproduccion" TestModificarListaReproduccion
    /// y TestEliminarLista
    /// </summary>
    [TestClass]
    public class PruebasFN {
        private readonly ManejoListas.ManejoListasClient clienteListas = new ManejoListas.ManejoListasClient(Canales.CanalListas);
        private readonly ManejoCanciones.ManejoCancionesClient clienteCanciones = new ManejoCanciones.ManejoCancionesClient(Canales.CanalCanciones);
        private List<ListaReproduccion> listasEncontradas = new List<ListaReproduccion>();
        private ListaReproduccion miListaReproduccion;
        [TestMethod]
        public void TestAgregarCanciones() {
            var listaAA = new ListaAA();
            listaAA.IdLista = 3;
            listaAA.Agregar = true;
            listaAA.IdUsuario = 1;
            listaAA.IdCanciones.Add(1);
            var respuesta = clienteListas.AgregarQuitarCancionesLista(listaAA);
            Assert.AreEqual(respuesta.Respuesta,true);
        }
        [TestMethod]
        public void TestAgregarListaAMeGusta() {
            var listaAA = new ListaAA();
            listaAA.IdUsuario = 1;
            listaAA.IdLista = 3;
            listaAA.Agregar = true;
            var respuesta = clienteListas.AgregarListaAMeGusta(listaAA);
        }
        [TestMethod]
        public void TestBuscarListas() {
            var respuesta = clienteListas.BuscarListas(new NombreLista { Nombre="li" });
            var listasAMostrar = new List<ElementoListView>();
            Assert.AreEqual(respuesta.Listas.Count>0,true);
        }
        [TestMethod]
        public void TestConsultarMisListas() {
            var respuesta = clienteListas.ConsultarMisListas(new MnjListas.IdUsuario { Id=1});
            Assert.AreEqual(respuesta.Listas.Count > 0, true);
        }
        [TestMethod]
        public void TestConsultarMisListasAgregadas() {
            var respuesta = clienteListas.ConsultarMisListasAgregadas(new MnjListas.IdUsuario { Id = 1});
            Assert.AreEqual(respuesta.Listas.Count > 0, true);
        }
        [TestMethod]
        public void TestConsultarMisListasDefault() {
            var respuesta = clienteListas.ConsultarMisListasDefault(new MnjListas.IdUsuario { Id = 1 });
            Assert.AreEqual(respuesta.Listas.Count > 0, true);
        }
        [TestMethod]
        public void TestCrearListaReproduccion() {
            Stream imgStream = new MemoryStream();
            Random random = new Random();
            var nuevaLista = new ListaReproduccion();
            nuevaLista.Nombre = "listaPueba No" + random.Next(0, 100000000)+"QQ"; ;
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
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestModificarListaReproduccion() {
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
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestEliminarLista() {
            Stream imgStream = new MemoryStream();
            Random random = new Random();
            var nuevaLista = new ListaReproduccion();
            nuevaLista.Nombre = "listaPuebaABorrar"; ;
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
            Assert.AreEqual(respuesta.Respuesta, true);
            //buscar
            var respuesta1 = clienteListas.BuscarListas(new NombreLista { Nombre = "listaPuebaABorrar" });
            var listasAMostrar = respuesta1.Listas;
            ListaReproduccion listaBorrar = new ListaReproduccion();
            foreach(ListaReproduccion lista in listasAMostrar) {
                listaBorrar = lista;
            }
            //borrado
            listaAG = new ListaAG();
            listaAG.IdUsuario = 2;
            listaAG.ListaAAgregar = new ListaReproduccion() {Id= listaBorrar.Id};
            var resultado = clienteListas.EliminarListaReproduccion(listaAG);
            Assert.AreEqual(resultado.Respuesta, true);
        }
    }
}
