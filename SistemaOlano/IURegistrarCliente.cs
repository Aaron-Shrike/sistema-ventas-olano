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
    public partial class IURegistrarCliente : Form
    {
        #region "Singleton"

        private static IURegistrarCliente frm;

        public static IURegistrarCliente Crear(Form frmPadre)
        {
            if (IURegistrarCliente.frm == null)
            {
                IURegistrarCliente.frm = new IURegistrarCliente()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarCliente.frm.BringToFront();

            return IURegistrarCliente.frm;
        }

        private void frmRegistrarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarCliente.frm = null;
        }

        #endregion

        /**
         * contructor del form recibe opcionalmente el dniRuc de un cliente
         * 
        @param string dniRuc
        @roseuid 5B8F65D2039A
        */
        public IURegistrarCliente(string dniRuc = "")
        {
            InitializeComponent();
            this.CargarDni(dniRuc);
        }

        /**
         * carga el dni que recibio en el contructor
         * 
        @param string dniRuc
        @roseuid 5B8F65D2039A
        */
        private void CargarDni(string dniRuc)
        {
            this.txtDniRucCliente.Text = dniRuc;
        }

        /**
         * registra un nuevo cliente
         * 
        @roseuid 5B8F65D2039A
        */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestorCliente gC;

            if (this.ValidateChildren() == true)
            {
                gC = new GestorCliente();

                try
                {
                    string dniRucCliente = this.txtDniRucCliente.Text;
                    string nombre = this.txtNombre.Text;
                    string telefono = this.txtTelefono.Text;
                    string direccion = this.txtDireccion.Text;

                    gC.RegistrarCliente(dniRucCliente,nombre,telefono,direccion);

                    this.Notificar("Cliente registrado correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * emite un mensaje de informacion para el actor
         * 
        @param string msj
        @roseuid 5B8F65D2039A
        */
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
         * cierra el formulario
         * 
        @roseuid 5B8F65D2039A
        */
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
