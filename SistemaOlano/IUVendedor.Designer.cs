namespace SistemaOlano
{
    partial class IUVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUVendedor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarVenta = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.rpCerrarSesion = new System.Windows.Forms.RibbonPanel();
            this.btnCerrarSesion = new System.Windows.Forms.RibbonButton();
            this.rpAyuda = new System.Windows.Forms.RibbonPanel();
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
            this.ribbon1.Location = new System.Drawing.Point(0, 24);
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
            this.ribbonTab1.Text = "Registrar";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.btnRegistrarVenta);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Registrar venta";
            this.ribbonPanel1.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Image = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnRegistrarVenta.LargeImage = global::SistemaOlano.Properties.Resources.Umut_Pulat_Tulliana_2_Korganizer;
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarVenta.SmallImage")));
            this.btnRegistrarVenta.Text = "";
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.rpCerrarSesion);
            this.ribbonTab2.Panels.Add(this.rpAyuda);
            this.ribbonTab2.Text = "Cuenta";
            // 
            // rpCerrarSesion
            // 
            this.rpCerrarSesion.Items.Add(this.btnCerrarSesion);
            this.rpCerrarSesion.Name = "rpCerrarSesion";
            this.rpCerrarSesion.Text = "Cerrar Sesión";
            this.rpCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Image = global::SistemaOlano.Properties.Resources.Close_2_icon__1_;
            this.btnCerrarSesion.LargeImage = global::SistemaOlano.Properties.Resources.Close_2_icon__1_;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.SmallImage")));
            this.btnCerrarSesion.Text = "";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // rpAyuda
            // 
            this.rpAyuda.Name = "rpAyuda";
            this.rpAyuda.Text = "Ayuda";
            // 
            // IUVendedor
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
            this.Name = "IUVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Sistema de Ventas Olano - Vendedor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVendedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnRegistrarVenta;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel rpCerrarSesion;
        private System.Windows.Forms.RibbonPanel rpAyuda;
        private System.Windows.Forms.RibbonButton btnCerrarSesion;
    }
}