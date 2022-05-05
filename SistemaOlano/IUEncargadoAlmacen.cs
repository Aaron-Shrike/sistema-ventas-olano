using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOlano
{
    public partial class IUEncargadoAlmacen : Form
    {
        string dniEncargado;

        //Contructor del formulario carga el dni del encargado de almacén que inició sesión
        public IUEncargadoAlmacen(string dniEncargado)
        {
            InitializeComponent();
            this.dniEncargado = dniEncargado;
        }

        //Este método se ejecuta cuando se abre el formulario
        private void frmEncargadoAlmacen_Load(object sender, EventArgs e)
        {
            IULogo frm = IULogo.Crear(this);

            frm.Show();
            frm.BringToFront();
        }

        //Abre el formulario Registrar Entrega de Productos
        private void btnRegistrarEntrega_Click(object sender, EventArgs e)
        {
            IURegistrarEntregaDeProductos frm = IURegistrarEntregaDeProductos.Crear(this);

            frm.Show();
        }

        //Abre el formulario Registrar Producto
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            IURegistrarProducto frm = IURegistrarProducto.Crear(this);

            frm.Show();
        }

        //Abre el formulario Modificar Stock
        private void btnModificarStock_Click(object sender, EventArgs e)
        {
            IUModificarStockDeProducto frm = IUModificarStockDeProducto.Crear(this);

            frm.Show();
        }

        //Abre el formulario Registrar Producto Defectuoso Por Garantía
        private void btnProductoDefectuoso_Click(object sender, EventArgs e)
        {
            IURegistrarProductoDefectuosoPorGarantia frm = IURegistrarProductoDefectuosoPorGarantia.Crear(this);

            frm.Show();
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {

        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {

        }
    }
}
