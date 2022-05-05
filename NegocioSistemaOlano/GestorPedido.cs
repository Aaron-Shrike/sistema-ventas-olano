using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorPedido
    {
        /**
         * Registra los datos de un nuevo pedido
         * 
        @param string dniRucCliente, string dniTrabajador, string especificaciones, DateTime fecha
        @roseuid 59C5EAFC015E
        */
        public void RegistrarPedido(string dniRucCliente, string dniTrabajador, string especificaciones, DateTime fecha)
        {
            Pedido datosPedido = new Pedido
            {
                DniRucCliente = new Cliente
                {
                    DniRucCliente = dniRucCliente
                },
                DniTrabajador = new Trabajador
                {
                    DniTrabajador = dniTrabajador
                },
                Descripcion = especificaciones,
                Fecha = fecha
            };

            datosPedido.GuardarPedido(datosPedido);
        }

        /**
         * Busca un pedido gracias a su codigo
         * 
        @param string codigoPedido
        @return string[] datosPedido
        @roseuid 59C5EAFC0160
        */
        public string[] BuscarPedido(string codigoPedido)
        {
            Pedido p = new Pedido();
            string[] datosPedido = null;


            p = p.ObtenerPedido(codigoPedido);

            if(p != null)
            {
                datosPedido = new string[4];

                datosPedido[0] = p.DniTrabajador.DniTrabajador + " - " + p.DniTrabajador.Nombre;
                datosPedido[1] = p.DniRucCliente.DniRucCliente + " - " + p.DniRucCliente.Nombre;
                //datosPedido[2] = p.CodEstadoPedido.CodEstadoPedido.ToString();
                datosPedido[2] = p.CodEstadoPedido.Descripcion;
                datosPedido[3] = p.Descripcion;
            }
            

            return datosPedido;
        }

        /**
         * Registra la respuesta que tiene un pedido
         * 
        @param string codigoPedido, string codigoEstadoPedido
        @roseuid 59C5EAFC0162
        */
        public void RegistrarRespuesta(string codigoPedido, string codigoEstadoPedido)
        {
            Pedido datosPedido = new Pedido
            {
                CodPedido = Int16.Parse(codigoPedido),
                CodEstadoPedido = new EstadoPedido
                {
                    CodEstadoPedido = Byte.Parse(codigoEstadoPedido)
                }
            };

            datosPedido.ActualizarPedido(datosPedido);
        }
        
    }
}
