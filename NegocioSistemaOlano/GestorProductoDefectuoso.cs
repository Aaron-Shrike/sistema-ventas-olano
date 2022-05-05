using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorProductoDefectuoso
    {
        /**
        * Registrar producto defectuoso por codigo del producto y cantidad
        * 
         @param int codProducto, int cantidad
         @roseuid 59C5EAFC18A1
        */
        public void RegistrarProductosDefectuoso(int codProducto, int cantidad)
        {
            ProductoDefectuoso pd = new ProductoDefectuoso();

            pd.GuardarProductosDefectuosos(codProducto, cantidad);

        }

         /**
        * Valida la existencia del producto defectuoso por codigo de producto
        * 
         @param int codigo
         @roseuid 59C5EAFC18A2
        */
        public int ValidarExistencia(int codigo)
        {
            int CodigoPD;
            ProductoDefectuoso pd = new ProductoDefectuoso();
            CodigoPD = pd.ValidarExistenciaDefectuoso(codigo);

            return CodigoPD;
        }

        /**
        * Actualiza la cantidad del producto defectuoso por codigo del producto y cantidad
        * 
         @param int codigoProducto, int cantidad
         @roseuid 59C5EAFC18A3
        */
        public void ActualizarCantidadProductoDefectuoso(int codigoProducto, int cantidad)
        {
            ProductoDefectuoso pd = new ProductoDefectuoso();
            pd.ActualizarProductoDefectuoso(codigoProducto, cantidad);
        }
    }
}
