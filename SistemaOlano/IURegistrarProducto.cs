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
    public partial class IURegistrarProducto : Form
    {
        #region "Singleton"

        private static IURegistrarProducto frm;

        public static IURegistrarProducto Crear(Form frmPadre)
        {
            if (IURegistrarProducto.frm == null)
            {
                IURegistrarProducto.frm = new IURegistrarProducto()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarProducto.frm.BringToFront();

            return IURegistrarProducto.frm;
        }

        private void frmRegistrarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarProducto.frm = null;
        }

        #endregion

        /**
         * contructor del formulario
         * 
        @roseuid 5B8F65D302B0
        */
        public IURegistrarProducto()
        {
            InitializeComponent();
        }

        /**
         * al abrir el formulario este evento se activa
         * 
        @roseuid 5B8F65D302B0
        */
        private void frmRegistrarProducto_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        /**
         * carga los datos al ingresar al formulario
         * 
        @roseuid 5B8F65D302B0
        */
        private void CargarDatos()
        {
            this.ListarUnidades();
            this.ListarMarcas();
        }

        /**
         * lista las unidades del producto
         * 
        @roseuid 5B8F65D302B0
        */
        private void ListarUnidades()
        {
            GestorUnidad gU = new GestorUnidad();
            Array listUnidades;

            try
            {
                listUnidades = gU.CargarUnidades();

                this.MostrarUnidades(listUnidades);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra las unidades en un combo box
         * 
        @param Array listUnidades
        @roseuid 5B8F65D302B0
        */
        private void MostrarUnidades(Array listUnidades)
        {
            this.cboUnidad.DataSource = null;
            if (listUnidades.Length > 0)
            {
                this.cboUnidad.ValueMember = "CodUnidad";
                this.cboUnidad.DisplayMember = "Descripcion";
                this.cboUnidad.DataSource = listUnidades;
                this.cboUnidad.SelectedIndex = -1;
            }
            else
            {
                this.Notificar("No hay unidades registradas");
            }
        }

        /**
         * lista las marcas del producto
         * 
        @roseuid 5B8F65D302B0
        */
        private void ListarMarcas()
        {
            GestorMarca gM = new GestorMarca();
            Array listMarcas;

            try
            {
                listMarcas = gM.CargarMarcas();

                this.MostrarMarcas(listMarcas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * muestra las marcas en un combo box
         * 
        @param Array listMarcas
        @roseuid 5B8F65D302B0
        */
        private void MostrarMarcas(Array listMarcas)
        {
            this.cboMarca.DataSource = null;
            if (listMarcas.Length > 0)
            {
                this.cboMarca.ValueMember = "CodMarca";
                this.cboMarca.DisplayMember = "Descripcion";
                this.cboMarca.DataSource = listMarcas;
                this.cboMarca.SelectedIndex = -1;
            }
            else
            {
                this.Notificar("No hay marcas registradas");
            }
        }

        /**
         * registra un nuevo producto
         * 
        @roseuid 5B8F65D302B0
        */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestorProducto gP;

            if (this.ValidateChildren() == true)
            {
                gP = new GestorProducto();

                try
                {
                    string nombre = this.txtNombre.Text;
                    string descripcion = this.txtDescripcion.Text;
                    int codMarca = Int16.Parse(this.cboMarca.SelectedValue.ToString());
                    float precio = float.Parse(this.numPrecio.Text);
                    int codUnidad = Int16.Parse(this.cboUnidad.SelectedValue.ToString());
                    int stock = Int16.Parse(this.numStock.Text);
                    int stockMinimo = Int16.Parse(this.numStockMinimo.Text);

                    gP.RegistrarProducto(nombre, descripcion, codMarca, precio, codUnidad, stock, stockMinimo);

                    this.LimpiarControles();
                    this.Notificar("Producto registrado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * restablece los campos a llenar despues de registrar un producto
         * 
        @roseuid 5B8F65D302B0
        */
        private void LimpiarControles()
        {
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.cboMarca.SelectedIndex = -1;
            this.numPrecio.Text = this.numPrecio.Minimum.ToString();
            this.cboUnidad.SelectedIndex = -1;
            this.numStock.Text = this.numStock.Minimum.ToString();
            this.numStockMinimo.Text = this.numStockMinimo.Minimum.ToString();
        }

        /**
         * informa al actor algun mensaje de informacion
         * 
        @roseuid 5B8F65D302B0
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
