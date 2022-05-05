using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class EstadoPedido
    {
        public int CodEstadoPedido { get; set; }
        public string Descripcion { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66331262
        */
        public EstadoPedido()
        {

        }

        /**
         * Obtiene un listado de los estados del pedido
         * 
        @return List<EstadoPedido> estados
        @roseuid 59C5EC0A0224
        */
        public List<EstadoPedido> ObtenerEstados()
        {
            List<EstadoPedido> estados;
            string sql = @"SELECT codEstadoPedido, descripcion FROM estado_pedido";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            estados = new List<EstadoPedido>();
                            while (dr.Read() == true)
                            {
                                estados.Add(
                                    new EstadoPedido()
                                    {
                                        CodEstadoPedido = dr.GetByte(dr.GetOrdinal("codEstadoPedido")),
                                        Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
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

            return estados;
        }
    }
}
