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
    public partial class IUAdministrador : Form
    {
        string dniAdministrador;

        //Contructor del formulario, carga el dni del administrador que inició sesión
        public IUAdministrador(string dniAdministrador)
        {
            InitializeComponent();
            this.dniAdministrador = dniAdministrador;
        }

        //Este método se ejecuta cuando se abre el formulario
        private void frmAdministrador_Load(object sender, EventArgs e)
        {
            IULogo frm = IULogo.Crear(this);

            frm.Show();
            frm.BringToFront();
        }

        //Abre el formulario Gestionar Producto
        private void btnGestionarProducto_Click(object sender, EventArgs e)
        {
            IUGestionarProducto frm = IUGestionarProducto.Crear(this);

            frm.Show();
        }

        //Abre el formulario Gestionar Trabajador
        private void btnGestionarTrabajador_Click(object sender, EventArgs e)
        {
            IUGestionarTrabajador frm = IUGestionarTrabajador.Crear(this);

            frm.Show();
        }

        private void btnGestionarCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnResumenVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnPedidosRechazados_Click(object sender, EventArgs e)
        {

        }

        private void btnFerreteroMayor_Click(object sender, EventArgs e)
        {

        }

        private void btnVendedorMas_Click(object sender, EventArgs e)
        {

        }
    }
}
