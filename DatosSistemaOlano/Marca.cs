using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class Marca
    {
        public int CodMarca { get; set; }
        public string Descripcion { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Marca()
        {

        }

        /**
         * Obtiene un listado de las marcas registradas
         * 
        @return List<Marca> marcas
        @roseuid 59C5EC0A0224
        */
        public List<Marca> ObtenerMarcas()
        {
            List<Marca> marcas;
            string sql = @"SELECT codMarca, descripcion FROM marca";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            marcas = new List<Marca>();
                            while (dr.Read() == true)
                            {
                                marcas.Add(
                                    new Marca()
                                    {
                                        CodMarca = dr.GetInt16(dr.GetOrdinal("codMarca")),
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

            return marcas;
        }
    }
}
