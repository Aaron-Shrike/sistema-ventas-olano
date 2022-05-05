using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class Solicitud
    {
        public int CodSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public Trabajador DniTrabajador { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Solicitud()
        {

        }

        /**
         * Guarda la solicitud de abastecimiento y sus detalles
         * 
        @param Solicitud sol, List<Producto> listPro
        @roseuid 59C5EC0A02A2
        */
        public void GuardarSolicitud(Solicitud sol, List<Producto> listPro)
        {
            int codSolicitud;
            string sql = @"INSERT INTO solicitud(fecha, dniTrabajador) OUTPUT inserted.codSolicitud VALUES ('" +
                        sol.Fecha.ToString("yyyyMMdd") + "','" + sol.DniTrabajador.DniTrabajador + "')";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();

                        codSolicitud = 0;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read() == true)
                            {
                                codSolicitud = dr.GetInt32(dr.GetOrdinal("codSolicitud"));
                            }
                        }
                    }
                }

                this.RegistrarDetalles(codSolicitud,listPro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * Registrar los detalles de solicitud
         * 
        @param int codSolicitud, List<Producto> listPro
        */
        private void RegistrarDetalles(int codSolicitud, List<Producto> listPro)
        {
            List<DetalleSolicitud> listDetSol = new List<DetalleSolicitud>();

            foreach (var pro in listPro)
            {
                listDetSol.Add(new DetalleSolicitud
                {
                    CodSolicitud = new Solicitud
                    {
                        CodSolicitud = codSolicitud
                    },
                    CodProducto = new Producto
                    {
                        CodProducto = pro.CodProducto
                    },
                    CantidadMinima = pro.CantidadMinima
                });
            }

            DetalleSolicitud detSol = new DetalleSolicitud();

            foreach (var det in listDetSol)
            {
                detSol.GuardarDetalleSolicitud(det);
            }
        }
    }
}
