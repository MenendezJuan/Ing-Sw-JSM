namespace CheeseLogix
{
	partial class frmAjustesStock
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelIdioma = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelCampos = new System.Windows.Forms.TableLayoutPanel();
            this.lblProducto = new System.Windows.Forms.Label();
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelAccionesTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tableLayoutPanelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.gridPendientes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelAccionesBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.tableLayoutPanelIdioma.SuspendLayout();
            this.tableLayoutPanelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.tableLayoutPanelAccionesTop.SuspendLayout();
            this.tableLayoutPanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendientes)).BeginInit();
            this.tableLayoutPanelAccionesBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(159, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "Titulo_AjustesStock";
            this.lblTitulo.Text = "Ajustes de Stock";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCampos, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelAccionesTop, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelGrid, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelAccionesBottom, 0, 4);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(900, 600);
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
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(894, 54);
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
            this.tableLayoutPanelIdioma.Location = new System.Drawing.Point(539, 3);
            this.tableLayoutPanelIdioma.Name = "tableLayoutPanelIdioma";
            this.tableLayoutPanelIdioma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanelIdioma.Size = new System.Drawing.Size(352, 48);
            this.tableLayoutPanelIdioma.TabIndex = 1;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(48, 14);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(142, 20);
            this.lblSeleccionarIdioma.TabIndex = 0;
            this.lblSeleccionarIdioma.Tag = "Label_Idioma_FormIni";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Location = new System.Drawing.Point(209, 13);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(140, 21);
            this.cboxIdiomas.TabIndex = 1;
            // 
            // tableLayoutPanelCampos
            // 
            this.tableLayoutPanelCampos.ColumnCount = 2;
            this.tableLayoutPanelCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelCampos.Controls.Add(this.lblProducto, 0, 0);
            this.tableLayoutPanelCampos.Controls.Add(this.comboProductos, 1, 0);
            this.tableLayoutPanelCampos.Controls.Add(this.lblTipo, 0, 1);
            this.tableLayoutPanelCampos.Controls.Add(this.comboTipo, 1, 1);
            this.tableLayoutPanelCampos.Controls.Add(this.lblCantidad, 0, 2);
            this.tableLayoutPanelCampos.Controls.Add(this.numericCantidad, 1, 2);
            this.tableLayoutPanelCampos.Controls.Add(this.lblMotivo, 0, 3);
            this.tableLayoutPanelCampos.Controls.Add(this.txtMotivo, 1, 3);
            this.tableLayoutPanelCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCampos.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelCampos.Name = "tableLayoutPanelCampos";
            this.tableLayoutPanelCampos.RowCount = 4;
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCampos.Size = new System.Drawing.Size(894, 114);
            this.tableLayoutPanelCampos.TabIndex = 1;
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProducto.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProducto.Location = new System.Drawing.Point(209, 3);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(100, 23);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Tag = "Producto_Label";
            this.lblProducto.Text = "Producto";
            // 
            // comboProductos
            // 
            this.comboProductos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductos.Location = new System.Drawing.Point(315, 4);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(260, 21);
            this.comboProductos.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTipo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTipo.Location = new System.Drawing.Point(209, 33);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Tag = "Tipo_Label";
            this.lblTipo.Text = "Tipo";
            // 
            // comboTipo
            // 
            this.comboTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.Location = new System.Drawing.Point(315, 34);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(260, 21);
            this.comboTipo.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCantidad.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCantidad.Location = new System.Drawing.Point(209, 63);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(100, 23);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Tag = "Cantidad_Label";
            this.lblCantidad.Text = "Cantidad";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericCantidad.DecimalPlaces = 2;
            this.numericCantidad.Location = new System.Drawing.Point(315, 65);
            this.numericCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(120, 20);
            this.numericCantidad.TabIndex = 5;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMotivo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMotivo.Location = new System.Drawing.Point(209, 90);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(100, 23);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Tag = "Motivo_Label";
            this.lblMotivo.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivo.Location = new System.Drawing.Point(315, 93);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(576, 18);
            this.txtMotivo.TabIndex = 7;
            // 
            // tableLayoutPanelAccionesTop
            // 
            this.tableLayoutPanelAccionesTop.ColumnCount = 1;
            this.tableLayoutPanelAccionesTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAccionesTop.Controls.Add(this.btnRegistrar, 0, 0);
            this.tableLayoutPanelAccionesTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAccionesTop.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanelAccionesTop.Name = "tableLayoutPanelAccionesTop";
            this.tableLayoutPanelAccionesTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelAccionesTop.Size = new System.Drawing.Size(894, 44);
            this.tableLayoutPanelAccionesTop.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrar.Location = new System.Drawing.Point(3, 3);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnRegistrar.Size = new System.Drawing.Size(109, 37);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Tag = "Registrar";
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tableLayoutPanelGrid
            // 
            this.tableLayoutPanelGrid.ColumnCount = 1;
            this.tableLayoutPanelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGrid.Controls.Add(this.gridPendientes, 0, 0);
            this.tableLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGrid.Location = new System.Drawing.Point(3, 233);
            this.tableLayoutPanelGrid.Name = "tableLayoutPanelGrid";
            this.tableLayoutPanelGrid.RowCount = 1;
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGrid.Size = new System.Drawing.Size(894, 314);
            this.tableLayoutPanelGrid.TabIndex = 3;
            // 
            // gridPendientes
            // 
            this.gridPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPendientes.Location = new System.Drawing.Point(3, 3);
            this.gridPendientes.Name = "gridPendientes";
            this.gridPendientes.Size = new System.Drawing.Size(888, 308);
            this.gridPendientes.TabIndex = 0;
            // 
            // tableLayoutPanelAccionesBottom
            // 
            this.tableLayoutPanelAccionesBottom.ColumnCount = 3;
            this.tableLayoutPanelAccionesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAccionesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAccionesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAccionesBottom.Controls.Add(this.btnAprobar, 0, 0);
            this.tableLayoutPanelAccionesBottom.Controls.Add(this.btnRechazar, 1, 0);
            this.tableLayoutPanelAccionesBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAccionesBottom.Location = new System.Drawing.Point(3, 553);
            this.tableLayoutPanelAccionesBottom.Name = "tableLayoutPanelAccionesBottom";
            this.tableLayoutPanelAccionesBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAccionesBottom.Size = new System.Drawing.Size(894, 44);
            this.tableLayoutPanelAccionesBottom.TabIndex = 4;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAprobar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAprobar.Location = new System.Drawing.Point(3, 3);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(109, 38);
            this.btnAprobar.TabIndex = 0;
            this.btnAprobar.Tag = "Aprobar";
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRechazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRechazar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRechazar.Location = new System.Drawing.Point(301, 3);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(100, 37);
            this.btnRechazar.TabIndex = 1;
            this.btnRechazar.Tag = "Rechazar";
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // frmAjustesStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "frmAjustesStock";
            this.Text = "Ajustes de Stock";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.tableLayoutPanelIdioma.ResumeLayout(false);
            this.tableLayoutPanelIdioma.PerformLayout();
            this.tableLayoutPanelCampos.ResumeLayout(false);
            this.tableLayoutPanelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.tableLayoutPanelAccionesTop.ResumeLayout(false);
            this.tableLayoutPanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPendientes)).EndInit();
            this.tableLayoutPanelAccionesBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIdioma;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCampos;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAccionesTop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGrid;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAccionesBottom;
		private System.Windows.Forms.ComboBox comboProductos;
		private System.Windows.Forms.ComboBox comboTipo;
		private System.Windows.Forms.NumericUpDown numericCantidad;
		private System.Windows.Forms.TextBox txtMotivo;
		private System.Windows.Forms.Button btnRegistrar;
		private System.Windows.Forms.DataGridView gridPendientes;
		private System.Windows.Forms.Button btnAprobar;
		private System.Windows.Forms.Button btnRechazar;
		private System.Windows.Forms.ComboBox cboxIdiomas;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Label lblSeleccionarIdioma;
		private System.Windows.Forms.Label lblProducto;
		private System.Windows.Forms.Label lblTipo;
		private System.Windows.Forms.Label lblCantidad;
		private System.Windows.Forms.Label lblMotivo;
	}
}

