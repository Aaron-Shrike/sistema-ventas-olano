using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorVenta
    {
        /**
         * Muestra los datos de la venta de acuerdo al codigo de la venta
        @param int codigo
        @return string[] datos
        @roseuid 59C5EAFC0191
         */
        public string[] BuscarVenta(int codigo)
        {
            string[] datos;
            Venta v = new Venta();
            datos = v.ObtenerVenta(codigo);
            return datos;
        }

        /**
         * Muestra los datos de la venta de acuerdo al codigo de la venta
        @param int codigo
        @return string[] datos
        @roseuid 59C5EAFC0192
         */
        public string[] BuscarVenta1(int codigo)
        {
            string[] datos;
            Venta v = new Venta();
            datos = v.ObtenerVenta1(codigo);
            return datos;
        }

        /**
        * Obtiene el monto total de la venta de acuerdo al codigo de la venta
         @param int codigo
         @return string[] datos
         @roseuid 59C5EAFC0193
        */
        public string[] ObtenerMonto(int codigo)
        {
            string[] datos;
            Venta v = new Venta();
            datos = v.ObtenerMonto(codigo);
            return datos;
        }

        /**
        * Carga los detalles de la venta de acuerdo al codigo de la venta
         @param int codigo
         @return Array ldv
         @roseuid 59C5EAFC0194
        */
        public Array CargarDetalleVenta(int codigo)
        {
            Array ldv;
            DetalleVenta dV = new DetalleVenta();
            ldv = dV.ObtenerDetalleVenta(codigo).ToArray();
            return ldv;
        }

        /**
        * Registra una venta sin cliente de acuerdo a los datos ingresados y devuelve el numero de la venta creada
         @param DateTime fecha, string trabajador, string montoTotal
         @return int codVenta
         @roseuid 59C5EAFC0195
        */
        public int RegistrarVenta(DateTime fecha, string trabajador, string montoTotal)
        {
            int codVenta = 0;
            Venta v = new Venta();
            codVenta = v.RegistrarVenta(fecha, trabajador, montoTotal);
            return codVenta;
        }

        /**
        * Registra Venta por fecha,trabajador,dniCliente,montoTotal
         @param DateTime fecha, string trabajador,string dniCliente, string montoTotal
         @return int codVenta
         @roseuid 59C5EAFC0196
        */
        public int RegistrarVentaV(DateTime fecha, string trabajador, string dniCliente, string montoTotal)
        {
            int codVenta = 0;
            Venta v = new Venta();
            codVenta = v.RegistrarVentaV(fecha, trabajador, dniCliente, montoTotal);
            return codVenta;
        }

        /**
        * Registra detalle de venta por codVenta,codigos,cantiades y precios
         @param int codVenta, int[] codigos, int[] cantidades, string[] precios
         @roseuid 59C5EAFC0197
        */
        public void RegistrarDetalleVenta(int codVenta, int[] codigos, int[] cantidades, string[] precios)
        {
            DetalleVenta dV = new DetalleVenta();
            for (int i = 0; i < codigos.Length; i++)
            {
                dV.RegistrarDetalleVenta(codVenta, codigos[i], cantidades[i], precios[i]);
            }
        }

        /**
        * Actualiza el estado de la venta por codigo y estado
         @param int codigo, int estado
         @roseuid 59C5EAFC0198
        */
        public void EstadoVenta(int codigo, int estado)
        {
            Venta v = new Venta();
            v.EstadoVenta(codigo, estado);
        }

        /**
        * Registra un cliente en una venta que no lo tenía inicialmente
         @param int codigo, string dniRucCliente
         @roseuid 59C5EAFC0200
        */
        public void AgregarCliente(int codigo, string dniRucCliente)
        {
            Venta v = new Venta();
            v.AgregarCliente(codigo, dniRucCliente);
        }

         /**
         * Actualiza numero de devoluciones de la venta por codigo de venta y codigo del producto a 
         * actualizar el numero de devoluciones
         @param int[] codigoA,int codVenta
         @roseuid 59C5EAFC0201
        */
        public void ActualizarNumDevoluciones(int[] codigoA, int codVenta)
        {
            DetalleVenta dv = new DetalleVenta();
            for (int i = 0; i < codigoA.Length; i++)
            {
                dv.ActualizarNumDevoluciones(codigoA[i], codVenta);
            }
        }
    }
}
