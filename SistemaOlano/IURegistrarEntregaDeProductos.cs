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
    public partial class IURegistrarEntregaDeProductos : Form
    {
        #region "Singleton"

        private static IURegistrarEntregaDeProductos frm;

        public static IURegistrarEntregaDeProductos Crear(Form frmPadre)
        {
            if (IURegistrarEntregaDeProductos.frm == null)
            {
                IURegistrarEntregaDeProductos.frm = new IURegistrarEntregaDeProductos()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarEntregaDeProductos.frm.BringToFront();

            return IURegistrarEntregaDeProductos.frm;
        }

        private void frmRegistrarEntrega_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarEntregaDeProductos.frm = null;
        }

        #endregion

        //Contructor del formulario
        public IURegistrarEntregaDeProductos()
        {
            InitializeComponent();
        }

        //Busca la venta cuyo código fue ingresado en el formulario
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorVenta gV = new GestorVenta();
            int codigo;
            string[] datos;
            Array ldv;

            try
            {
                codigo = Int32.Parse(this.textBox5.Text);
                datos = gV.BuscarVenta(codigo);

                if (byte.Parse(datos[3]) == 2)
                {
                    textBox6.Text = datos[1];
                    textBox1.Text = datos[2];
                    ldv = gV.CargarDetalleVenta(codigo);
                    mostrarDetalleVenta(ldv);
                    this.label5.Text = codigo.ToString();
                }
                else
                {
                    textBox6.Text = "";
                    textBox1.Text = "";
                    dataGridView2.DataSource = null;
                    MessageBox.Show("La venta aún no ha sido pagada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra los detalles de la venta en un datagridview si esta fue encontrada
        private void mostrarDetalleVenta(Array ldv)
        {
            dataGridView2.DataSource = null;

            if (ldv != null && ldv.Length > 0)
            {

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = ldv;
                dataGridView2.ClearSelection();

            }
            else
            {
                MessageBox.Show("No se encontró detalle de la venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Modifica el estado de la venta a pagado 
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                GestorVenta gV = new GestorVenta();
                try
                {
                    int codigo = Int32.Parse(this.label5.Text);
                    gV.EstadoVenta(codigo, 3);
                    Notificar("Entrega registrada exitosamente");
                    this.dataGridView2.DataSource = null;
                    this.textBox5.Text = "";
                    this.textBox6.Text = "";
                    this.textBox1.Text = "";
                    this.textBox5.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe buscar una venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Emite un mensaje de informacion para el actor
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Cierra el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
