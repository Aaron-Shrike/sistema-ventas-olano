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
    public partial class IUGestionarProducto : Form
    {
        #region "Singleton"

        private static IUGestionarProducto frm;

        public static IUGestionarProducto Crear(Form frmPadre)
        {
            if (IUGestionarProducto.frm == null)
            {
                IUGestionarProducto.frm = new IUGestionarProducto()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IUGestionarProducto.frm.BringToFront();

            return IUGestionarProducto.frm;
        }

        private void frmGestionarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            IUGestionarProducto.frm = null;
        }

        #endregion

        //Contructor del formulario 
        public IUGestionarProducto()
        {
            InitializeComponent();
        }

        //Este método se ejecuta cuando se inicia el formulario
        private void frmGestionarProducto_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        //Cierra el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Carga los datos necesarios para el registro o modificacion de un producto
        private void CargarDatos()
        {
            this.ListarUnidades();
            this.ListarMarcas();
        }

        //Carga las unidades registradas
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

        //Muestra las unidades en un combobox
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

        //Carga las marcas registradas
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

        //Muestra las marcas en un combobox
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

        //Carga los productos registrados, si se ingresa algo en el textbox buscará productos con nombre coincidente
        private void btnListar_Click(object sender, EventArgs e)
        {
            GestorProducto gP = new GestorProducto();
            Array listProductos;
            string nombre;

            try
            {
                nombre = this.txtNombreBuscar.Text;
                listProductos = gP.CargarProductos(nombre);

                this.MostrarProductos(listProductos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra los productos encontrados en un datagridview
        private void MostrarProductos(Array listProductos)
        {
            dgvListado.DataSource = null;
            if (listProductos != null && listProductos.Length > 0)
            {
                this.dgvListado.AutoGenerateColumns = false;
                this.dgvListado.DataSource = listProductos;
            }
            else
            {
                this.Notificar("No se encontraron productos");
            }
        }

        //Permite modificar los datos de un producto ya existente
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Object selectProducto;
            
            if (this.dgvListado.CurrentRow != null)
            {
                selectProducto = this.dgvListado.CurrentRow.DataBoundItem;
                this.CargarDatosProducto(selectProducto);
            }
            else
            {
                this.Notificar("Debe seleccionar un producto");
            }
        }

        //Muestra los datos del producto previamente registrado en los controles del formulario para modificar
        private void CargarDatosProducto(Object selectProducto)
        {
            if (selectProducto != null)
            {
                this.lblNumeroCodigo.Text = this.dgvListado.CurrentRow.Cells["cdCodigo"].Value.ToString();
                this.txtNombre.Text = this.dgvListado.CurrentRow.Cells["cdNombre"].Value.ToString();
                this.txtDescripcion.Text = this.dgvListado.CurrentRow.Cells["cdDescripcion"].Value.ToString();
                this.cboMarca.Text = this.dgvListado.CurrentRow.Cells["cdMarca"].Value.ToString();
                this.numPrecio.Text = this.dgvListado.CurrentRow.Cells["cdPrecio"].Value.ToString();
                this.cboUnidad.Text = this.dgvListado.CurrentRow.Cells["cdUnidad"].Value.ToString();
                this.numStock.Text = this.dgvListado.CurrentRow.Cells["cdStock"].Value.ToString();
                this.numStockMinimo.Text = this.dgvListado.CurrentRow.Cells["cdStockMinimo"].Value.ToString();
                this.chkDadoBaja.Checked = Convert.ToBoolean(this.dgvListado.CurrentRow.Cells["cdDadoBaja"].Value.ToString());
                this.chkDadoBaja.Enabled = true;

                this.ActivarControles(true);
            }
            else
            {
                this.Notificar("No se encontró el producto indicado");
            }
        }

        //Permite el uso de los controles del formulario
        private void ActivarControles(bool estado)
        {
            this.gbEntidad.Enabled = estado;
            this.gbListado.Enabled = !estado;
            if (estado == true)
            {
                this.txtNombre.Focus();
            }
            else
            {
                this.btnListar.Focus();
            }
        }

        //Actualiza un producto existente
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorProducto gP;

            if (this.ValidateChildren() == true)
            {
                gP = new GestorProducto();

                try
                {
                    int codigo = Int16.Parse(this.lblNumeroCodigo.Text);
                    string nombre = this.txtNombre.Text;
                    string descripcion = this.txtDescripcion.Text;
                    int codMarca = Int16.Parse(this.cboMarca.SelectedValue.ToString());
                    float precio = float.Parse(this.numPrecio.Text);
                    int codUnidad = Int16.Parse(this.cboUnidad.SelectedValue.ToString());
                    int stock = Int16.Parse(this.numStock.Text);
                    int stockMinimo = Int16.Parse(this.numStockMinimo.Text);
                    bool dadoBaja = this.chkDadoBaja.Checked;

                    gP.ModificarProducto(codigo,nombre,descripcion,codMarca,precio,codUnidad,stock,stockMinimo,dadoBaja);

                    this.ActivarControles(false);
                    this.btnListar.PerformClick();
                    this.Notificar("Producto modificado correctamente");
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

        //Anula la modificacion
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ActivarControles(false);
        }

    }
}
