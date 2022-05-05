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
using System.Windows.Forms.VisualStyles;


namespace SistemaOlano
{
    public partial class IURegistrarProductoDefectuosoPorGarantia : Form
    {
        #region "Singleton"

        private static IURegistrarProductoDefectuosoPorGarantia frm;

        public static IURegistrarProductoDefectuosoPorGarantia Crear(Form frmPadre)
        {
            if (IURegistrarProductoDefectuosoPorGarantia.frm == null)
            {
                IURegistrarProductoDefectuosoPorGarantia.frm = new IURegistrarProductoDefectuosoPorGarantia()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarProductoDefectuosoPorGarantia.frm.BringToFront();

            return IURegistrarProductoDefectuosoPorGarantia.frm;
        }

        private void frmRegistrarDefectuoso_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarProductoDefectuosoPorGarantia.frm = null;
        }

        #endregion
        //Inicialización del formulario
        public IURegistrarProductoDefectuosoPorGarantia()
        {
            InitializeComponent();
        }

        //Cierra el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Busca la venta
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           try
            {
                mostrarVenta();   
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Muestra de la venta sus datos y el detalle de la venta
        private void mostrarVenta()
        {

            string[] datos = new string[3];
            string dniTrabajador;
            Array ldv;
            GestorVenta gu = new GestorVenta();
            datos = gu.BuscarVenta1(int.Parse(txtCodigoVenta.Text));
            if (!datos[0].Equals("0"))
            {
                txtFecha.Text = datos[0];
                txtDNIRUC.Text = datos[1];
                txtNombre.Text = datos[2];
                dniTrabajador = datos[3];
               
                ldv = gu.CargarDetalleVenta(int.Parse(txtCodigoVenta.Text));
                this.mostrarDetalleVenta(ldv, dniTrabajador);
                
                ValidarFecha();
            }
            else
            {
                MessageBox.Show("Venta con codigo no registrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //Valida que la fecha sea menor a 7 dias
        private void ValidarFecha()
        {
            string[] fechaVenta = txtFecha.Text.Split('/');
            string[] fechaHoy = System.DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            if ((int.Parse(fechaHoy[0]) - int.Parse(fechaVenta[0])) < 7 && (int.Parse(fechaHoy[1]) - int.Parse(fechaVenta[1])) == 0 && (int.Parse(fechaHoy[2]) - int.Parse(fechaVenta[2])) == 0)
            {
                dgvListadoDetalleVenta.Enabled = true;
                nudCantidadDefectuoso.Enabled = true;
                btnAñadir.Enabled = true;
                btnRegistrar.Enabled = true;
            }
            else
            {
                dgvListadoDetalleVenta.Enabled = false;
                MessageBox.Show("No aplica garantía debido a fecha", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Muestra el detalle de la venta 
        private void mostrarDetalleVenta(Array ldv, string dniTrabajador)
        {
            dgvListadoDetalleVenta.DataSource = null;

            if (ldv != null && ldv.Length > 0)
            {

                dgvListadoDetalleVenta.AutoGenerateColumns = false;
                dgvListadoDetalleVenta.DataSource = ldv;

                for (int i = 0; i < dgvListadoDetalleVenta.RowCount; i++)
                {
                    double precioTotal = double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[3].Value.ToString()) * double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[4].Value.ToString());
                    dgvListadoDetalleVenta.Rows[i].Cells[5].Value = precioTotal.ToString();
                    dgvListadoDetalleVenta.Rows[i].Cells[7].Value = dniTrabajador;
                }
                dgvListadoDetalleVenta.ClearSelection();

            }
            else
            {
                MessageBox.Show("No se encontró detalle de la venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Añade un elemento seleccionado del dgvListadoDetalleVenta al dgvListadoDefectuoso 
        // validando que se haya seleccionado un producto
        // validando que la cantidad a registrar como defectuoso sea menor o igual a la del producto del detalle venta
        // validando que el producto tenga stock disponible para realizar el cambio
        private void btnAñadir_Click(object sender, EventArgs e)
        {

            if (this.dgvListadoDetalleVenta.CurrentRow != null && this.dgvListadoDetalleVenta.CurrentRow.Selected == true)
            {
                int cantidad = Convert.ToInt32(this.nudCantidadDefectuoso.Value);
                int codigo = Int32.Parse(this.dgvListadoDetalleVenta.CurrentRow.Cells["cdCodProducto"].Value.ToString());
                bool Reemplazo=false;

                GestorProducto gP = new GestorProducto();
                if (cantidad <= Int32.Parse(this.dgvListadoDetalleVenta.CurrentRow.Cells["Unidades"].Value.ToString()))
                {
                    if (gP.ValidarStock(cantidad, codigo) == true)
                    {

                        ValidarDevoluciones(Reemplazo, cantidad, codigo);

                    }
                    else
                    {
                        Reemplazo = false;
                        agregarAListadoDefectuoso(cantidad, Reemplazo, codigo);
                        MessageBox.Show("Stock Insuficiente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                    MessageBox.Show("Cantidad de productos defectuosos mayor a la cantidad del producto del detalle venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
        //Valida el número de devoluciones por producto añadido al dgvListadoDefectuoso
        private void ValidarDevoluciones(bool Reemplazo, int cantidad, int codigo)
        {

            if (Int32.Parse(this.dgvListadoDetalleVenta.CurrentRow.Cells["cdND"].Value.ToString()) < 3)
            {
                Reemplazo = true;
                agregarAListadoDefectuoso(cantidad, Reemplazo, codigo);

            }
            else
            {
                Reemplazo = false;

                agregarAListadoDefectuoso(cantidad, Reemplazo, codigo);
                MessageBox.Show("Numero de devoluciones excede el limite, se realizará devolución del dinero", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Agrega producto defectuoso al dgvListadoDefectuoso 
        //Suma una nueva cantidad si el producto ya agregado tiene el mismo codigo del que se quiere agregar
        // Modifica la nueva cantidad en el producto defectuoso agregado al dgvListadoDefectuoso
        private void agregarAListadoDefectuoso(int cantidad, bool Reemplazo, int codigo)
        {

            int index = -1;
            for (int i = 0; i < dgvListadoDefectuoso.Rows.Count; i++)
            {
                if (codigo == Int32.Parse(dgvListadoDefectuoso.Rows[i].Cells[5].Value.ToString()))
                {
                    index = i;
                }
            }
            if (index >= 0)
            {
                bool band = false;
                int nuevaCantidad = Int32.Parse(dgvListadoDefectuoso.Rows[index].Cells[2].Value.ToString()) + cantidad;
                for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
                {
                    if (Int32.Parse(dgvListadoDefectuoso.Rows[index].Cells[5].Value.ToString()) ==
                        Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[0].Value.ToString()))

                    {
                        if (nuevaCantidad <= int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[3].Value.ToString()))
                        {
                            band = true;
                            dgvListadoDefectuoso.Rows[index].Cells[2].Value = nuevaCantidad.ToString();
                        }
                    }

                }
                if (!band)
                    MessageBox.Show("Cantidad del producto defectuoso mayor a la mostrada en el detalle de la venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                index = this.dgvListadoDefectuoso.Rows.Add();
                dgvListadoDefectuoso.Rows[index].Cells[0].Value = dgvListadoDetalleVenta.CurrentRow.Cells[1].Value.ToString();
                dgvListadoDefectuoso.Rows[index].Cells[1].Value = dgvListadoDetalleVenta.CurrentRow.Cells[2].Value.ToString();
                dgvListadoDefectuoso.Rows[index].Cells[2].Value = cantidad;
                dgvListadoDefectuoso.Rows[index].Cells[3].Value = dgvListadoDetalleVenta.CurrentRow.Cells[4].Value.ToString();
                dgvListadoDefectuoso.Rows[index].Cells[5].Value = dgvListadoDetalleVenta.CurrentRow.Cells[0].Value.ToString();
                dgvListadoDefectuoso.Rows[index].Cells[6].Value = Reemplazo;
                double precioTotal = double.Parse(dgvListadoDefectuoso.Rows[index].Cells[2].Value.ToString()) * double.Parse(dgvListadoDefectuoso.Rows[index].Cells[3].Value.ToString());
                dgvListadoDefectuoso.Rows[index].Cells[4].Value = precioTotal.ToString();
            }
            dgvListadoDefectuoso.ClearSelection();
            dgvListadoDetalleVenta.ClearSelection();
            this.nudCantidadDefectuoso.Value = 0;
        }
        //Registra productos defectuosos o actualiza su cantidad si este ya existe
        //Muestra que productos serán reemplazados y a cuales se le realizará la devolución del dinero
        //De los productos que serán reemplazados se actualiza el stock del producto y el número de devoluciones
        // del detalle de la venta aumenta en 1 devolución
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvListadoDefectuoso.RowCount > 0)
            {
                GestorVenta gv = new GestorVenta();
                int cc = 0;
                GestorProductoDefectuoso gpd = new GestorProductoDefectuoso();
                GestorProducto gp = new GestorProducto();

                for (int i = 0; i < dgvListadoDefectuoso.RowCount; i++)
                {
                    if (dgvListadoDefectuoso.Rows[i].Cells[6].Value.ToString().Equals("True"))
                    {
                        cc++;
                    }

                }
                int[] Existencia = new int[dgvListadoDefectuoso.RowCount];
                int[] codProductoD = new int[dgvListadoDefectuoso.RowCount];
                int[] cantidadD = new int[dgvListadoDefectuoso.RowCount];
                int[] codigoA = new int[cc];
                int[] cantidadesA = new int[cc];
                bool band = false;
                for (int i = 0; i < dgvListadoDefectuoso.RowCount; i++)
                {
                    codProductoD[i] = int.Parse(dgvListadoDefectuoso.Rows[i].Cells[5].Value.ToString());
                    cantidadD[i] = int.Parse(dgvListadoDefectuoso.Rows[i].Cells[2].Value.ToString());
                    Existencia[i] = gpd.ValidarExistencia(codProductoD[i]);

                }
                for (int i = 0; i < dgvListadoDefectuoso.RowCount; i++)
                {
                    if (Existencia[i] > 0)
                    {
                        gpd.ActualizarCantidadProductoDefectuoso(codProductoD[i], cantidadD[i]);
                    }
                    else
                    {
                        gpd.RegistrarProductosDefectuoso(codProductoD[i], cantidadD[i]);
                    }
                }
                string[] Reemplazo = new string[dgvListadoDefectuoso.Rows.Count];
                for (int i = 0; i < dgvListadoDefectuoso.Rows.Count; i++)
                {
                    Reemplazo[i] = dgvListadoDefectuoso.Rows[i].Cells[6].Value.ToString();
                }
                int p = 0;
                for (int i = 0; i < dgvListadoDefectuoso.RowCount; i++)
                {
                    if (Reemplazo[i].Equals("True"))
                    {
                        codigoA[p] = int.Parse(dgvListadoDefectuoso.Rows[i].Cells[5].Value.ToString());
                        cantidadesA[p] = int.Parse(dgvListadoDefectuoso.Rows[i].Cells[2].Value.ToString());
                        band = true;
                        p++;
                    }
                }
                
                gp.ActualizarStockVenta(codigoA, cantidadesA);
                gv.ActualizarNumDevoluciones(codigoA, int.Parse(txtCodigoVenta.Text));
                if (band)
                {
                    Notificar("Producto(s) defectuoso(s) registrado(s) Exitosamente, se realizará cambio(s) de producto(s)");
                }
                else
                {
                    MessageBox.Show("Producto(s) defectuoso(s) registrado(s) Exitosamente, se realizará devolución de dinero", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Debe añadir producto defectuoso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvListadoDefectuoso.Rows.Clear();
            txtCodigoVenta.Text = "";
            txtDNIRUC.Text = "";
            txtFecha.Text = "";
            txtNombre.Text = "";
            dgvListadoDetalleVenta.DataSource = null;
            nudCantidadDefectuoso.Value = 0;
        }

        // Informa algun msj al actor
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
