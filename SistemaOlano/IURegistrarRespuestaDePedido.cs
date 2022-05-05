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
    public partial class IURegistrarRespuestaDePedido : Form
    {
        #region "Singleton"

        private static IURegistrarRespuestaDePedido frm;

        public static IURegistrarRespuestaDePedido Crear(Form frmPadre)
        {
            if (IURegistrarRespuestaDePedido.frm == null)
            {
                IURegistrarRespuestaDePedido.frm = new IURegistrarRespuestaDePedido()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarRespuestaDePedido.frm.BringToFront();

            return IURegistrarRespuestaDePedido.frm;
        }

        private void frmRegistrarRespuesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarRespuestaDePedido.frm = null;
        }

        #endregion

        /**
         * contructor del formulario
         * 
        @roseuid 5B8F65D4002F
         */
        public IURegistrarRespuestaDePedido()
        {
            InitializeComponent();
        }

        /**
         * este evento se activa al iniciar el formulario
         * 
        @roseuid 5B8F65D4002F
         */
        private void frmRegistrarRespuesta_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        /**
         * carga los datos iniciales del formulario
         * 
        @roseuid 5B8F65D4002F
         */
        private void CargarDatos()
        {
            this.ListarEstados();
        }

        /**
         * lista los estados del pedido
         * 
        @roseuid 5B8F65D4002F
         */
        private void ListarEstados()
        {
            GestorEstadoPedido gEP;
            Array listEstados;

            try
            {
                gEP = new GestorEstadoPedido();

                listEstados = gEP.CargarEstados();

                this.MostrarEstados(listEstados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra los estados en un combo box
         * 
        @param Array listEstados
        @roseuid 5B8F65D4002F
         */
        private void MostrarEstados(Array listEstados)
        {
            this.cboEstado.DataSource = null;
            if (listEstados.Length > 0)
            {
                this.cboEstado.ValueMember = "CodEstadoPedido";
                this.cboEstado.DisplayMember = "Descripcion";
                this.cboEstado.DataSource = listEstados;
                this.cboEstado.SelectedIndex = -1;
            }
            else
            {
                this.Notificar("No hay estados registrados");
            }
        }


        /**
         * busca un pedido segun el codigo ingresado
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorPedido gP;
            string codigoPedido;
            string[] datosPedido;
            
            try
            {
                gP = new GestorPedido();
                codigoPedido = this.txtCodigoBuscar.Text;

                datosPedido = gP.BuscarPedido(codigoPedido);
                this.MostrarPedido(datosPedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra el pedido encontrado
         * 
        @param string[] datosPedido
        @roseuid 5B8F65D4002F
         */
        private void MostrarPedido(string[] datosPedido)
        {
            if (datosPedido != null) 
            {
                this.lblCodigoPedido.Text = this.txtCodigoBuscar.Text;
                this.lblDatosTrabajador.Text = datosPedido[0];
                this.lblDatosCliente.Text = datosPedido[1];
                this.cboEstado.Text = datosPedido[2];
                this.txtEspecificaciones.Text = datosPedido[3];
            }
        }

        /**
         * registra la respuesta en el pedido
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestorPedido gP;
            string codigoPedido;
            string codigoEstadoPedido;
            
            if (this.ValidateChildren() == true)
            {
                gP = new GestorPedido();

                try
                {
                    codigoPedido = this.lblCodigoPedido.Text;
                    codigoEstadoPedido = this.cboEstado.SelectedValue.ToString();

                    gP.RegistrarRespuesta(codigoPedido,codigoEstadoPedido);

                    this.LimpiarControles();
                    this.Notificar("Respuesta de pedido registrada correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * Limpia todos los datos ingresador y buscador por el actor
         * 
        @roseuid 5B8F65D4002F
         */
        private void LimpiarControles()
        {
            this.txtCodigoBuscar.Text = "";
            this.lblCodigoPedido.Text = "-";
            this.lblDatosTrabajador.Text = "-";
            this.lblDatosCliente.Text = "-";
            this.cboEstado.SelectedIndex = -1;
            this.txtEspecificaciones.Text = "";
        }

        /**
         * informa al actor un msj de informacion
         * 
        @param msjModificado
        @roseuid 59C5EBA1026E
         */
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
        * cierra el formulario
        * 
       @roseuid 5B8F65D4002F
        */
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
