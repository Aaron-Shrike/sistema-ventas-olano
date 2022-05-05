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
using System.Drawing.Printing;


namespace SistemaOlano
{
    public partial class IURegistrarPago : Form
    {
        #region "Singleton"

        private static IURegistrarPago frm;

        public static IURegistrarPago Crear(Form frmPadre)
        {
            if (IURegistrarPago.frm == null)
            {
                IURegistrarPago.frm = new IURegistrarPago()
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarPago.frm.BringToFront();

            return IURegistrarPago.frm;
        }

        private void frmRegistrarPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarPago.frm = null;
        }

        #endregion

        private Image boletaModelo;

        //Contructor del formulario inicializa el formato del comprobante de pago
        public IURegistrarPago()
        {
            InitializeComponent();
            boletaModelo = SistemaOlano.Properties.Resources.boletaModelo;
        }

        //Busca una venta de acuerdo al codigo ingresado en el formulario
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            GestorVenta gV = new GestorVenta();
            int codigo;
            string[] datos;
            Array ldv;

            try
            {
                codigo = Int32.Parse(this.textBox5.Text);

                datos = gV.ObtenerMonto(codigo);

                if (byte.Parse(datos[0]) == 1)
                {
                    lblCodigo.Text = codigo.ToString();
                    txtTotal.Text = datos[1];
                    double subtotal = double.Parse(txtTotal.Text)*100/118;
                    double igv = subtotal * 18 / 100;
                    txtSubtotal.Text = subtotal.ToString("N2");
                    txtIgv.Text = igv.ToString("N2");
                    ldv = gV.CargarDetalleVenta(codigo);
                    MostrarDetalleVenta(ldv);
                }
                else
                {
                    txtIgv.Text = "";
                    txtSubtotal.Text = "";
                    txtTotal.Text = "";
                    txtDni.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    nudPago.Value = 0;
                    dataGridView2.DataSource = null;
                    MessageBox.Show("La venta aún no ha sido registrada o ya fue pagada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Muestra en el datagridview el detalle de la venta encontrada
        private void MostrarDetalleVenta(Array ldv)
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

        //Calcula el vuelto de acuerdo a la cantidad pagada ingresado en el formulario, el uso de esta función es opcional
        private void btnCalcularVuelto_Click(object sender, EventArgs e)
        {
            if (this.nudPago.Value > 0)
            {
                if (txtTotal.Text != "")
                {
                    decimal vuelto = this.nudPago.Value - decimal.Parse(txtTotal.Text);
                    if (vuelto >= 0)
                    {
                        this.textBox8.Text = vuelto.ToString();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad pagada no puede ser menor al total", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe buscar una venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un monto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Busca un cliente segun el dni ingresado
        private void btnBuscarCliente_Click(object sender, EventArgs e)
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
                    lblDNI.Text = dniRucCliente;
                    textBox6.Text = nombre;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Inicia el formulario de registrar cliente
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            string dniCliente = txtDni.Text;

            IURegistrarCliente frm = new IURegistrarCliente(dniCliente);

            frm.ShowDialog();

            this.btnBuscarCliente.PerformClick();
        }

        //Registra el estado de la venta como pagado, actualiza el monto total del cliente y agrega el cliente a la venta
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (lblCodigo.Text != "")
            {
                if (lblDNI.Text != "")
                {
                    GestorCliente gC = new GestorCliente();
                    GestorVenta gV = new GestorVenta();
                    try
                    {
                        int codigo = Int32.Parse(this.lblCodigo.Text);
                        string dniRucCliente = this.lblDNI.Text;
                        gC.ActualizarMonto(dniRucCliente, txtTotal.Text); 
                        gV.AgregarCliente(codigo, dniRucCliente);
                        gV.EstadoVenta(codigo, 2);
                        Notificar("Pago registrado exitosamente");
                        generarComprobante();

                        txtIgv.Text = "";
                        txtSubtotal.Text = "";
                        txtTotal.Text = "";
                        txtDni.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox8.Text = "";
                        nudPago.Value = 0;
                        dataGridView2.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe buscar un cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe buscar una venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Genera el comprobante por la venta usando los datos visibles en el formulario
        private void generarComprobante()
        {
            string fecha = System.DateTime.Now.ToString("dd/MM/yyyy");

            //tabla
            int[] x = { 48, 180, 400, 500 };
            int firstY = 248;
            int y = 0;

            //subtotal,igv y total
            int xMontos = 510;
            int yMontos = 500;
            int aumento = 22;

            //fecha y codigo de venta
            int xFecha = 520;
            int yFecha = 80;

            //datos del cliente
            int xCliente = 115;
            int yCliente = 188;

            Image boletaActual = boletaModelo;
            Graphics g = Graphics.FromImage(boletaActual);
            StringFormat formatter = new StringFormat();
            formatter.LineAlignment = StringAlignment.Center;
            formatter.Alignment = StringAlignment.Center;
            Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                        g.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), font, brush, new Point(x[j], firstY), formatter);
                    else
                        g.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), font, brush, new Point(x[j], firstY + y), formatter);
                }

                y += 15;
            }

            g.DrawString(textBox6.Text, font, brush, new Point(xCliente, yCliente), formatter);
            g.DrawString(fecha, font, brush, new Point(xFecha, yFecha), formatter);
            g.DrawString(txtSubtotal.Text, font, brush, new Point(xMontos, yMontos), formatter);
            yMontos += aumento;
            yFecha += aumento;
            yCliente += aumento;
            g.DrawString(lblDNI.Text, font, brush, new Point(xCliente, yCliente), formatter);
            g.DrawString(this.lblCodigo.Text, font, brush, new Point(xFecha, yFecha), formatter);
            g.DrawString(txtIgv.Text, font, brush, new Point(xMontos, yMontos), formatter);
            yMontos += aumento;
            g.DrawString(txtTotal.Text, font, brush, new Point(xMontos, yMontos), formatter);

            imprimirComprobante(boletaActual);
        }

        //Imprime el comprobante previamente generado
        private Boolean imprimirComprobante(Image boletaActual)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) => e.Graphics.DrawImage(boletaActual, 0, 0);
                pd.Print();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir la factura", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
