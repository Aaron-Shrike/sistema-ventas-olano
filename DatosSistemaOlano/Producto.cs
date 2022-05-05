using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DatosSistemaOlano
{
    public class Producto
    {
        public int CodProducto { get; set; }
        public Marca CodMarca { get; set; }
        public Unidad CodUnidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public bool DadoBaja { get; set; }

        public string DescripcionMarca { 
            get{ return CodMarca.Descripcion; }
        }

        public string DescripcionUnidad
        {
            get { return CodUnidad.Descripcion; }
        }

        public int CantidadMinima
        {
            get { return StockMinimo-Stock; }
        }

        /**
         * Constructor por defecto de la entidad
        @roseuid 5B8F66330177
        */
        public Producto()
        {

        }

        /**
         * Guarda los datos de un nuevo producto
         * 
        @param Producto datosProducto
        @roseuid 59C5EC0A02BA
        */
        public void GuardarProducto(Producto datosProducto)
        {
            string sql = @"INSERT INTO producto(nombre, descripcion, codMarca, precio, codUnidad, stock, stockMinimo, dadoBaja) VALUES ('" +
                        datosProducto.Nombre + "','" + datosProducto.Descripcion + "','" + datosProducto.CodMarca.CodMarca + "','" +
                        datosProducto.Precio.ToString().Replace(',', '.') + "','" + datosProducto.CodUnidad.CodUnidad + "','" + datosProducto.Stock + "','" +
                        datosProducto.StockMinimo + "','false')";

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
         * Obtiene la lista de productos cuando su stock es menor al minimo
         * 
        @return List<Producto> productos
        @roseuid 59C5EC0A02BA
        */
        public List<Producto> ObtenerProductosStockMinimo()
        {
            List<Producto> productos;
            string sql = @"SELECT codProducto, nombre, descripcion, stock, stockMinimo FROM producto 
                            WHERE stock <= stockMinimo AND dadoBaja = 'false'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            productos = new List<Producto>();
                            while (dr.Read() == true)
                            {
                                productos.Add(
                                    new Producto()
                                    {
                                        CodProducto = dr.GetInt32(dr.GetOrdinal("codProducto")),
                                        Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                                        Descripcion = dr.GetString(dr.GetOrdinal("descripcion")),
                                        Stock = dr.GetInt16(dr.GetOrdinal("stock")),
                                        StockMinimo = dr.GetInt16(dr.GetOrdinal("stockMinimo"))
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

            return productos;
        }

        /**
         * Actualiza el stock de productos indicando el codigo del producto y la cantidad que ingresa
         * 
        @param int codigo
        @param int cantidad
        @roseuid 59C5EC0A02BA
        */
        public void ActualizarStockProducto(int codigo, int cantidad)
        {
            string sql = @"UPDATE producto SET stock +=" + cantidad + " WHERE codProducto = '" + codigo + "'";

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
         * Obtiene una lista de productos segun el nombre solicitado
         * 
        @param string nombre
        @return List<Producto> productos
        @roseuid 59C5EC0A02BC
        */
        public List<Producto> ObtenerProductos(string nombre)
        {
            List<Producto> productos;
            string sql = @"SELECT P.codProducto, M.descripcion AS desMarca, U.descripcion AS desUnidad, P.nombre, P.descripcion AS desProducto,
                        P.precio ,P.stock, P.stockMinimo, P.dadoBaja FROM Producto P JOIN Marca M ON M.codMarca = P.codMarca
                        JOIN Unidad U ON U.codUnidad = P.codUnidad WHERE P.nombre LIKE '"+nombre+"%'";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            productos = new List<Producto>();
                            while (dr.Read() == true)
                            {
                                productos.Add(
                                    new Producto()
                                    {
                                        CodProducto = dr.GetInt32(dr.GetOrdinal("codProducto")),
                                        CodMarca = new Marca()
                                        {
                                            Descripcion = dr.GetString(dr.GetOrdinal("desMarca"))
                                        },
                                        CodUnidad = new Unidad() {
                                            Descripcion = dr.GetString(dr.GetOrdinal("desUnidad"))
                                        },
                                        Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                                        Descripcion = dr.GetString(dr.GetOrdinal("desProducto")),
                                        Precio = dr.GetDouble(dr.GetOrdinal("precio")),
                                        Stock = dr.GetInt16(dr.GetOrdinal("stock")),
                                        StockMinimo = dr.GetInt16(dr.GetOrdinal("stockMinimo")),
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

            return productos;
        }

        /**
         * Actualiza los datos de un producto
         * 
        @param Producto datosProducto
        @roseuid 59C5EC0A02BE
        */
        public void ActualizarProducto(Producto datosProducto)
        {
            string sql = @"UPDATE producto SET nombre = '"+datosProducto.Nombre+"', descripcion = '"+datosProducto.Descripcion+"', codMarca = '"+
                        datosProducto.CodMarca.CodMarca + "', precio = '" + datosProducto.Precio.ToString().Replace(',', '.') + "', codUnidad = '" + datosProducto.CodUnidad.CodUnidad +
                        "', stock = '"+datosProducto.Stock+"', stockMinimo = '"+datosProducto.StockMinimo+"', dadoBaja = '"+datosProducto.DadoBaja+
                        "' WHERE codProducto = '" + datosProducto.CodProducto + "'";

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
        * Valida stock por codigo del producto y cantidad
        * 
       @param int cantidad
       @param int codigo
       @return bool disponible
       @roseuid 59C5EC0A02BE
       */
        public bool ValidarStock(int cantidad, int codigo)
        {
            bool disponible = false;
            string sql = @"SELECT stock FROM Producto WHERE codProducto = '" + codigo + "' AND dadoBaja = 'False' AND stock >= " + cantidad + "";

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read() == true)
                            {
                                if (dr.GetInt16(dr.GetOrdinal("stock")) > 0)
                                {
                                    disponible = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return disponible;
        }
    }
}
