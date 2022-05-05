using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class ProductoDefectuoso
    {
        public int codProductoDefectuoso { get; set; }
        public int codProducto { get; set; }
        public int cantidad {get; set;}

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public ProductoDefectuoso()
        {

        }

        /**
         * Guarda productos defectuosos por codProducto y cantidad
         * 
        @param int codProducto
        @param int cantidad
        @roseuid 59C5EC0B2274
        */
        public void GuardarProductosDefectuosos(int codProducto, int cantidad)
        {
            string sql = @"INSERT INTO producto_defectuoso(codProducto,cantidad)
            VALUES(+'"+codProducto+"','"+cantidad+"')";

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
         * Valida existencia del producto defectuoso por codigo de producto
         * 
        @param int codigo
        @return int Codigo
        @roseuid 59C5ED643B131
        */
        public int ValidarExistenciaDefectuoso(int codigo)
        {
            int Codigo=0;
            string sql = @"SELECT  codProductoDefectuoso FROM producto_defectuoso WHERE codProducto = '"+codigo+"'";
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
                           
                            while (dr.Read() == true)
                            {
                              Codigo= dr.GetInt32(dr.GetOrdinal("codProductoDefectuoso"));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Codigo;
        }

        /**
         * Actualiza producto defectuoso por codigo de producto y cantidad
         * 
        @param int codigoProducto
        @param int Cantidad
        @roseuid 59C6E265A431
        */
        public void ActualizarProductoDefectuoso(int codigoProducto, int Cantidad)
        {
            string sql = @"UPDATE producto_defectuoso SET cantidad += '"+Cantidad+"' WHERE codProducto = '"+codigoProducto+"'";

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
