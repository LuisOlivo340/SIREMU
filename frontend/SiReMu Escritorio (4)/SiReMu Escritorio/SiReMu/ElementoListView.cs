using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace SiReMu
{
    public class ElementoListView
    {
        private int idElemento;
        private string tituloPrincipal;
        private string tituloSecundario;
        private BitmapImage ilustracion;

        public int IdElemento
        {
            get { return this.idElemento; }
            set { this.idElemento = value; }
        }

        public string TituloPrincipal
        {
            get { return this.tituloPrincipal; }
            set { this.tituloPrincipal = value; }
        }

        public string TituloSecundario
        {
            get { return this.tituloSecundario; }
            set { this.tituloSecundario = value; }
        }


        public BitmapImage Ilustracion
        {
            get { return this.ilustracion; }
            set { this.ilustracion = value; }
        }

    }
}
