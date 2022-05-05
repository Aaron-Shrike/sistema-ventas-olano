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
    public partial class IUCajero : Form
    {
        string dniCajero;

        //Contructor del formulario carga el dni del cajero que inició sesión
        public IUCajero(string dniCajero)
        {
            InitializeComponent();
            this.dniCajero = dniCajero;
        }

        //Este método se ejecuta cuando se abre el formulario
        private void frmCajero_Load(object sender, EventArgs e)
        {
            IULogo frm = IULogo.Crear(this);

            frm.Show();
            frm.BringToFront();
        }

        //Abre el formulario Registrar Pago
        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            IURegistrarPago frm = IURegistrarPago.Crear(this);

            frm.Show();
        }

        //Abre el formulario Registrar Pedido
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            IURegistrarPedido frm = IURegistrarPedido.Crear(this, this.dniCajero);

            frm.Show();
        }

        //Abre el formulario Registrar Respuesta de Pedido
        private void btnRespuesta_Click(object sender, EventArgs e)
        {
            IURegistrarRespuestaDePedido frm = IURegistrarRespuestaDePedido.Crear(this);

            frm.Show();
        }

        //Abre el formulario Registrar Solicitud de Abastecimiento
        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            IURegistrarSolicitudDeAbastecimiento frm = IURegistrarSolicitudDeAbastecimiento.Crear(this,this.dniCajero);

            frm.Show();
        }

        //Abre el formulario Registrar Devolución de Dinero Por Garantía
        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            IURegistrarDevolucionDeDineroPorGarantia frm = IURegistrarDevolucionDeDineroPorGarantia.Crear(this);

            frm.Show();
        }


        private void btnListarVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnListarPedido_Click(object sender, EventArgs e)
        {

        }
    }
}
