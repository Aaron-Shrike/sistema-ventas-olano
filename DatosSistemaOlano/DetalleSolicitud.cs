using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class DetalleSolicitud
    {
        public Solicitud CodSolicitud { get; set; }
        public Producto CodProducto { get; set; }
        public int CantidadMinima { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public DetalleSolicitud()
        {

        }


        /**
         * Guarda el detalle de una solicitud en la base de datos
         * 
        @param DtalleSolicitud det
        @roseuid 59C5EC0A02AE
        */
        internal void GuardarDetalleSolicitud(DetalleSolicitud det)
        {
            string sql = @"INSERT INTO detalle_solicitud(codSolicitud, codProducto, cantidadMinima) VALUES ('" +
                        det.CodSolicitud.CodSolicitud + "','" + det.CodProducto.CodProducto+"','"+det.CantidadMinima+ "')";

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
