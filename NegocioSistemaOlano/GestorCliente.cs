using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorCliente
    {
        /**
         * Busca el nombre de un cliente segun su dni
         * 
        @param string dniCliente
        @return string nombre
        @roseuid 59C5EAFC011A
        */
        public string BuscarNombreCliente(string dniCliente)
        {
            string nombre;

            Cliente cli = new Cliente();

            nombre = cli.ObtenerNombreCliente(dniCliente);

            return nombre;
        }


        /**
         * Registra un nuevo cliente
         * 
        @param string dniRucCliente, string nombre, string telefono, direccion
        @roseuid 59C5EAFC011E
         */
        public void RegistrarCliente(string dniRucCliente, string nombre, string telefono, string direccion)
        {
            bool clienteNatural = false;

            if(dniRucCliente.Length == 8){
                clienteNatural = true;
            }

            Cliente cli = new Cliente
            {
                DniRucCliente = dniRucCliente,
                Nombre = nombre,
                Telefono = telefono,
                Direccion = direccion,
                MontoAcumulado = 0.00,
                ClienteFerretero = false,
                ClienteNatural = clienteNatural
            };

            cli.GuardarCliente(cli);
        }

        /**
        * Actualiza el monto acumulado de un cliente tras realizar el pago de una compra en la tienda
        * 
       @param string dniRucCliente
       @param string montoTotal
       @roseuid 59C5EC0A02BH
        */
        public void ActualizarMonto(string dniRucCliente, string montoTotal)
        {
            Cliente cli = new Cliente();
            cli.ActualizarMonto(dniRucCliente,montoTotal);
        }
    }
}
