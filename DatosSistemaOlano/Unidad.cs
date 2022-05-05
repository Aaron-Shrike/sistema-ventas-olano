using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class Unidad
    {
        public int CodUnidad { get; set; }
        public string Descripcion { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Unidad()
        {

        }


        /**
         * Obtiene un listado de las unidades
         * 
        @return List<Unidad>
        @roseuid 59C5EC0A0224
        */
        public List<Unidad> ObtenerUnidades()
        {
            List<Unidad> unidades;
            string sql = @"SELECT codUnidad, descripcion FROM unidad";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            unidades = new List<Unidad>();
                            while (dr.Read() == true)
                            {
                                unidades.Add(
                                    new Unidad()
                                    {
                                        CodUnidad = dr.GetInt16(dr.GetOrdinal("codUnidad")),
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

            return unidades;
        }
    }
}
