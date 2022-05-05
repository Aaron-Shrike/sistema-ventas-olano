using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorEstadoPedido
    {
        /**
         * Carga una lista con los estados del pedido
         * 
        @return Arrayy listEstados
        @roseuid 59C5EAFC0158
        */
        public Array CargarEstados()
        {
            EstadoPedido estadoPedido = new EstadoPedido();
            Array listEstados;

            listEstados = estadoPedido.ObtenerEstados().ToArray();

            return listEstados;
        }
    }
}
