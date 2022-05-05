using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorMarca
    {
        /**
         * Carga una lista con las marcas del producto
         * 
        @return Array marcas
        @roseuid 59C5EAFC015B
        */
        public Array CargarMarcas()
        {
            Array marcas;

            Marca m = new Marca();

            marcas = m.ObtenerMarcas().ToArray();

            return marcas;
        }
    }
}
