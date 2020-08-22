using Microsoft.VisualStudio.TestTools.UnitTesting;
using MnjCuentas;
using SiReMu;
using System;

namespace PruebasServidorCuentas {
    [TestClass]
    public class PruebasFN {
        /// <summary>
        /// Estas son las pruebas para el flujo normal de los metodos del servidor de cuentas
        /// Requistos: debe existir un usuario con las siguientes credenciales Usuario=123 y Contraseña = 123456789
        /// Ademas debe existir un usuario con id 2
        /// </summary>
        private Random random = new Random();
        private ManejoCuentas.ManejoCuentasClient clienteCuentas = new ManejoCuentas.ManejoCuentasClient(Canales.CanalCuentas);

        [TestMethod]
        public void TestIniciarSesion() {
            var respuesta = clienteCuentas.IniciarSesion(new Usuario() { Usuario_ = "123", Contrasenia = "123456789" });
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestRegistrarUsuario() {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Usuario_ = "pruebaRegistroNo"+random.Next(1,100000);
            nuevoUsuario.Nombre = "Prueba";
            nuevoUsuario.Apellido = "Prueba";
            var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
            nuevoUsuario.Contrasenia = "Prueba";
            nuevoUsuario.Correo = "Prueba@Prueba.Prueba"+ random.Next(1, 100000);
            nuevoUsuario.Genero = "Rock";
            var respuesta = clienteCuentas.RegistrarUsuario(nuevoUsuario);
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestModificarUsuario() {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Id = 2;
            nuevoUsuario.Usuario_ = "pruebaRegistroNo" + random.Next(1, 100000);
            nuevoUsuario.Nombre = "Prueba";
            nuevoUsuario.Apellido = "Prueba";
            var fechaNacimiento = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            nuevoUsuario.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
            nuevoUsuario.Contrasenia = "Prueba";
            nuevoUsuario.Correo = "Prueba@Prueba.Prueba"+ random.Next(1, 100000);
            nuevoUsuario.Genero = "Rock";
            nuevoUsuario.EsCreadorContenido = true;
            var respuesta = clienteCuentas.ModificarUsuario(nuevoUsuario);
            Assert.AreEqual(respuesta.Respuesta, true);
        }
        [TestMethod]
        public void TestCambiarContrasena() {
            var cambioContraseña = new CambioContrasenas();
            cambioContraseña.IdUsuario = 6;
            cambioContraseña.ContrasenaAnterior = "Prueba";
            cambioContraseña.NuevaContrasena = "Prueba";
            var respuesta = clienteCuentas.CambiarContrasena(cambioContraseña);
            Assert.AreEqual(respuesta.Respuesta, true);
        }
    }
}
