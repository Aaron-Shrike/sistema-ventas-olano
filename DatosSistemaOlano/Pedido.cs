using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class Pedido
    {
        public int CodPedido { get; set; }
        public Trabajador DniTrabajador { get; set; }
        public Cliente DniRucCliente { get; set; }
        public EstadoPedido CodEstadoPedido { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Pedido()
        {

        }


        /**
         * Guarda un nuevo pedido registrado
         * 
        @param Pedido datosPedido
        @roseuid 59C5EC0A0233
        */
        public void GuardarPedido(Pedido datosPedido)
        {
            string sql = @"INSERT INTO pedido(dniTrabajador,dniRucCliente,codEstadoPedido,descripcion,fecha) VALUES ('"+
                        datosPedido.DniTrabajador.DniTrabajador+"','"+datosPedido.DniRucCliente.DniRucCliente+"','1','"+
                        datosPedido.Descripcion + "','" + datosPedido.Fecha.ToString("yyyyMMdd") + "')";

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
         * Obtiene un pedido segun un codigo
         * 
        @param string codigoPedido
        @return Pedido pedido
        @roseuid 59C5EC0A0235
        */
        public Pedido ObtenerPedido(string codigoPedido)
        {
            Pedido pedido = null;
            string sql = @"SELECT T.dniTrabajador, T.nombre as nomTrabajador, C.dniRucCliente, C.nombre as nomCliente, E.descripcion as desEstado,
                        P.descripcion as desPedido, P.fecha FROM pedido P JOIN trabajador T ON T.dniTrabajador = P.dniTrabajador
                        JOIN cliente C ON C.dniRucCliente = P.dniRucCliente JOIN estado_pedido E ON 
                        E.codEstadoPedido = P.codEstadoPedido WHERE P.codPedido = '" + codigoPedido + "'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            pedido = new Pedido();
                            if (dr.Read() == true)
                            {
                                pedido.DniTrabajador = new Trabajador()
                                {
                                    DniTrabajador = dr.GetString(dr.GetOrdinal("dniTrabajador")),
                                    Nombre = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                                };
                                pedido.DniRucCliente = new Cliente()
                                {
                                    DniRucCliente = dr.GetString(dr.GetOrdinal("dniRucCliente")),
                                    Nombre = dr.GetString(dr.GetOrdinal("nomCliente"))
                                };
                                pedido.CodEstadoPedido = new EstadoPedido()
                                {
                                    //CodEstadoPedido = dr.GetByte(dr.GetOrdinal("codEstadoPedido"))
                                    Descripcion = dr.GetString(dr.GetOrdinal("desEstado"))
                                };
                                pedido.Descripcion = dr.GetString(dr.GetOrdinal("desPedido"));
                                pedido.Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pedido;
        }


        /**
         * Actualiza el estado del pedido
         * 
        @param Pedido datosPedido
        @roseuid 59C5EC0A0237
         */
        public void ActualizarPedido(Pedido datosPedido)
        {
            string sql = @"UPDATE pedido SET codEstadoPedido = '" + datosPedido.CodEstadoPedido.CodEstadoPedido+ "' WHERE codPedido = '" + datosPedido.CodPedido + "'";

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
