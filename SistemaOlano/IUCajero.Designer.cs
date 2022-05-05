namespace SistemaOlano
{
    partial class IUCajero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUCajero));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.mnuRegistrar = new System.Windows.Forms.RibbonTab();
            this.mnuPagoVenta = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarPago = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarPedido = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnRespuesta = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.btnSolicitud = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.btnDevolucion = new System.Windows.Forms.RibbonButton();
            this.mnuReportes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.btnListarVentas = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.btnListarPedido = new System.Windows.Forms.RibbonButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(692, 98);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.mnuRegistrar);
            this.ribbon1.Tabs.Add(this.mnuReportes);
            this.ribbon1.Text = "ribbon1";
            // 
            // mnuRegistrar
            // 
            this.mnuRegistrar.Name = "mnuRegistrar";
            this.mnuRegistrar.Panels.Add(this.mnuPagoVenta);
            this.mnuRegistrar.Panels.Add(this.ribbonPanel1);
            this.mnuRegistrar.Panels.Add(this.ribbonPanel2);
            this.mnuRegistrar.Panels.Add(this.ribbonPanel3);
            this.mnuRegistrar.Panels.Add(this.ribbonPanel4);
            this.mnuRegistrar.Text = "Registrar";
            // 
            // mnuPagoVenta
            // 
            this.mnuPagoVenta.ButtonMoreVisible = false;
            this.mnuPagoVenta.Items.Add(this.btnRegistrarPago);
            this.mnuPagoVenta.Name = "mnuPagoVenta";
            this.mnuPagoVenta.Text = "Registrar pago";
            this.mnuPagoVenta.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Image = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnRegistrarPago.LargeImage = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarPago.SmallImage")));
            this.btnRegistrarPago.Text = "";
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.btnRegistrarPedido);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Registrar pedido";
            this.ribbonPanel1.Click += new System.EventHandler(this.btnRegistrarPedido_Click);
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.Image = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnRegistrarPedido.LargeImage = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarPedido.SmallImage")));
            this.btnRegistrarPedido.Text = "";
            this.btnRegistrarPedido.Click += new System.EventHandler(this.btnRegistrarPedido_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.btnRespuesta);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Respuesta de pedido";
            this.ribbonPanel2.Click += new System.EventHandler(this.btnRespuesta_Click);
            // 
            // btnRespuesta
            // 
            this.btnRespuesta.Image = global::SistemaOlano.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Check_3;
            this.btnRespuesta.LargeImage = global::SistemaOlano.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Check_3;
            this.btnRespuesta.Name = "btnRespuesta";
            this.btnRespuesta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRespuesta.SmallImage")));
            this.btnRespuesta.Text = "";
            this.btnRespuesta.Click += new System.EventHandler(this.btnRespuesta_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.btnSolicitud);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Solicitud abastecimiento";
            this.ribbonPanel3.Click += new System.EventHandler(this.btnSolicitud_Click);
            // 
            // btnSolicitud
            // 
            this.btnSolicitud.Image = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnSolicitud.LargeImage = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnSolicitud.Name = "btnSolicitud";
            this.btnSolicitud.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitud.SmallImage")));
            this.btnSolicitud.Text = "";
            this.btnSolicitud.Click += new System.EventHandler(this.btnSolicitud_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.btnDevolucion);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Devolución de dinero";
            this.ribbonPanel4.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Image = global::SistemaOlano.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Money;
            this.btnDevolucion.LargeImage = global::SistemaOlano.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Money;
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDevolucion.SmallImage")));
            this.btnDevolucion.Text = "";
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Panels.Add(this.ribbonPanel5);
            this.mnuReportes.Panels.Add(this.ribbonPanel6);
            this.mnuReportes.Text = "Reportes";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.btnListarVentas);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "Listar ventas";
            this.ribbonPanel5.Click += new System.EventHandler(this.btnListarVentas_Click);
            // 
            // btnListarVentas
            // 
            this.btnListarVentas.Image = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnListarVentas.LargeImage = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnListarVentas.Name = "btnListarVentas";
            this.btnListarVentas.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnListarVentas.SmallImage")));
            this.btnListarVentas.Text = "";
            this.btnListarVentas.Click += new System.EventHandler(this.btnListarVentas_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.btnListarPedido);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Listar pedidos";
            this.ribbonPanel6.Click += new System.EventHandler(this.btnListarPedido_Click);
            // 
            // btnListarPedido
            // 
            this.btnListarPedido.Image = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnListarPedido.LargeImage = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnListarPedido.Name = "btnListarPedido";
            this.btnListarPedido.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnListarPedido.SmallImage")));
            this.btnListarPedido.Text = "";
            this.btnListarPedido.Click += new System.EventHandler(this.btnListarPedido_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // frmCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 453);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCajero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas Olano - Cajero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCajero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab mnuRegistrar;
        private System.Windows.Forms.RibbonTab mnuReportes;
        private System.Windows.Forms.RibbonPanel mnuPagoVenta;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton btnRegistrarPago;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton btnRegistrarPedido;
        private System.Windows.Forms.RibbonButton btnRespuesta;
        private System.Windows.Forms.RibbonButton btnSolicitud;
        private System.Windows.Forms.RibbonButton btnDevolucion;
        private System.Windows.Forms.RibbonButton btnListarVentas;
        private System.Windows.Forms.RibbonButton btnListarPedido;
        private System.Windows.Forms.MenuStrip menuStrip1;

    }
}