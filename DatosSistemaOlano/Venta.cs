using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class Venta 
    {
        public int codVenta { get; set; }
        public EstadoVenta codEstadoVenta { get; set; }
        public Cliente dniRucCliente { get; set; }
        public Trabajador dniTrabajador { get; set; }
        public DateTime fecha { get; set; }
        public double montoTotal { get; set; }

        /**
        @roseuid 5B8F66330177
        */
        public Venta()
        {

        }

        /**
         * Obtiene la fecha, el numero de documento del cliente, el nombre del cliente, y el estado 
         * de la venta cuyo código se ha ingresado
        @param int codigo
        @return string[] camposMostrar
        @roseuid 59C5EC0A025D
        */
        public string[] ObtenerVenta(int codigo)
        {
            string[] camposMostrar = new string[4];
            string sql = @"SELECT V.codVenta, V.dniRucCliente, V.fecha, V.codEstadoVenta, C.nombre
                FROM Venta V JOIN Cliente C ON V.dniRucCliente=C.dniRucCliente 
                WHERE V.codVenta = '" + codigo + "'";
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
                            camposMostrar[0] = "0";
                            camposMostrar[1] = "0";
                            camposMostrar[2] = "0";
                            camposMostrar[3] = "0";
                            while (dr.Read() == true)
                            {

                                camposMostrar[0] = dr.GetDateTime(dr.GetOrdinal("fecha")).ToString("dd/MM/yyyy");
                                camposMostrar[1] = dr.GetString(dr.GetOrdinal("dniRucCliente"));
                                camposMostrar[2] = dr.GetString(dr.GetOrdinal("Nombre"));
                                camposMostrar[3] = dr.GetByte(dr.GetOrdinal("codEstadoVenta")).ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return camposMostrar;
        }

        /**
         * Obtiene venta por codigo de ella mostrará fecha,dniRucCliente,Nombre,dniTrabajador
        @param int codigo
        @return string[] ObtenerVenta1
        @roseuid 59C5EC1B1226
        */
        public string[] ObtenerVenta1(int codigo)
        {

            string[] camposMostrar = new string[4];
            string sql = @"SELECT V.codVenta, V.dniRucCliente, V.fecha, V.dniTrabajador, C.dniRucCliente, C.nombre
                FROM Venta V JOIN Cliente C ON V.dniRucCliente=C.dniRucCliente 
                WHERE V.CodVenta = '"+codigo+"'";
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
                            camposMostrar[0] = "0";
                            camposMostrar[1] = "0";
                            camposMostrar[2] = "0";
                            camposMostrar[3] = "0";
                            while (dr.Read() == true)
                            {

                                camposMostrar[0] = dr.GetDateTime(dr.GetOrdinal("fecha")).ToString("dd/MM/yyyy");
                                camposMostrar[1] = dr.GetString(dr.GetOrdinal("dniRucCliente"));
                                camposMostrar[2] = dr.GetString(dr.GetOrdinal("Nombre"));
                                camposMostrar[3] = dr.GetString(dr.GetOrdinal("dniTrabajador"));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return camposMostrar;
        }

        /**
         * Obtiene el estado y el monto total de una venta cuyo cliente y pago aún no han sido registrados
         @param int codigo
         @return string[] camposMostrar
         @roseuid 59C5EC1B1237
        */
        public string[] ObtenerMonto(int codigo)
        {
            string[] camposMostrar = new string[2];
            string sql = @"SELECT codEstadoVenta, montoTotal
                FROM Venta WHERE codVenta = '" + codigo + "'";
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
                            camposMostrar[0] = "0";
                            camposMostrar[1] = "0";
                            while (dr.Read() == true)
                            {
                                camposMostrar[0] = dr.GetByte(dr.GetOrdinal("codEstadoVenta")).ToString();
                                camposMostrar[1] = dr.GetDouble(dr.GetOrdinal("montoTotal")).ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return camposMostrar;
        }

        /**
         * Registra una nueva venta con estado pendiente y sin cliente y devuelve el codigo de la venta recien creada
         @param DateTime fecha
         @param string trabajador
         @param string montoTotal
         @return int codigo
         @roseuid 59C5EC1C2547
        */
        public int RegistrarVenta(DateTime fecha, string trabajador, string montoTotal)
        {
            string sql = @"INSERT INTO venta(fecha,dniTrabajador,codEstadoVenta,montoTotal)OUTPUT inserted.codVenta VALUES('" + fecha + "','" + trabajador + "',1,'" + montoTotal.Replace(',', '.') + "')";

            int codigo = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        //cmd.ExecuteNonQuery();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read() == true)
                            {
                                codigo = dr.GetInt32(dr.GetOrdinal("codVenta"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }

        /**
         * Registra venta por fecha,trabajador,dniCliente,montoTotal y devuelve el codigo de la venta recien creada
         @param DateTime fecha
         @param string trabajador
         @param string dniCliente
         @param string montoTotal
         @return int codigo
         @roseuid 59C5EC1C2548
        */
        public int RegistrarVentaV(DateTime fecha, string trabajador, string dniCliente, string montoTotal)
        {
            string sql = @"INSERT INTO venta(fecha,dniTrabajador,dniRucCliente,codEstadoVenta,montoTotal)OUTPUT inserted.codVenta VALUES('" + fecha + "','" + trabajador + "','" + dniCliente + "',1,'" + montoTotal.Replace(',', '.') + "')";

            int codigo = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        //cmd.ExecuteNonQuery();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read() == true)
                            {
                                codigo = dr.GetInt32(dr.GetOrdinal("codVenta"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }

        /**
         * Actualiza el estado de la venta
         @param int codigo
         @param int estado
         @roseuid 59C5EB242111
        */
        public void EstadoVenta(int codigo, int estado)
        {
            string sql = @"UPDATE venta SET codEstadoVenta = '" + estado + "' WHERE codVenta = '" + codigo + "'";

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
         * Registra un cliente en una venta de la cual se registrará el pago
         @param int codigo
         @param string dniRucCliente
         @roseuid 59C5E4318731
        */
        public void AgregarCliente(int codigo, string dniRucCliente)
        {
            string sql = @"UPDATE venta SET dniRucCliente = '" + dniRucCliente + "' WHERE codVenta = '" + codigo + "'";

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

