namespace SistemaOlano
{
    partial class IUEncargadoAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUEncargadoAlmacen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarEntrega = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarProducto = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.btnModificarStock = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.btnProductoDefectuoso = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.btnRegistrarDevolucion = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnListarProductos = new System.Windows.Forms.RibbonButton();
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
            this.ribbon1.Size = new System.Drawing.Size(879, 102);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Panels.Add(this.ribbonPanel5);
            this.ribbonTab1.Panels.Add(this.ribbonPanel6);
            this.ribbonTab1.Text = "Registrar";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.btnRegistrarEntrega);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Registrar entrega";
            this.ribbonPanel2.Click += new System.EventHandler(this.btnRegistrarEntrega_Click);
            // 
            // btnRegistrarEntrega
            // 
            this.btnRegistrarEntrega.Image = global::SistemaOlano.Properties.Resources.Double_J_Design_Super_Mono_3d_Shopping_bag;
            this.btnRegistrarEntrega.LargeImage = global::SistemaOlano.Properties.Resources.Double_J_Design_Super_Mono_3d_Shopping_bag;
            this.btnRegistrarEntrega.Name = "btnRegistrarEntrega";
            this.btnRegistrarEntrega.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarEntrega.SmallImage")));
            this.btnRegistrarEntrega.Text = "";
            this.btnRegistrarEntrega.Click += new System.EventHandler(this.btnRegistrarEntrega_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.btnRegistrarProducto);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Registrar producto";
            this.ribbonPanel3.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.Image = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnRegistrarProducto.LargeImage = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarProducto.SmallImage")));
            this.btnRegistrarProducto.Text = "";
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.btnModificarStock);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Modificar stock de producto";
            this.ribbonPanel4.Click += new System.EventHandler(this.btnModificarStock_Click);
            // 
            // btnModificarStock
            // 
            this.btnModificarStock.Image = global::SistemaOlano.Properties.Resources.Custom_Icon_Design_Pretty_Office_10_Numbers;
            this.btnModificarStock.LargeImage = global::SistemaOlano.Properties.Resources.Custom_Icon_Design_Pretty_Office_10_Numbers;
            this.btnModificarStock.Name = "btnModificarStock";
            this.btnModificarStock.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnModificarStock.SmallImage")));
            this.btnModificarStock.Text = "";
            this.btnModificarStock.Click += new System.EventHandler(this.btnModificarStock_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.btnProductoDefectuoso);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "Registrar producto defectuoso";
            this.ribbonPanel5.Click += new System.EventHandler(this.btnProductoDefectuoso_Click);
            // 
            // btnProductoDefectuoso
            // 
            this.btnProductoDefectuoso.Image = global::SistemaOlano.Properties.Resources.Musett_Lcd_Boxes_Broken_Clean;
            this.btnProductoDefectuoso.LargeImage = global::SistemaOlano.Properties.Resources.Musett_Lcd_Boxes_Broken_Clean;
            this.btnProductoDefectuoso.Name = "btnProductoDefectuoso";
            this.btnProductoDefectuoso.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnProductoDefectuoso.SmallImage")));
            this.btnProductoDefectuoso.Text = "";
            this.btnProductoDefectuoso.Click += new System.EventHandler(this.btnProductoDefectuoso_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.btnRegistrarDevolucion);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Registrar devolución";
            this.ribbonPanel6.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Image = global::SistemaOlano.Properties.Resources.Custom_Icon_Design_Flatastic_2_Truck;
            this.btnRegistrarDevolucion.LargeImage = global::SistemaOlano.Properties.Resources.Custom_Icon_Design_Flatastic_2_Truck;
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarDevolucion.SmallImage")));
            this.btnRegistrarDevolucion.Text = "";
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel1);
            this.ribbonTab2.Text = "Reportes";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.btnListarProductos);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Listar productos";
            this.ribbonPanel1.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // btnListarProductos
            // 
            this.btnListarProductos.Image = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnListarProductos.LargeImage = global::SistemaOlano.Properties.Resources.Double_J_Design_Ravenna_3d_Box;
            this.btnListarProductos.Name = "btnListarProductos";
            this.btnListarProductos.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnListarProductos.SmallImage")));
            this.btnListarProductos.Text = "";
            this.btnListarProductos.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // frmEncargadoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 488);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEncargadoAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas Olano - Encargado de almacen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEncargadoAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnRegistrarEntrega;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnListarProductos;
        private System.Windows.Forms.RibbonButton btnRegistrarProducto;
        private System.Windows.Forms.RibbonButton btnModificarStock;
        private System.Windows.Forms.RibbonButton btnProductoDefectuoso;
        private System.Windows.Forms.RibbonButton btnRegistrarDevolucion;
    }
}