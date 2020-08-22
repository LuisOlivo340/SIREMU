using Microsoft.VisualStudio.TestTools.UnitTesting;
using MnjCuentas;
using SiReMu;
using System;

namespace PruebasServidorCuentas {
    /// <summary>
    /// Estas son las pruebas para cuando no esa disponible el servidor de cuentas
    /// Requistos: no debe existir una conexion valida entre el cliente y el servidor de cuentas
    /// </summary>
    [TestClass]
    public class PruebasExcepcionSCS {
        private Random random = new Random();
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);
        private Grpc.Core.RpcException excepcionEsperada = null;
        [TestMethod]
        public void TestIniciarSesion() {
            try {
                var respuesta = clienteCuentas.IniciarSesion(new Usuario() { Usuario_ = "123", Contrasenia = "123456789" });
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestRegistrarUsuario() {
            try {
                var nuevoUsuario = new Usuario();
                nuevoUsuario.Usuario_ = "pruebaRegistroNo" + random.Next(1, 100000);
                nuevoUsuario.Nombre = "Prueba";
                nuevoUsuario.Apellido = "Prueba";
                var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);//.SelectedDate.Value;
                nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
                nuevoUsuario.Contrasenia = "Prueba";
                nuevoUsuario.Correo = "Prueba@Prueba.Prueba" + random.Next(1, 100000);
                nuevoUsuario.Genero = "Rock";
                var respuesta = clienteCuentas.RegistrarUsuario(nuevoUsuario);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestModificarUsuario() {
            try {
                var nuevoUsuario = new Usuario();
                nuevoUsuario.Id = 2;
                nuevoUsuario.Usuario_ = "pruebaRegistroNo" + random.Next(1, 100000);
                nuevoUsuario.Nombre = "Prueba";
                nuevoUsuario.Apellido = "Prueba";
                var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);//.SelectedDate.Value;
                nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
                nuevoUsuario.Contrasenia = "Prueba";
                nuevoUsuario.Correo = "Prueba@Prueba.Prueba" + random.Next(1, 100000);
                nuevoUsuario.Genero = "Rock";
                nuevoUsuario.EsCreadorContenido = true;
                var respuesta = clienteCuentas.ModificarUsuario(nuevoUsuario);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestCambiarContrasena() {
            try {
                var cambioContraseña = new CambioContrasenas();
                cambioContraseña.IdUsuario = 6;
                cambioContraseña.ContrasenaAnterior = "Prueba";
                cambioContraseña.NuevaContrasena = "Prueba";
                var respuesta = clienteCuentas.CambiarContrasena(cambioContraseña);
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("failed to connect to all addresses", excepcionEsperada.Status.Detail);
            }
        }
    }
}
