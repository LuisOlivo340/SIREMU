using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiReMu
{
    public static class Canales
    {
        public static Channel CanalListas = new Channel(Propiedades.Default.IpServidorListas + ":" + Propiedades.Default.PuertoServidorListas, ChannelCredentials.Insecure);
        public static Channel CanalCanciones = new Channel(Propiedades.Default.IpServidorCanciones + ":" + Propiedades.Default.PuertoServidorCanciones, ChannelCredentials.Insecure);
        public static Channel CanalCuentas = new Channel(Propiedades.Default.IpServidorCuentas + ":" + Propiedades.Default.PuertoServidorCuentas, ChannelCredentials.Insecure);

        public static void CerrarCanales()
        {
            CanalListas.ShutdownAsync().Wait();
            CanalCanciones.ShutdownAsync().Wait();
            CanalCuentas.ShutdownAsync().Wait();
        }
    }
}
