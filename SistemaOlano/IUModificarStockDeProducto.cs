using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioSistemaOlano;

namespace SistemaOlano
{
    public partial class IUModificarStockDeProducto : Form
    {
        #region "Singleton"

        private static IUModificarStockDeProducto frm;

        public static IUModificarStockDeProducto Crear(Form frmPadre)
        {
            if (IUModificarStockDeProducto.frm == null)
            {
                IUModificarStockDeProducto.frm = new IUModificarStockDeProducto()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IUModificarStockDeProducto.frm.BringToFront();

            return IUModificarStockDeProducto.frm;
        }

        private void frmModificarStockProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            IUModificarStockDeProducto.frm = null;
        }

        #endregion

        /**
         * contructor del formulario
         * 
        @roseuid 5B8F65D3030E
        */
        public IUModificarStockDeProducto()
        {
            InitializeComponent();
        }

        /**
         * busca productos segun su nombre
         * 
        @roseuid 5B8F65D3030E
        */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorProducto gP = new GestorProducto();
            Array listProductos;
            string nombre;

            try
            {
                nombre = this.txtNombreBuscar.Text;
                listProductos = gP.CargarProductos(nombre);

                this.MostrarProductos(listProductos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra los productos encontrados en un datagridview
         * 
        @param Array listProductos
        @roseuid 5B8F65D3030E
        */
        private void MostrarProductos(Array listProductos)
        {
            dgvListado.DataSource = null;
            if (listProductos != null && listProductos.Length > 0)
            {
                this.dgvListado.AutoGenerateColumns = false;
                this.dgvListado.DataSource = listProductos;
            }
            else
            {
                this.Notificar("No se encontraron productos con el nombre indicado");
            }
        }

        /**
         * modifica el stock del producto seleccionado
         * 
        @roseuid 5B8F65D3030E
        */
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GestorProducto gP;

            if (this.ValidateChildren() == true)
            {
                gP = new GestorProducto();

                try
                {
                    int codigo = this.CargarCodigoProducto();
                    int cantidad = Int16.Parse(this.numCantidad.Text);

                    gP.ModificarStockProducto(codigo, cantidad);

                    this.numCantidad.Text = this.numCantidad.Minimum.ToString();
                    this.Notificar("Producto modificado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * carga el codigo del producto seleccionado para poder encontrarlo en la base de datos
         * 
        @roseuid 5B8F65D3030E
        */
        private int CargarCodigoProducto()
        {
            Object selectProducto;
            int codigo = -1;

            if (this.dgvListado.CurrentRow != null)
            {
                selectProducto = this.dgvListado.CurrentRow.DataBoundItem;

                if (selectProducto != null)
                {
                    codigo = Int32.Parse(this.dgvListado.CurrentRow.Cells["cdCodigo"].Value.ToString());
                }
                else
                {
                    this.Notificar("No se encontró el producto indicado");
                }
            }
            else
            {
                this.Notificar("Debe seleccionar un producto");
            }

            return codigo;
        }

        /**
         * informa al actor algun msj de informacion
         * 
        @roseuid 5B8F65D3030E
        */
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
