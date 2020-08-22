using System;
using System.Collections.Generic;
using System.Text;

namespace SiReMu
{
    public class Cuenta
    {
        private int id;
        private string nombreUsuario;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { this.nombreUsuario = value; }
        }
    }
}
