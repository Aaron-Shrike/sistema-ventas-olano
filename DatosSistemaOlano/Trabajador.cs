using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSistemaOlano
{
    public class Trabajador
    {
        public string DniTrabajador { get; set; }
        public TipoTrabajador CodTipoTrabajador { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public bool DadoBaja { get; set; }

        public string DescripcionTipoTrabajador { get { return CodTipoTrabajador.Descripcion; } }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Trabajador()
        {

        }


        /**
         * Obtiene el nombre de un trabajador segun su dni
         * 
        @param int dniTrabajador
        @return string nombre
        @roseuid 59C5EC0A027D
        */
        public string ObtenerNombreTrabajador(string dniTrabajador)
        {
            string nombre;
            string sql = @"SELECT nombre FROM trabajador WHERE dniTrabajador = '" + dniTrabajador + "'";

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
                            while (dr.Read() == true)
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
        * Obtiene el tipo y dni de un trabajador luego de validar su existencia en el sistema
        * 
       @param string dni
       @param string contrasenia
       @return string[] trab
       @roseuid 59C5E06C1320
       */
        public string[] ValidarCredenciales(string dni, string contrasenia)
        {
            string[] trab = new string[2];
            string sql = @"SELECT codTipoTrabajador,dniTrabajador FROM trabajador WHERE contraseña = '" + contrasenia + "' AND dniTrabajador = '" + dni + "' AND dadoBaja = 'False'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            trab[0] = "0";
                            trab[1] = "0";
                            while (dr.Read() == true)
                            {
                                trab[0] = dr.GetByte(dr.GetOrdinal("codTipoTrabajador")).ToString();
                                trab[1] = dr.GetString(dr.GetOrdinal("dniTrabajador"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return trab;
        }

        /**
       * Obtiene un listado de trabajadores que coincidan con el nombre ingresado
       * 
      @param string nombre
      @return List<Trabajador> trabajadores
      @roseuid 59C5E1A62215
      */
        public List<Trabajador> ObtenerTrabajadores(string nombre)
        {
            List<Trabajador> trabajadores;
            string sql = @"SELECT T.dniTrabajador, I.descripcion, T.nombre, T.direccion, T.telefono,
                        T.contraseña, T.dadoBaja FROM trabajador T JOIN tipo_trabajador I 
                        ON I.codTipoTrabajador = T.codTipoTrabajador WHERE T.nombre LIKE '" + nombre + "%'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            trabajadores = new List<Trabajador>();
                            while (dr.Read() == true)
                            {
                                trabajadores.Add(
                                    new Trabajador()
                                    {
                                        DniTrabajador = dr.GetString(dr.GetOrdinal("dniTrabajador")),
                                        CodTipoTrabajador = new TipoTrabajador()
                                        {
                                            Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                                        },
                                        Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                                        Direccion = dr.GetString(dr.GetOrdinal("direccion")),
                                        Telefono = dr.GetString(dr.GetOrdinal("telefono")),
                                        Contraseña = dr.GetString(dr.GetOrdinal("contraseña")),
                                        DadoBaja = dr.GetBoolean(dr.GetOrdinal("dadoBaja"))
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

            return trabajadores;
        }

         /**
          * Guarda un trabajador en la base de datos
          * 
         @param Trabajador t
         @roseuid 59C6227A3115
         */
        public void GuardarTrabajador(Trabajador t)
        {
            string sql = @"INSERT INTO trabajador(dniTrabajador, nombre, direccion, telefono, codTipoTrabajador, contraseña,
                        dadoBaja) VALUES ('" + t.DniTrabajador + "','" + t.Nombre + "','" + t.Direccion + "','" +
                        t.Telefono + "','" + t.CodTipoTrabajador.CodTipoTrabajador + "','" + t.Contraseña + "','false')";

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
          * Modifica los atributos de un trabajador registrado previamente
          * 
         @param Trabajador t
         @roseuid 59C6227A3116
         */
        public void ActualizarTrabajador(Trabajador t)
        {
            string sql = @"UPDATE trabajador SET nombre = '" + t.Nombre + "', direccion = '" + t.Direccion + "', telefono = '"
                        + t.Telefono + "', codTipoTrabajador= '" + t.CodTipoTrabajador.CodTipoTrabajador + "', contraseña = '"
                        + t.Contraseña + "', dadoBaja = '" + t.DadoBaja + "' WHERE dniTrabajador = '" + t.DniTrabajador + "'";

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
