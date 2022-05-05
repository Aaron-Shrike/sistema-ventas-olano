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
    public partial class IUVendedor : Form
    {
        string dniVendedor;

        //Contructor del formulario carga el dni del vendedor que inició sesión
        public IUVendedor(string dniVendedor)
        {
            InitializeComponent();
            this.dniVendedor = dniVendedor;
        }

        //Este método se ejecuta cuando se abre el formulario
        private void frmVendedor_Load(object sender, EventArgs e)
        {
            IULogo frm = IULogo.Crear(this);

            frm.Show();
            frm.BringToFront();
        }

        //Abre el formulario Registrar Venta
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            IURegistrarVenta frm = IURegistrarVenta.Crear(this, this.dniVendedor);

            frm.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
