namespace CheeseLogix.Negocio.Ventas
{
	partial class frmRegistrarDevolucion
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.comboVentas = new System.Windows.Forms.ComboBox();
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.chkApto = new System.Windows.Forms.CheckBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelIdioma = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.tableLayoutPanelCampos = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelAcciones = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.tableLayoutPanelIdioma.SuspendLayout();
            this.tableLayoutPanelCampos.SuspendLayout();
            this.tableLayoutPanelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboVentas
            // 
            this.comboVentas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVentas.Location = new System.Drawing.Point(210, 7);
            this.comboVentas.Name = "comboVentas";
            this.comboVentas.Size = new System.Drawing.Size(240, 21);
            this.comboVentas.TabIndex = 1;
            // 
            // comboProductos
            // 
            this.comboProductos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductos.Location = new System.Drawing.Point(210, 42);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(240, 21);
            this.comboProductos.TabIndex = 3;
            // 
            // numericCantidad
            // 
            this.numericCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericCantidad.DecimalPlaces = 2;
            this.numericCantidad.Location = new System.Drawing.Point(210, 77);
            this.numericCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(120, 20);
            this.numericCantidad.TabIndex = 5;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivo.Location = new System.Drawing.Point(210, 115);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(381, 60);
            this.txtMotivo.TabIndex = 7;
            // 
            // chkApto
            // 
            this.chkApto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkApto.Location = new System.Drawing.Point(210, 202);
            this.chkApto.Name = "chkApto";
            this.chkApto.Size = new System.Drawing.Size(104, 24);
            this.chkApto.TabIndex = 8;
            this.chkApto.Tag = "AptoParaVenta";
            this.chkApto.Text = "Apto para venta";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrar.Location = new System.Drawing.Point(3, 4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnRegistrar.Size = new System.Drawing.Size(133, 35);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Tag = "Registrar";
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Location = new System.Drawing.Point(130, 13);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(99, 21);
            this.cboxIdiomas.TabIndex = 1;
            // 
            // lblVenta
            // 
            this.lblVenta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVenta.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblVenta.Location = new System.Drawing.Point(104, 6);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(100, 23);
            this.lblVenta.TabIndex = 0;
            this.lblVenta.Tag = "Venta_Label";
            this.lblVenta.Text = "Venta";
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProducto.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProducto.Location = new System.Drawing.Point(104, 41);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(100, 23);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Tag = "Producto_Label";
            this.lblProducto.Text = "Producto";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCantidad.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCantidad.Location = new System.Drawing.Point(104, 76);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(100, 23);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Tag = "Cantidad_Label";
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMotivo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMotivo.Location = new System.Drawing.Point(104, 133);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(100, 23);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Tag = "Motivo_Label";
            this.lblMotivo.Text = "Motivo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(191, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "Titulo_RegistrarDevolucion";
            this.lblTitulo.Text = "Registrar Devolución";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCampos, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelAcciones, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(600, 360);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.ColumnCount = 2;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelHeader.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.tableLayoutPanelIdioma, 1, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(594, 54);
            this.tableLayoutPanelHeader.TabIndex = 0;
            // 
            // tableLayoutPanelIdioma
            // 
            this.tableLayoutPanelIdioma.ColumnCount = 2;
            this.tableLayoutPanelIdioma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelIdioma.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelIdioma.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutPanelIdioma.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanelIdioma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelIdioma.Location = new System.Drawing.Point(359, 3);
            this.tableLayoutPanelIdioma.Name = "tableLayoutPanelIdioma";
            this.tableLayoutPanelIdioma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelIdioma.Size = new System.Drawing.Size(232, 48);
            this.tableLayoutPanelIdioma.TabIndex = 1;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(33, 4);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(91, 40);
            this.lblSeleccionarIdioma.TabIndex = 0;
            this.lblSeleccionarIdioma.Tag = "Label_Idioma_FormIni";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // tableLayoutPanelCampos
            // 
            this.tableLayoutPanelCampos.ColumnCount = 2;
            this.tableLayoutPanelCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelCampos.Controls.Add(this.lblVenta, 0, 0);
            this.tableLayoutPanelCampos.Controls.Add(this.comboVentas, 1, 0);
            this.tableLayoutPanelCampos.Controls.Add(this.lblProducto, 0, 1);
            this.tableLayoutPanelCampos.Controls.Add(this.comboProductos, 1, 1);
            this.tableLayoutPanelCampos.Controls.Add(this.lblCantidad, 0, 2);
            this.tableLayoutPanelCampos.Controls.Add(this.numericCantidad, 1, 2);
            this.tableLayoutPanelCampos.Controls.Add(this.lblMotivo, 0, 3);
            this.tableLayoutPanelCampos.Controls.Add(this.txtMotivo, 1, 3);
            this.tableLayoutPanelCampos.Controls.Add(this.chkApto, 1, 4);
            this.tableLayoutPanelCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCampos.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelCampos.Name = "tableLayoutPanelCampos";
            this.tableLayoutPanelCampos.RowCount = 5;
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCampos.Size = new System.Drawing.Size(594, 244);
            this.tableLayoutPanelCampos.TabIndex = 1;
            // 
            // tableLayoutPanelAcciones
            // 
            this.tableLayoutPanelAcciones.ColumnCount = 2;
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAcciones.Controls.Add(this.btnRegistrar, 0, 0);
            this.tableLayoutPanelAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAcciones.Location = new System.Drawing.Point(3, 313);
            this.tableLayoutPanelAcciones.Name = "tableLayoutPanelAcciones";
            this.tableLayoutPanelAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAcciones.Size = new System.Drawing.Size(594, 44);
            this.tableLayoutPanelAcciones.TabIndex = 2;
            // 
            // btnAbrirNotaCredito
            // 
            this.btnAbrirNotaCredito = new System.Windows.Forms.Button();
            this.tableLayoutPanelAcciones.Controls.Add(this.btnAbrirNotaCredito, 1, 0);
            this.btnAbrirNotaCredito.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAbrirNotaCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnAbrirNotaCredito.Enabled = false;
            this.btnAbrirNotaCredito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAbrirNotaCredito.FlatAppearance.BorderSize = 2;
            this.btnAbrirNotaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirNotaCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAbrirNotaCredito.Location = new System.Drawing.Point(300, 4);
            this.btnAbrirNotaCredito.Name = "btnAbrirNotaCredito";
            this.btnAbrirNotaCredito.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnAbrirNotaCredito.Size = new System.Drawing.Size(180, 35);
            this.btnAbrirNotaCredito.TabIndex = 1;
            this.btnAbrirNotaCredito.Tag = "AbrirNotaCredito";
            this.btnAbrirNotaCredito.Text = "Abrir Nota de Crédito";
            this.btnAbrirNotaCredito.UseVisualStyleBackColor = false;
            this.btnAbrirNotaCredito.Click += new System.EventHandler(this.btnAbrirNotaCredito_Click);
            // 
            // frmRegistrarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "frmRegistrarDevolucion";
            this.Text = "Registrar Devolución";
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.tableLayoutPanelIdioma.ResumeLayout(false);
            this.tableLayoutPanelIdioma.PerformLayout();
            this.tableLayoutPanelCampos.ResumeLayout(false);
            this.tableLayoutPanelCampos.PerformLayout();
            this.tableLayoutPanelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private System.Windows.Forms.ComboBox comboVentas;
		private System.Windows.Forms.ComboBox comboProductos;
		private System.Windows.Forms.NumericUpDown numericCantidad;
		private System.Windows.Forms.TextBox txtMotivo;
		private System.Windows.Forms.CheckBox chkApto;
		private System.Windows.Forms.Button btnRegistrar;
		private System.Windows.Forms.ComboBox cboxIdiomas;
		private System.Windows.Forms.Label lblVenta;
		private System.Windows.Forms.Label lblProducto;
		private System.Windows.Forms.Label lblCantidad;
		private System.Windows.Forms.Label lblMotivo;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIdioma;
		private System.Windows.Forms.Label lblSeleccionarIdioma;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCampos;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAcciones;
		private System.Windows.Forms.Button btnAbrirNotaCredito;
	}
}