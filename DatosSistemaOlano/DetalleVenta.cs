using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class DetalleVenta
    {
        public Venta CodVenta { get; set; }
        public Producto CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int NumDevoluciones { get; set; }

        public string DescripcionProducto
        {
            get { return this.CodProducto.Descripcion; }
        }
        public string NombreProducto
        {
            get { return this.CodProducto.Nombre; }
        }
        public string CodigoProducto
        {
            get { return this.CodProducto.CodProducto.ToString(); }
        }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66323182
        */
        public DetalleVenta()
        {

        }

        /**
         * Registra detalle de una venta por codigo de venta, codigo de producto, cantidad de producto y precio
         * 
        @param int codVenta
        @param int codigo
        @param int cantidad
        @param string precio
        @roseuid 59C5EC0A0249
         */
        public void RegistrarDetalleVenta(int codVenta, int codigo, int cantidad, string precio)
        {
            string sql = @"INSERT INTO detalle_venta(codVenta,codProducto,cantidad,precio,numDevolucion)VALUES('" + codVenta + "','" + codigo + "','" + cantidad + "','" + precio.Replace(',', '.') + "',0)";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * Obtiene el detalle de venta por codigo de venta
         * 
        @param int codigo
        @return List<DetalleVenta> detalleVenta
        @roseuid 59C5EC0B1132
         */
        public List<DetalleVenta> ObtenerDetalleVenta(int codigo)
        {
            List<DetalleVenta> detalleVenta;
            string sql = @"SELECT D.precio, D.cantidad,D.numDevolucion,P.descripcion,P.codProducto,P.nombre FROM detalle_venta D JOIN Producto P ON D.codProducto=P.codProducto WHERE D.CodVenta ='" + codigo + "'";

            try
            {
                using (SqlConnection cn = new SqlConnection(
                   ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            detalleVenta = new List<DetalleVenta>();
                            while (dr.Read() == true)
                            {
                                detalleVenta.Add(
                                    new DetalleVenta()
                                    {
                                        Precio = dr.GetDouble(dr.GetOrdinal("precio")),
                                        Cantidad = dr.GetInt16(dr.GetOrdinal("cantidad")),
                                        NumDevoluciones = dr.GetByte(dr.GetOrdinal("numDevolucion")),
                                        CodProducto = new Producto()
                                        {
                                            CodProducto = dr.GetInt32(dr.GetOrdinal("codProducto")),
                                            Descripcion = dr.GetString(dr.GetOrdinal("descripcion")),
                                            Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                                        }

                                    }
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detalleVenta;
        }

        /**
         * Actualiza el numero de devoluciones por codigo de venta y codigo de producto
         * 
        @param int codigoProducto
        @param int codVenta
        @roseuid 59C5EC001325
         */
        public void ActualizarNumDevoluciones(int codigoProducto, int codVenta)
        {
            string sql = @"UPDATE detalle_venta SET NumDevolucion += '" + 1 + "' WHERE codProducto = '" + codigoProducto + "' AND codVenta = '" + codVenta + "'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
