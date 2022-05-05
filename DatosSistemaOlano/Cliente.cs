using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class Cliente
    {
        public string DniRucCliente {get; set;}
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public double MontoAcumulado { get; set; }
        public bool ClienteFerretero { get; set; }
        public bool ClienteNatural { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Cliente()
        {

        }

        /**
         * Obtiene el nombre del cliente por su dni
         * 
        @param string dniCliente
        @return string nombre
        @roseuid 59C5EC0A0249
         */
        public string ObtenerNombreCliente(string dniCliente)
        {
            string nombre;
            string sql = @"SELECT nombre FROM cliente WHERE dniRucCliente = '" + dniCliente + "'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            nombre = "";
                            if (dr.Read() == true)
                            {
                                nombre = dr.GetString(dr.GetOrdinal("nombre"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nombre;
        }

        /**
         * Guarda a un cliente en la base de datos
         * 
        @param cliente datosCliente
        @roseuid 59C5EC0A02AE
         */
        public void GuardarCliente(Cliente datosCliente)
        {
            string sql = @"INSERT INTO cliente(dniRucCliente,nombre,telefono,direccion,montoAcumulado,clienteFerretero,clienteNatural) 
                        VALUES ('"+datosCliente.DniRucCliente+"','"+datosCliente.Nombre+ "','"+datosCliente.Telefono+"','"+
                        datosCliente.Direccion+"','"+datosCliente.MontoAcumulado+ "','"+datosCliente.ClienteFerretero+"','"+
                        datosCliente.ClienteNatural+"')";

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
         * Actualiza el monto acumulado de un cliente tras realizar el pago de una compra en la tienda
         * 
        @param string dniRucCliente
        @param string montoTotal
        @roseuid 59C5EC0A02BH
         */
        public void ActualizarMonto(string dniRucCliente, string montoTotal)
        {
            string sql = @"UPDATE cliente SET montoAcumulado += '" + montoTotal.Replace(',', '.') + "' WHERE dniRucCliente = '" + dniRucCliente + "'";

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
