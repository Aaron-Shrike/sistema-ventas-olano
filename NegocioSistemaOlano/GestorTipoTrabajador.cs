using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorTipoTrabajador
    {
        /**
         * Carga una lista con los tipos de trabajador registrados
         * 
        @return Array tiposTrabajador
        @roseuid 59C5EAFC015C
        */
        public Array CargarTiposTrabajador()
        {
            Array tiposTrabajador;

            TipoTrabajador tT = new TipoTrabajador();

            tiposTrabajador = tT.ObtenerTiposTrabajador().ToArray();

            return tiposTrabajador;
        }
    }
}
