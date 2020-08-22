using Microsoft.VisualStudio.TestTools.UnitTesting;
using MnjCuentas;
using SiReMu;
using System;

namespace PruebasServidorCuentas {
    /// <summary>
    /// Estas son las pruebas para los flujos alternos de los metodos del seevidor de cuentas
    /// Requistos: debe existir un usuario con las siguientes credenciales Usuario=123 y Contraseña = 123456789
    /// Ademas debe existir un usuario con id 2
    /// </summary>
    [TestClass]
    public class PruebasFA {
        private Random random = new Random();
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);
        private Grpc.Core.RpcException excepcionEsperada = null;
        [TestMethod]
        public void TestIniciarSesionUsuarioInvalido() {
            try {
                var respuesta = clienteCuentas.IniciarSesion(new Usuario() { Usuario_ = "134679usuarioInvalido", Contrasenia = "123456789" });
                Assert.AreEqual("No hay ningun usuario registrado con ese nombre de usuario.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("No hay ningun usuario registrado con ese nombre de usuario.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestIniciarSesionContraInvalida() {
            try {
                var respuesta = clienteCuentas.IniciarSesion(new Usuario() { Usuario_ = "123", Contrasenia = "123" });
                Assert.AreEqual("La contraseña es incorrecta.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("La contraseña es incorrecta.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestRegistrarUsuarioCorreoExistente() {
            try {
                var nuevoUsuario = new Usuario();
                nuevoUsuario.Usuario_ = "pruebaRegistroNo" + random.Next(1, 100000);
                nuevoUsuario.Nombre = "Prueba";
                nuevoUsuario.Apellido = "Prueba";
                var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
                nuevoUsuario.Contrasenia = "Prueba";
                nuevoUsuario.Correo = "123@123.123";
                nuevoUsuario.Genero = "Rock";
                var respuesta = clienteCuentas.RegistrarUsuario(nuevoUsuario);
                Assert.AreEqual("Ya existe un usuario registrado con ese correo.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Ya existe un usuario registrado con ese correo.", excepcionEsperada.Status.Detail);
            }
        }
        [TestMethod]
        public void TestRegistrarUsuarioUsuarioExistente() {
            try {
                var nuevoUsuario = new Usuario();
                nuevoUsuario.Usuario_ = "123";
                nuevoUsuario.Nombre = "Prueba";
                nuevoUsuario.Apellido = "Prueba";
                var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
                nuevoUsuario.Contrasenia = "Prueba";
                nuevoUsuario.Correo = "123@prueba.123" + random.Next(1,100000) ;
                nuevoUsuario.Genero = "Rock";
                var respuesta = clienteCuentas.RegistrarUsuario(nuevoUsuario);
                Assert.AreEqual("Ya existe un usuario registrado con ese nombre de usuario.", excepcionEsperada.Status.Detail);
            } catch (Grpc.Core.RpcException ex) {
                excepcionEsperada = ex;
                Assert.AreEqual("Ya existe un usuario registrado con ese nombre de usuario.", excepcionEsperada.Status.Detail);
            }
        }
    }
}
