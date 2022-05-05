using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorProducto
    {
        /**
         * Carga los productos segun el nombre indicado
         * 
        @param string nombre
        @return Array productos
        @roseuid 5B8F63CD02B0
        */
        public Array CargarProductos(string nombre)
        {
            Array productos;

            Producto p = new Producto();

            productos = p.ObtenerProductos(nombre).ToArray();

            return productos;
        }

        /**
         * Modifica los datos indicados de un producto
         * 
        @param int codigo, string nombre, string descripcion, int marca, double precio, int unidad, int stock, int stockMinimo, bool dadoBaja
        @roseuid 59C5EAFC01A1
        */
        public void ModificarProducto(int codigo, string nombre, string descripcion, int marca, double precio, int unidad, int stock, int stockMinimo, bool dadoBaja)
        {
            Producto p = new Producto
            {
                CodProducto = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                CodMarca = new Marca
                {
                    CodMarca = marca
                },
                Precio = precio,
                CodUnidad = new Unidad 
                { 
                    CodUnidad = unidad
                },
                Stock = stock,
                StockMinimo = stockMinimo,
                DadoBaja = dadoBaja
            };

            p.ActualizarProducto(p);
        }

        /**
         * Lista los productos cuyo stock es menor al stock minimo y requieren de abastecimiento
         * 
        @return Array productos
        @roseuid 59C5EAFC01A1
        */
        public Array ListarProductosStockMinimo()
        {
            Array productos;

            Producto p = new Producto();

            productos = p.ObtenerProductosStockMinimo().ToArray();

            return productos;
        }

        /**
         * Registra un nuevo producto indicando sus datos
         * 
        @param string nombre, string descripcion, int codMarca, double precio, int codUnidad, int stock, int stockMinimo
        @roseuid 59C5EAFC019E
        */
        public void RegistrarProducto(string nombre, string descripcion, int codMarca, double precio, int codUnidad, int stock, int stockMinimo)
        {
            Producto p = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                CodMarca = new Marca
                {
                    CodMarca = codMarca
                },
                Precio = precio,
                CodUnidad = new Unidad
                {
                    CodUnidad = codUnidad
                },
                Stock = stock,
                StockMinimo = stockMinimo
            };

            p.GuardarProducto(p);
        }

        /**
         * Modifica el stock de un producto segun su codigo y indicando la cantidad
         * 
        @param int codigo, int cantidad
        @roseuid 59C5EAFC01A0
        */
        public void ModificarStockProducto(int codigo, int cantidad)
        {
            Producto p = new Producto();

            p.ActualizarStockProducto(codigo,cantidad);
        }

        /**
         * Valida stock de producto por cantidad y codigo
         * 
        @param int codigo, int cantidad
        @roseuid 59C5EAFC01B2
        */
        public bool ValidarStock(int cantidad, int codigo)
        {
            bool disponible = false;
            Producto p = new Producto();
            disponible = p.ValidarStock(cantidad, codigo);

            return disponible;
        }

        /**
         * Actualiza stock de productos de la venta por codigos y cantidades
         * 
        @param int codigo, int cantidad
        @roseuid 59C5EAFC01B3
        */
        public void ActualizarStockVenta(int[] codigos, int[] cantidades)
        {
            Producto p = new Producto();
            for (int i = 0; i < codigos.Length; i++)
            {
                p.ActualizarStockProducto(codigos[i],(cantidades[i] * -1));
            }

        }
    }
}
