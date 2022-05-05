using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class TipoTrabajador
    {
        public int CodTipoTrabajador { get; set; }
        public string Descripcion { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public TipoTrabajador()
        {

        }

        /**
         * Obtiene un listado de los tipos de trabajador registrados
        @return List<TipoTrabajador> tiposTrabajador
        @roseuid 5B8F51993156
        */
        public List<TipoTrabajador> ObtenerTiposTrabajador()
        {
            List<TipoTrabajador> tiposTrabajador;
            string sql = @"SELECT codTipoTrabajador, descripcion FROM tipo_trabajador";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            tiposTrabajador = new List<TipoTrabajador>();
                            while (dr.Read() == true)
                            {
                                tiposTrabajador.Add(
                                    new TipoTrabajador()
                                    {
                                        CodTipoTrabajador = dr.GetByte(dr.GetOrdinal("codTipoTrabajador")),
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

            return tiposTrabajador;
        }
    }
}
