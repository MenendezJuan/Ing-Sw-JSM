namespace CheeseLogix.Negocio.Ventas
{
	partial class frmHistorialVentas
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
            this.tableLayoutGrids = new System.Windows.Forms.TableLayoutPanel();
            this.gridVentas = new System.Windows.Forms.DataGridView();
            this.gridDetalles = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelAcciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.tableLayoutPanelIdioma.SuspendLayout();
            this.tableLayoutGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalles)).BeginInit();
            this.tableLayoutPanelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "Titulo_HistorialVentas";
            this.lblTitulo.Text = "Historial de Ventas";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutGrids, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelAcciones, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1000, 600);
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
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(994, 54);
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
            this.tableLayoutPanelIdioma.Location = new System.Drawing.Point(599, 3);
            this.tableLayoutPanelIdioma.Name = "tableLayoutPanelIdioma";
            this.tableLayoutPanelIdioma.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelIdioma.Size = new System.Drawing.Size(392, 48);
            this.tableLayoutPanelIdioma.TabIndex = 1;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(70, 14);
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
            this.cboxIdiomas.Location = new System.Drawing.Point(249, 13);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(140, 21);
            this.cboxIdiomas.TabIndex = 1;
            // 
            // tableLayoutGrids
            // 
            this.tableLayoutGrids.ColumnCount = 2;
            this.tableLayoutGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutGrids.Controls.Add(this.gridVentas, 0, 0);
            this.tableLayoutGrids.Controls.Add(this.gridDetalles, 1, 0);
            this.tableLayoutGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutGrids.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutGrids.Name = "tableLayoutGrids";
            this.tableLayoutGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGrids.Size = new System.Drawing.Size(994, 484);
            this.tableLayoutGrids.TabIndex = 1;
            // 
            // gridVentas
            // 
            this.gridVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVentas.Location = new System.Drawing.Point(3, 3);
            this.gridVentas.MultiSelect = false;
            this.gridVentas.Name = "gridVentas";
            this.gridVentas.ReadOnly = true;
            this.gridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVentas.Size = new System.Drawing.Size(491, 478);
            this.gridVentas.TabIndex = 0;
            this.gridVentas.SelectionChanged += new System.EventHandler(this.gridVentas_SelectionChanged);
            // 
            // gridDetalles
            // 
            this.gridDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetalles.Location = new System.Drawing.Point(500, 3);
            this.gridDetalles.MultiSelect = false;
            this.gridDetalles.Name = "gridDetalles";
            this.gridDetalles.ReadOnly = true;
            this.gridDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetalles.Size = new System.Drawing.Size(491, 478);
            this.gridDetalles.TabIndex = 1;
            this.gridDetalles.SelectionChanged += new System.EventHandler(this.gridDetalles_SelectionChanged);
            // 
            // tableLayoutPanelAcciones
            // 
            this.tableLayoutPanelAcciones.ColumnCount = 2;
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAcciones.Controls.Add(this.btnRegistrarDevolucion, 0, 0);
            this.tableLayoutPanelAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAcciones.Location = new System.Drawing.Point(3, 553);
            this.tableLayoutPanelAcciones.Name = "tableLayoutPanelAcciones";
            this.tableLayoutPanelAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAcciones.Size = new System.Drawing.Size(994, 44);
            this.tableLayoutPanelAcciones.TabIndex = 2;
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRegistrarDevolucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRegistrarDevolucion.Enabled = false;
            this.btnRegistrarDevolucion.FlatAppearance.BorderSize = 0;
            this.btnRegistrarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDevolucion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(3, 7);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(101, 30);
            this.btnRegistrarDevolucion.TabIndex = 0;
            this.btnRegistrarDevolucion.Tag = "RegistrarDevolucion";
            this.btnRegistrarDevolucion.Text = "Registrar Devolución";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // frmHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "frmHistorialVentas";
            this.Text = "Historial de Ventas";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.tableLayoutPanelIdioma.ResumeLayout(false);
            this.tableLayoutPanelIdioma.PerformLayout();
            this.tableLayoutGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalles)).EndInit();
            this.tableLayoutPanelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIdioma;
		private System.Windows.Forms.Label lblSeleccionarIdioma;
		private System.Windows.Forms.ComboBox cboxIdiomas;
		private System.Windows.Forms.TableLayoutPanel tableLayoutGrids;
		private System.Windows.Forms.DataGridView gridVentas;
		private System.Windows.Forms.DataGridView gridDetalles;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAcciones;
		private System.Windows.Forms.Button btnRegistrarDevolucion;
	}
}

