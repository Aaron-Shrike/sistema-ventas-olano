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
using System.Globalization;

namespace SistemaOlano
{
    public partial class IURegistrarVenta : Form
    {
        #region "Singleton"

        private static IURegistrarVenta frm;

        public static IURegistrarVenta Crear(Form frmPadre, string dni)
        {
            if( IURegistrarVenta.frm == null)
            {
                IURegistrarVenta.frm = new IURegistrarVenta(dni)
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarVenta.frm.BringToFront();

            return IURegistrarVenta.frm;
        }

        private void frmRegistrarVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
          IURegistrarVenta.frm = null;
        }

        #endregion

        private string dniTrabajador;

        //Contructor del formulario carga el dni del vendedor que inició sesión
        public IURegistrarVenta(string dni = "")
        {
            InitializeComponent();
            this.dniTrabajador = dni;
        }

        //Este método se ejecuta cuando se abre el formulario
        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

        //Busca productos que coincidan con el texto ingresado en el formulario
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorProducto gP = new GestorProducto();
            Array listProductos;
            string producto;

            try
            {
                producto = this.txtProducto.Text;
                listProductos = gP.CargarProductos(producto);
                this.MostrarListaProductos(listProductos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra los productos que coincidieron con la búsqueda
        private void MostrarListaProductos(Array listProductos)
        {
            dgvProductos.DataSource = null;
            if (listProductos != null && listProductos.Length > 0)
            {
                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = listProductos;
                dgvProductos.ClearSelection();
            }
            else
            {
                MessageBox.Show("No se encontraron productos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Verifica si el stock del producto es suficiente para cubrir la cantidad deseada
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.CurrentRow != null && this.dgvProductos.CurrentRow.Selected == true)
            {
                GestorProducto gP = new GestorProducto();
                int cantidad = Convert.ToInt32(this.nudUnidades.Value);
                int codigo = Int32.Parse(this.dgvProductos.CurrentRow.Cells["Codigo"].Value.ToString());
                bool duplicado = false;

                for (int i = 0; i < dgvDetalleVenta.Rows.Count; i++)
                {
                    if (codigo == Int32.Parse(dgvDetalleVenta.Rows[i].Cells[0].Value.ToString()))
                    {

                        duplicado = true;
                        cantidad = Int32.Parse(dgvDetalleVenta.Rows[i].Cells[3].Value.ToString()) + cantidad;
                        if(gP.ValidarStock(cantidad,codigo))
                        {
                            AgregarProductoLista(cantidad, codigo, i);
                        }
                        else
                        {
                            Notificar("Stock insuficiente");
                        }
                        
                    }
                }
                if (duplicado == false)
                {
                    if (gP.ValidarStock(cantidad, codigo))
                    {
                        AgregarProductoLista(cantidad, codigo);
                    }
                    else
                    {
                        Notificar("Stock insuficiente"); ;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Agrega un producto del datagridview de productos coincidentes, al datagridview de productos que se registrarán 
        //en la venta
        private void AgregarProductoLista(int cantidad, int codigo, int index = -1)
        {
            if (index >= 0)
            {
                dgvDetalleVenta.Rows[index].Cells[3].Value = cantidad.ToString();
            }
            else
            {
                index = this.dgvDetalleVenta.Rows.Add();
                dgvDetalleVenta.Rows[index].Cells[0].Value = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                dgvDetalleVenta.Rows[index].Cells[1].Value = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                dgvDetalleVenta.Rows[index].Cells[2].Value = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                dgvDetalleVenta.Rows[index].Cells[4].Value = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                dgvDetalleVenta.Rows[index].Cells[3].Value = cantidad;
            }

            double totalProducto = cantidad * double.Parse(this.dgvDetalleVenta.Rows[index].Cells[4].Value.ToString());
            double subtotal = double.Parse(this.textBox2.Text) + totalProducto;
            this.textBox2.Text = subtotal.ToString();
            double igv = 0.18 * subtotal;
            this.textBox1.Text = igv.ToString();
            double total = subtotal + igv;
            this.txtTotal.Text = total.ToString();
            dgvProductos.ClearSelection();
            dgvDetalleVenta.ClearSelection();
            this.nudUnidades.Value = 0;
        }

        //Actualiza el stock de los productos a registrar en la venta
        //Registra la venta y obtiene su código
        //Registra los detalles de la venta
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalleVenta.Rows.Count > 0)
            {
                GestorProducto gP = new GestorProducto();
                GestorVenta gV = new GestorVenta();
                int codVenta = 0;
                int longitud = this.dgvDetalleVenta.Rows.Count;
                int[] codigos = new int[longitud];
                int[] cantidades = new int[longitud];
                string[] precios = new string[longitud];
                for (int i = 0; i < longitud; i++)
                {
                    codigos[i] = Int32.Parse(dgvDetalleVenta.Rows[i].Cells[0].Value.ToString());
                    cantidades[i] = Int32.Parse(dgvDetalleVenta.Rows[i].Cells[3].Value.ToString());
                    precios[i] = dgvDetalleVenta.Rows[i].Cells[4].Value.ToString();
                }
                gP.ActualizarStockVenta(codigos, cantidades);
                codVenta = gV.RegistrarVenta(DateTime.ParseExact(this.lblFecha.Text, "dd/MM/yyyy",CultureInfo.InvariantCulture), this.dniTrabajador, this.txtTotal.Text);
                gV.RegistrarDetalleVenta(codVenta, codigos, cantidades, precios);
                dgvDetalleVenta.Rows.Clear();
                dgvProductos.DataSource = null;
                Notificar("Venta registrada exitosamente, CODIGO: "+ codVenta.ToString());
            }
            else
            {
               Notificar("Debe añadir al menos un producto");
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
