namespace SistemaOlano
{
    partial class IUAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUAdministrador));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnGestionarProducto = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnGestionarTrabajador = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.btnGestionarCliente = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.btnResumenVentas = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.btnPedidosRechazados = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.btnFerreteroMayor = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.btnVendedorMas = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
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
            this.ribbon1.Size = new System.Drawing.Size(692, 101);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "Registrar";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.btnGestionarProducto);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Gestionar producto";
            this.ribbonPanel1.Click += new System.EventHandler(this.btnGestionarProducto_Click);
            // 
            // btnGestionarProducto
            // 
            this.btnGestionarProducto.Image = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnGestionarProducto.LargeImage = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnGestionarProducto.Name = "btnGestionarProducto";
            this.btnGestionarProducto.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarProducto.SmallImage")));
            this.btnGestionarProducto.Text = "";
            this.btnGestionarProducto.Click += new System.EventHandler(this.btnGestionarProducto_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.btnGestionarTrabajador);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Gestionar trabajador";
            this.ribbonPanel2.Click += new System.EventHandler(this.btnGestionarTrabajador_Click);
            // 
            // btnGestionarTrabajador
            // 
            this.btnGestionarTrabajador.Image = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_User_Coffee_break;
            this.btnGestionarTrabajador.LargeImage = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_User_Coffee_break;
            this.btnGestionarTrabajador.Name = "btnGestionarTrabajador";
            this.btnGestionarTrabajador.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarTrabajador.SmallImage")));
            this.btnGestionarTrabajador.Text = "";
            this.btnGestionarTrabajador.Click += new System.EventHandler(this.btnGestionarTrabajador_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.btnGestionarCliente);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Gestionar cliente";
            this.ribbonPanel3.Click += new System.EventHandler(this.btnGestionarCliente_Click);
            // 
            // btnGestionarCliente
            // 
            this.btnGestionarCliente.Image = global::SistemaOlano.Properties.Resources.Hopstarter_Sleek_Xp_Basic_User_Group;
            this.btnGestionarCliente.LargeImage = global::SistemaOlano.Properties.Resources.Hopstarter_Sleek_Xp_Basic_User_Group;
            this.btnGestionarCliente.Name = "btnGestionarCliente";
            this.btnGestionarCliente.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGestionarCliente.SmallImage")));
            this.btnGestionarCliente.Text = "";
            this.btnGestionarCliente.Click += new System.EventHandler(this.btnGestionarCliente_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel4);
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            this.ribbonTab2.Panels.Add(this.ribbonPanel6);
            this.ribbonTab2.Panels.Add(this.ribbonPanel7);
            this.ribbonTab2.Text = "Reportes";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.btnResumenVentas);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Resumen de ventas";
            this.ribbonPanel4.Click += new System.EventHandler(this.btnResumenVentas_Click);
            // 
            // btnResumenVentas
            // 
            this.btnResumenVentas.Image = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnResumenVentas.LargeImage = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.btnResumenVentas.Name = "btnResumenVentas";
            this.btnResumenVentas.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnResumenVentas.SmallImage")));
            this.btnResumenVentas.Text = "";
            this.btnResumenVentas.Click += new System.EventHandler(this.btnResumenVentas_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.btnPedidosRechazados);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "Pedidos rechazados";
            this.ribbonPanel5.Click += new System.EventHandler(this.btnPedidosRechazados_Click);
            // 
            // btnPedidosRechazados
            // 
            this.btnPedidosRechazados.Image = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnPedidosRechazados.LargeImage = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnPedidosRechazados.Name = "btnPedidosRechazados";
            this.btnPedidosRechazados.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPedidosRechazados.SmallImage")));
            this.btnPedidosRechazados.Text = "";
            this.btnPedidosRechazados.Click += new System.EventHandler(this.btnPedidosRechazados_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.btnFerreteroMayor);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Ferreteros con mayor gasto";
            this.ribbonPanel6.Click += new System.EventHandler(this.btnFerreteroMayor_Click);
            // 
            // btnFerreteroMayor
            // 
            this.btnFerreteroMayor.Image = global::SistemaOlano.Properties.Resources.Google_Noto_Emoji_People_Profession_10526_woman_construction_worker_light_skin_tone;
            this.btnFerreteroMayor.LargeImage = global::SistemaOlano.Properties.Resources.Google_Noto_Emoji_People_Profession_10526_woman_construction_worker_light_skin_tone;
            this.btnFerreteroMayor.Name = "btnFerreteroMayor";
            this.btnFerreteroMayor.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnFerreteroMayor.SmallImage")));
            this.btnFerreteroMayor.Text = "";
            this.btnFerreteroMayor.Click += new System.EventHandler(this.btnFerreteroMayor_Click);
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.btnVendedorMas);
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Text = "Vendedores con más ventas";
            this.ribbonPanel7.Click += new System.EventHandler(this.btnVendedorMas_Click);
            // 
            // btnVendedorMas
            // 
            this.btnVendedorMas.Image = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_User_Coffee_break;
            this.btnVendedorMas.LargeImage = global::SistemaOlano.Properties.Resources.Aha_Soft_Large_User_Coffee_break;
            this.btnVendedorMas.Name = "btnVendedorMas";
            this.btnVendedorMas.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnVendedorMas.SmallImage")));
            this.btnVendedorMas.Text = "";
            this.btnVendedorMas.Click += new System.EventHandler(this.btnVendedorMas_Click);
            // 
            // frmAdministrador
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
            this.Name = "frmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas Olano - Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdministrador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnGestionarProducto;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnGestionarTrabajador;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton btnGestionarCliente;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton btnResumenVentas;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton btnPedidosRechazados;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton btnFerreteroMayor;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton btnVendedorMas;
    }
}