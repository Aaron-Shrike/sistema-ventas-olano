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
using System.Globalization;


namespace SistemaOlano
{
    public partial class IURegistrarDevolucionDeDineroPorGarantia : Form
    {
        #region "Singleton"

        private static IURegistrarDevolucionDeDineroPorGarantia frm;

        public static IURegistrarDevolucionDeDineroPorGarantia Crear(Form frmPadre)
        {
            if (IURegistrarDevolucionDeDineroPorGarantia.frm == null)
            {
                IURegistrarDevolucionDeDineroPorGarantia.frm = new IURegistrarDevolucionDeDineroPorGarantia()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarDevolucionDeDineroPorGarantia.frm.BringToFront();

            return IURegistrarDevolucionDeDineroPorGarantia.frm;
        }

        private void frmRegistrarDevolucionDinero_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarDevolucionDeDineroPorGarantia.frm = null;
        }

        #endregion
        //Inicialización del formulario
        string dniTrabajador;
        public IURegistrarDevolucionDeDineroPorGarantia()
        {
            InitializeComponent();
        }
        
        //Cierra el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Busca la venta
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
        //Muestra la venta si esta fue encontrada sus datos y detalle de venta
        private void mostrarVenta()
        {
            string[] datos = new string[3];

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
            }
            else
            {
                MessageBox.Show("Venta con codigo no registrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Muestra el detalle de venta
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
        //Añade un producto al dgvListadoDevolver
        //Validando que se haya seleccionado un producto
        //validando que la cantidad a registrar como devolución sea menor o igual a la del producto del detalle venta
        private void btnAñadir_Click(object sender, EventArgs e)
        {

            if (this.dgvListadoDetalleVenta.CurrentRow != null && this.dgvListadoDetalleVenta.CurrentRow.Selected == true)
            {
                int codigo = Int32.Parse(this.dgvListadoDetalleVenta.CurrentRow.Cells["cdCodigo"].Value.ToString());
                int cantidad = Convert.ToInt32(this.nudCantidadDevolver.Value);

                if (cantidad <= Int32.Parse(this.dgvListadoDetalleVenta.CurrentRow.Cells["Unidades"].Value.ToString()))
                {

                    int index = -1;
                    for (int i = 0; i < dgvListadoDevolver.Rows.Count; i++)
                    {
                        if (codigo == Int32.Parse(dgvListadoDevolver.Rows[i].Cells[0].Value.ToString()))
                        {
                            index = i;
                        }
                    }
                    if (index >= 0)
                    {
                        bool band = false;
                        int nuevaCantidad = Int32.Parse(dgvListadoDevolver.Rows[index].Cells[3].Value.ToString()) + cantidad;
                        for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
                        {
                            if (Int32.Parse(dgvListadoDevolver.Rows[index].Cells[0].Value.ToString()) ==
                                Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[0].Value.ToString()))
                            {
                                if (nuevaCantidad <= int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[3].Value.ToString()))
                                {
                                    band = true;
                                    dgvListadoDevolver.Rows[index].Cells[3].Value = nuevaCantidad.ToString();
                                }
                            }

                        }
                        if (!band)
                            MessageBox.Show("Cantidad del producto para la devolución de dinero mayor a la mostrada en el detalle de la venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        index = this.dgvListadoDevolver.Rows.Add();
                        dgvListadoDevolver.Rows[index].Cells[0].Value = dgvListadoDetalleVenta.CurrentRow.Cells[0].Value.ToString();
                        dgvListadoDevolver.Rows[index].Cells[1].Value = dgvListadoDetalleVenta.CurrentRow.Cells[1].Value.ToString();
                        dgvListadoDevolver.Rows[index].Cells[2].Value = dgvListadoDetalleVenta.CurrentRow.Cells[2].Value.ToString();
                        dgvListadoDevolver.Rows[index].Cells[3].Value = cantidad;
                        dgvListadoDevolver.Rows[index].Cells[4].Value = dgvListadoDetalleVenta.CurrentRow.Cells[4].Value.ToString();
                        double precioTotal = double.Parse(dgvListadoDevolver.Rows[index].Cells[3].Value.ToString()) * double.Parse(dgvListadoDevolver.Rows[index].Cells[4].Value.ToString());
                        dgvListadoDevolver.Rows[index].Cells[5].Value = precioTotal.ToString();
                        dgvListadoDevolver.Rows[index].Cells[6].Value = dgvListadoDetalleVenta.CurrentRow.Cells[6].Value.ToString();
                        dgvListadoDevolver.Rows[index].Cells[7].Value = int.Parse(dgvListadoDetalleVenta.CurrentRow.Cells[3].Value.ToString()) - cantidad;
                    }


                    dgvListadoDevolver.ClearSelection();
                    dgvListadoDetalleVenta.ClearSelection();
                    this.nudCantidadDevolver.Value = 0;


                }
                else
                {
                    MessageBox.Show("Cantidad de productos a devolver excede el stock de la cantidad del producto del detalle de la venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Registra devolución de dinero, actualiza el estado de la venta a dar de baja 
        //Recorre los dos dgv, comparando si los códigos de los productos coinciden
        //asigna el valor de de la cantidad que queda a una fila del detalle de venta.
        //Si no coinciden se les asignará -1
        //Verifica la cantidad de productos que quedan en la venta, si esta tiene mas productos registra nueva venta
        //Si no queda ninguno muestra mensaje Estado de la venta actualizado, se realizará devolución del dinero
        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {


            int c = 0;
            GestorVenta gv = new GestorVenta();

            gv.EstadoVenta(Int32.Parse(txtCodigoVenta.Text), 4);
            if (this.dgvListadoDevolver.Rows.Count > 0)
            {

                for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvListadoDevolver.Rows.Count; j++)
                    {
                        if (dgvListadoDetalleVenta.Rows[i].Cells[0].Value.ToString().Equals(dgvListadoDevolver.Rows[j].Cells[0].Value.ToString()))
                        {
                            dgvListadoDetalleVenta.Rows[i].Cells[8].Value = int.Parse(dgvListadoDevolver.Rows[j].Cells[7].Value.ToString());

                        }
                        else
                        {
                            dgvListadoDetalleVenta.Rows[i].Cells[8].Value = -1;
                        }
                    }

                }
                bool band = false;
                for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
                {
                    if (dgvListadoDetalleVenta.Rows.Count == 1 && int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString()) == 0)
                    {
                        band = true;
                    }

                }
                if (band)
                {
                    MessageBox.Show("Estado de la venta actualizado, se realizará devolución del dinero", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    registrarNuevaVenta(c, gv);
                }
            }

            else
            {
                MessageBox.Show("Debe añadir un producto a devolver", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvListadoDevolver.Rows.Clear();
            txtCodigoVenta.Text = "";
            txtDNIRUC.Text = "";
            txtFecha.Text = "";
            txtNombre.Text = "";
            dgvListadoDetalleVenta.DataSource = null;
            nudCantidadDevolver.Value = 0;
        }
        //Registra nueva venta verificando que la cantidad que queda del producto sea mayor a 0, agrega producto a nueva venta
        //si la cantidad que queda es -1 entonces considera la cantidad original del detalle de la venta, agrega producto a nueva venta
        //Sino omite ese producto
        //Registra los datos de la venta
        //Registra el detalle de esta con los productos agregados a la nueva venta
        //Notifica("Venta nueva generada sin productos defectuosos exitosamente se realizará la devolución del dinero");
        private void registrarNuevaVenta(int c, GestorVenta gv)
        {
            for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
            {
                if (int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString()) == 0)
                {
                    c++;
                }
            }
            int codVenta = 0;
            double PT = 0;
            int longuitud = this.dgvListadoDetalleVenta.Rows.Count - c;
            int[] codigos = new int[longuitud];
            int[] cantidades = new int[longuitud];
            string[] precios = new string[longuitud];
            int p = 0;
            for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
            {
                if (int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString()) > 0)
                {
                    codigos[p] = Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[0].Value.ToString());
                    cantidades[p] = Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString());
                    precios[p] = dgvListadoDetalleVenta.Rows[i].Cells[4].Value.ToString();
                    PT += double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString()) *
                        double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[4].Value.ToString());
                    p++;
                }

            }
            for (int i = 0; i < dgvListadoDetalleVenta.Rows.Count; i++)
            {
                if (int.Parse(dgvListadoDetalleVenta.Rows[i].Cells[8].Value.ToString()) == -1)
                {
                    codigos[p] = Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[0].Value.ToString());
                    cantidades[p] = Int32.Parse(dgvListadoDetalleVenta.Rows[i].Cells[3].Value.ToString());
                    precios[p] = dgvListadoDetalleVenta.Rows[i].Cells[4].Value.ToString();
                    PT += double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[3].Value.ToString()) *
                        double.Parse(dgvListadoDetalleVenta.Rows[i].Cells[4].Value.ToString());
                    p++;
                }
            }
            codVenta = gv.RegistrarVentaV(DateTime.ParseExact(this.txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), this.dniTrabajador, this.txtDNIRUC.Text, PT.ToString());
            gv.RegistrarDetalleVenta(codVenta, codigos, cantidades, precios);
            Notificar("Venta nueva generada sin productos defectuosos exitosamente se realizará la devolución del dinero");
        }

        // Informa algun msj al actor
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
