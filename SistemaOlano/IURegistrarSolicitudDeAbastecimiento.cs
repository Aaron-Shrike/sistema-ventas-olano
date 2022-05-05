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
    public partial class IURegistrarSolicitudDeAbastecimiento : Form
    {
        #region "Singleton"

        private static IURegistrarSolicitudDeAbastecimiento frm;

        public static IURegistrarSolicitudDeAbastecimiento Crear(Form frmPadre,string dni)
        {
            if (IURegistrarSolicitudDeAbastecimiento.frm == null)
            {
                IURegistrarSolicitudDeAbastecimiento.frm = new IURegistrarSolicitudDeAbastecimiento(dni)
                {
                    MdiParent = frmPadre,
                    WindowState = FormWindowState.Maximized
                };
            }
            IURegistrarSolicitudDeAbastecimiento.frm.BringToFront();

            return IURegistrarSolicitudDeAbastecimiento.frm;
        }

        private void frmRegistrarSolicitud_FormClosed(object sender, FormClosedEventArgs e)
        {
            IURegistrarSolicitudDeAbastecimiento.frm = null;
        }

        #endregion

        private Image solicitudModelo;

        /**
         * Constructor del formulario, inicializa el formato de la solicitud
         * y recibe el dni del trabajador que genera la solicitud
         * 
        @param string dni
        @roseuid 5B8F65D2039A
        */
        public IURegistrarSolicitudDeAbastecimiento(string dni = "")
        {
            InitializeComponent();
            this.dniTrabajador = dni;
            solicitudModelo = SistemaOlano.Properties.Resources.solicitudModelo;
        }

        private Array listProductos = null;
        private string dniTrabajador;

        /**
         * lista los productos con stock menor al stock minimo
         * 
        @roseuid 59C5EBA10256
        */
        private void btnListar_Click(object sender, EventArgs e)
        {
            GestorProducto gP;
            Array lista;

            try
            {
                gP = new GestorProducto();

                lista = gP.ListarProductosStockMinimo();
                this.MostrarProductosStockMinimo(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**
         * llena los productos con stock minimo en el datagridview
         * 
        @param Array lista
        @roseuid 59C5EBA10256
        */
        private void MostrarProductosStockMinimo(Array lista)
        {
            dgvListado.DataSource = null;
            if (lista != null && lista.Length > 0)
            {
                this.dgvListado.AutoGenerateColumns = false;
                this.dgvListado.DataSource = lista;
                this.listProductos = lista;
            }
            else
            {
                this.Notificar("No se encontraron productos");
            }
        }

        /**
         * registra una solicitud con los productos de stock minimo
         * 
        @roseuid 59C5EBA10256
        */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestorSolicitud gS;
            DateTime fecha;
            
            if (this.ValidateChildren() == true)
            {
                gS = new GestorSolicitud();
                fecha = DateTime.Now;
                
                try
                {
                    //if (this.GenerarPDF())
                    //{
                        gS.RegistrarSolicitud(fecha, dniTrabajador, this.listProductos);
                        this.Notificar("Solicitud registrada correctamente");
                        GenerarSolicitud();
                        
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * genera una solicitud sobre una plantilla cargada en el programa
         * 
        @roseuid 59C5EBA10256
        */
        private void GenerarSolicitud()
        {
            string fecha = System.DateTime.Now.ToString("dd/MM/yyyy");

            //tabla
            int[] x = { 48, 180 };
            int firstY = 250;
            int y = 0;

            //fecha y codigo de venta
            int xFecha = 520;
            int yFecha = 90;

            Image solicitudActual = solicitudModelo;
            Graphics g = Graphics.FromImage(solicitudActual);
            StringFormat formatter = new StringFormat();
            formatter.LineAlignment = StringAlignment.Center;
            formatter.Alignment = StringAlignment.Center;
            Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 0; i < dgvListado.Rows.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i == 0)
                        g.DrawString(dgvListado.Rows[i].Cells[j].Value.ToString(), font, brush, new Point(x[j], firstY), formatter);
                    else
                        g.DrawString(dgvListado.Rows[i].Cells[j].Value.ToString(), font, brush, new Point(x[j], firstY + y), formatter);
                }
                y += 15;
            }

            g.DrawString(fecha, font, brush, new Point(xFecha, yFecha), formatter);

            imprimirSolicitud(solicitudActual);
        }

        /**
         * genera el pdf de la solicitud generada
         * 
        @return boolean
        @roseuid 59C5EBA10257
        */
        private Boolean imprimirSolicitud(Image solicitudActual)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) => e.Graphics.DrawImage(solicitudActual, 0, 0);
                pd.Print();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir la factura", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        

        /**
         * notifica al actor algun mensaje de informacion
         * 
        @param string msj
        @roseuid 59C5EBA10256
        */
        private void Notificar(string msj)
        {
            MessageBox.Show(msj, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
         * cierra el formulario
         * 
        @roseuid 59C5EBA10256
        */
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
