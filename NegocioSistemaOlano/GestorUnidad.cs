using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorUnidad
    {
        /**
         * Carga las unidades del producto en una lista
         * 
        @return Array unidades
        @roseuid 59C5EAFC018B
        */
        public Array CargarUnidades()
        {
            Array unidades;

            Unidad u = new Unidad();

            unidades = u.ObtenerUnidades().ToArray();

            return unidades;
        }
    }
}
