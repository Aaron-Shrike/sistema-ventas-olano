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
    public partial class IURegistrarPedido : Form
    {
        #region "Singleton"

        private static IURegistrarPedido frm;

        public static IURegistrarPedido Crear(Form frmPadre, string dni)
        {
            if (IURegistrarPedido.frm == null)
            {
                IURegistrarPedido.frm = new IURegistrarPedido(dni)
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarPedido.frm.BringToFront();

            return IURegistrarPedido.frm;
        }

        private void frmRegistrarPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarPedido.frm = null;
        }

        #endregion

        /**
         * contructor del formulario recibe el dni del trabajador
         * 
        @roseuid 5B8F65D303AA
         */
        public IURegistrarPedido(string dni = "")
        {
            InitializeComponent();
            this.CargarTrabajador(dni);
        }

        /**
         * este evento se activa al iniciar el formulario
         * 
        @roseuid 5B8F65D4002F
         */
        private void frmRegistrarPedido_Load(object sender, EventArgs e)
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
            this.CargarFecha();
        }

        /**
         * carga la fecha actual de la pc
         * 
        @roseuid 5B8F65D4002F
         */
        private void CargarFecha()
        {
            DateTime fecha = DateTime.Now;

            lblFechaActual.Text = fecha.ToString("dd/MM/yyyy");
        }

        /**
         * carga los datos del trabajador que realizara el pedido
         * 
        @param string dniTrabajador
        @roseuid 5B8F65D4002F
         */
        private void CargarTrabajador(string dniTrabajador)
        {
            GestorTrabajador gT = new GestorTrabajador();
            string nombre;

            try
            {
                nombre = gT.CargarNombreTrabajador(dniTrabajador);

                if (nombre.Length > 0)
                {
                    this.MostrarTrabajador(dniTrabajador, nombre);
                }
                else {
                    this.Notificar("Trabajador no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra los datos del trabajador encontrado
         * 
        @param string dniTrabajador, string nombre
        @roseuid 5B8F65D4002F
         */
        private void MostrarTrabajador(string dniTrabajador, string nombre)
        {
            lblNombreTrabajador.Text = nombre;
            lblDniTrabajador.Text = dniTrabajador;
        }

        /**
         * busca un cliente segun el dni ingresado
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorCliente gC = new GestorCliente();
            string nombre;
            string dniRucCliente;
            
            try
            {
                dniRucCliente = txtDni.Text;
                nombre = gC.BuscarNombreCliente(dniRucCliente);

                if (nombre.Length > 0)
                {
                    this.MostrarCliente(dniRucCliente, nombre);
                }
                else 
                {
                    this.Notificar("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra el cliente encontrado
         * 
        @param string dniRucCliente, string nombre
        @roseuid 5B8F65D4002F
         */
        private void MostrarCliente(string dniRucCliente, string nombre)
        {
            lblNombreCliente.Text = nombre;
            lblDniRucCliente.Text = dniRucCliente;
        }

        /**
         * inicia el formulario de registrar cliente
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            string dniCliente = txtDni.Text;

            IURegistrarCliente frm = new IURegistrarCliente(dniCliente);
            
            frm.ShowDialog();
        }

        /**
         * limpia las especificaciones ingresadas por el actor
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtEspecificaciones.Text = "";
            this.txtEspecificaciones.Focus();
        }

        /**
         * registra un nuevo pedido
         * 
        @roseuid 5B8F65D4002F
         */
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            GestorPedido gP;

            if (this.ValidateChildren() == true)
            {
                gP = new GestorPedido();

                try
                {
                    string dniRucCliente = this.lblDniRucCliente.Text;
                    string dniTrabajador = this.lblDniTrabajador.Text;
                    string especificaciones = this.txtEspecificaciones.Text;
                    DateTime fecha = DateTime.Now;

                    gP.RegistrarPedido(dniRucCliente, dniTrabajador, especificaciones, fecha);

                    this.LimpiarControles();
                    this.Notificar("Pedido registrado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * limpia los datos ingresados y buscados por el actor
         * 
        @roseuid 5B8F65D4002F
         */
        private void LimpiarControles()
        {
            this.txtDni.Text = "";
            this.lblNombreCliente.Text = "-";
            this.lblDniRucCliente.Text = "-";
            this.txtEspecificaciones.Text = "";
        }

        /**
         * informa algun msj al actor
         * 
        @param string msj
        @roseuid 5B8F65D4002F
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
