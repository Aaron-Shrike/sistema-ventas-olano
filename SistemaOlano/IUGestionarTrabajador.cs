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
    public partial class IUGestionarTrabajador : Form
    {
        #region "Singleton"

        private static IUGestionarTrabajador frm;

        public static IUGestionarTrabajador Crear(Form frmPadre)
        {
            if (IUGestionarTrabajador.frm == null)
            {
                IUGestionarTrabajador.frm = new IUGestionarTrabajador()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IUGestionarTrabajador.frm.BringToFront();

            return IUGestionarTrabajador.frm;
        }

        private void frmGestionarTrabajador_FormClosed(object sender, FormClosedEventArgs e)
        {
            IUGestionarTrabajador.frm = null;
        }

        #endregion

        //Contructor del formulario 
        public IUGestionarTrabajador()
        {
            InitializeComponent();
        }

        private bool TrabajadorNuevo;

        //Este método se ejecuta cuando se inicia el formulario
        private void frmGestionarTrabajador_Load(object sender, EventArgs e)
        {
            this.ListarTiposTrabajador();
        }

        //Carga los tipos de trabajador registrados
        private void ListarTiposTrabajador()
        {
            GestorTipoTrabajador gTt = new GestorTipoTrabajador();
            Array listTipos;

            try
            {
                listTipos = gTt.CargarTiposTrabajador();

                this.MostrarTiposTrabajadores(listTipos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra los tipos de trabajador en un combobox
        private void MostrarTiposTrabajadores(Array listTipos)
        {
            this.cboTipoTrabajador.DataSource = null;
            if (listTipos.Length > 0)
            {
                this.cboTipoTrabajador.ValueMember = "CodTipoTrabajador";
                this.cboTipoTrabajador.DisplayMember = "Descripcion";
                this.cboTipoTrabajador.DataSource = listTipos;
                this.cboTipoTrabajador.SelectedIndex = -1;
            }
            else
            {
                this.Notificar("No hay tipos de trabajador registrados");
            }
        }

        //Carga los trabajadores registrados, si se ingresa algo en el textbox buscará trabajadores con nombre coincidente
        private void btnListar_Click(object sender, EventArgs e)
        {
            GestorTrabajador gT = new GestorTrabajador();
            Array listTrabajadores;
            string nombre;

            try
            {
                nombre = this.txtNombreBuscar.Text;
                listTrabajadores = gT.CargarTrabajadores(nombre);

                this.MostrarTrabajadores(listTrabajadores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra los trabajadores encontrados en un datagridview
        private void MostrarTrabajadores(Array listTrabajadores)
        {
            dgvListado.DataSource = null;
            if (listTrabajadores != null && listTrabajadores.Length > 0)
            {
                this.dgvListado.AutoGenerateColumns = false;
                this.dgvListado.DataSource = listTrabajadores;
            }
            else
            {
                this.Notificar("No se encontraron trabajadores");
            }
        }

        //Activa el registro de un nuevo trabajador
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.ActivarControles(true);
            this.LimpiarControles();
            this.TrabajadorNuevo = true;
            this.txtDni.Enabled = true;
        }

        //Deja en blanco los controles del formulario
        private void LimpiarControles()
        {
            this.txtDni.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.cboTipoTrabajador.SelectedIndex = -1;
            this.chkDadoBaja.Checked = true;
            this.chkDadoBaja.Enabled = false;
            this.txtContraseña.Text = "";
        }

        //Permite el uso de los controles del formulario
        private void ActivarControles(bool estado)
        {
            this.gbEntidad.Enabled = estado;
            this.gbListado.Enabled = !estado;
            if (estado == true)
            {
                this.txtDni.Focus();
            }
            else
            {
                this.btnListar.Focus();
            }
        }

        //Permite modificar los datos de un trabajador ya existente
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Object selectTrabajador;

            if (this.dgvListado.CurrentRow != null)
            {
                selectTrabajador = this.dgvListado.CurrentRow.DataBoundItem;
                this.CargarDatosTrabajador(selectTrabajador);
            }
            else
            {
                this.Notificar("Debe seleccionar un trabajador");
            }
        }

        //Muestra los datos del trabajador previamente registrado en los controles del formulario para modificar
        private void CargarDatosTrabajador(object selectTrabajador)
        {
            if (selectTrabajador != null)
            {
                this.TrabajadorNuevo = false;
                this.txtDni.Text = this.dgvListado.CurrentRow.Cells["cdDni"].Value.ToString();
                this.txtDni.Enabled = false;
                this.txtNombre.Text = this.dgvListado.CurrentRow.Cells["cdNombre"].Value.ToString();
                this.txtDireccion.Text = this.dgvListado.CurrentRow.Cells["cdDireccion"].Value.ToString();
                this.txtTelefono.Text = this.dgvListado.CurrentRow.Cells["cdTelefono"].Value.ToString();
                this.cboTipoTrabajador.Text = this.dgvListado.CurrentRow.Cells["cdTipoTrabajador"].Value.ToString();
                this.chkDadoBaja.Checked = Convert.ToBoolean(this.dgvListado.CurrentRow.Cells["cdDadoBaja"].Value.ToString());
                this.chkDadoBaja.Enabled = true;
                this.txtContraseña.Text = "";

                this.ActivarControles(true);
            }
            else
            {
                this.Notificar("No se encontró el trabajador indicado");
            }
        }

        //Registra un nuevo trabajador o actualiza uno existente dependiendo de la forma en que se acccedio a los controles
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorTrabajador gT;

            if (this.ValidateChildren() == true)
            {
                gT = new GestorTrabajador();

                try
                {
                    string dni = this.txtDni.Text;
                    string nombre = this.txtNombre.Text;
                    string direccion = this.txtDireccion.Text;
                    string telefono = this.txtTelefono.Text;
                    int codTipoTrabajador = Int16.Parse(this.cboTipoTrabajador.SelectedValue.ToString());
                    bool dadoBaja = this.chkDadoBaja.Checked;
                    string contraseña = this.txtContraseña.Text;


                    if (this.TrabajadorNuevo)
                    {
                        gT.RegistrarTrabajador(dni, nombre, direccion, telefono, codTipoTrabajador, contraseña);
                        this.Notificar("Trabajador registrado correctamente");
                    }
                    else
                    {
                        gT.ModificarTrabajador(dni, nombre, direccion, telefono, codTipoTrabajador, dadoBaja, contraseña);
                        this.Notificar("Trabajador modificado correctamente");
                    }
                    
                    this.ActivarControles(false);
                    this.btnListar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Emite un mensaje de informacion para el actor
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Anula el registro o modificacion de un trabajador
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ActivarControles(false);
        }

        //Cierra el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
