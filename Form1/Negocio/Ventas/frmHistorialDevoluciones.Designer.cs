namespace CheeseLogix.Negocio.Ventas
{
    partial class frmHistorialDevoluciones
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
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.cmbVenta = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanelBotonesFiltro = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dataGridViewHistorial = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.tableLayoutPanelAcciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.tableLayoutPanelFiltros.SuspendLayout();
            this.tableLayoutPanelBotonesFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).BeginInit();
            this.tableLayoutPanelFooter.SuspendLayout();
            this.tableLayoutPanelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 1;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelTitulo, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFiltros, 0, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.dataGridViewHistorial, 0, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFooter, 0, 3);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 4;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(1200, 700);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1200, 60);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1200, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "FormHistorialDevoluciones";
            this.lblTitulo.Text = "Historial de Devoluciones";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelFiltros
            // 
            this.tableLayoutPanelFiltros.ColumnCount = 4;
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiltros.Controls.Add(this.lblCliente, 0, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbCliente, 0, 1);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblVenta, 1, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbVenta, 1, 1);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblEstado, 2, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbEstado, 2, 1);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblFechaDesde, 0, 2);
            this.tableLayoutPanelFiltros.Controls.Add(this.dtpFechaDesde, 0, 3);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblFechaHasta, 1, 2);
            this.tableLayoutPanelFiltros.Controls.Add(this.dtpFechaHasta, 1, 3);
            this.tableLayoutPanelFiltros.Controls.Add(this.tableLayoutPanelBotonesFiltro, 3, 1);
            this.tableLayoutPanelFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiltros.Location = new System.Drawing.Point(10, 65);
            this.tableLayoutPanelFiltros.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            this.tableLayoutPanelFiltros.RowCount = 4;
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelFiltros.Size = new System.Drawing.Size(1180, 130);
            this.tableLayoutPanelFiltros.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCliente.Location = new System.Drawing.Point(3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(289, 25);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Tag = "lblCliente";
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbCliente
            // 
            this.cmbCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(3, 28);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(289, 21);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVenta.Location = new System.Drawing.Point(298, 0);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(289, 25);
            this.lblVenta.TabIndex = 2;
            this.lblVenta.Tag = "lblVenta";
            this.lblVenta.Text = "Venta:";
            this.lblVenta.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbVenta
            // 
            this.cmbVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenta.FormattingEnabled = true;
            this.cmbVenta.Location = new System.Drawing.Point(298, 28);
            this.cmbVenta.Name = "cmbVenta";
            this.cmbVenta.Size = new System.Drawing.Size(289, 21);
            this.cmbVenta.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Location = new System.Drawing.Point(593, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(289, 25);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Tag = "lblEstado";
            this.lblEstado.Text = "Estado:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(593, 28);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(289, 21);
            this.cmbEstado.TabIndex = 5;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaDesde.Location = new System.Drawing.Point(3, 55);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(289, 25);
            this.lblFechaDesde.TabIndex = 6;
            this.lblFechaDesde.Tag = "lblFechaDesde";
            this.lblFechaDesde.Text = "Fecha Desde:";
            this.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Checked = false;
            this.dtpFechaDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(3, 83);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            this.dtpFechaDesde.Size = new System.Drawing.Size(289, 20);
            this.dtpFechaDesde.TabIndex = 7;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaHasta.Location = new System.Drawing.Point(298, 55);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(289, 25);
            this.lblFechaHasta.TabIndex = 8;
            this.lblFechaHasta.Tag = "lblFechaHasta";
            this.lblFechaHasta.Text = "Fecha Hasta:";
            this.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Checked = false;
            this.dtpFechaHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(298, 83);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            this.dtpFechaHasta.Size = new System.Drawing.Size(289, 20);
            this.dtpFechaHasta.TabIndex = 9;
            // 
            // tableLayoutPanelBotonesFiltro
            // 
            this.tableLayoutPanelBotonesFiltro.ColumnCount = 1;
            this.tableLayoutPanelBotonesFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBotonesFiltro.Controls.Add(this.btnBuscar, 0, 0);
            this.tableLayoutPanelBotonesFiltro.Controls.Add(this.btnLimpiar, 0, 1);
            this.tableLayoutPanelBotonesFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBotonesFiltro.Location = new System.Drawing.Point(888, 28);
            this.tableLayoutPanelBotonesFiltro.Name = "tableLayoutPanelBotonesFiltro";
            this.tableLayoutPanelBotonesFiltro.RowCount = 2;
            this.tableLayoutPanelFiltros.SetRowSpan(this.tableLayoutPanelBotonesFiltro, 3);
            this.tableLayoutPanelBotonesFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotonesFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotonesFiltro.Size = new System.Drawing.Size(289, 99);
            this.tableLayoutPanelBotonesFiltro.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(283, 43);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Tag = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(3, 52);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(283, 44);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Tag = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dataGridViewHistorial
            // 
            this.dataGridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistorial.Location = new System.Drawing.Point(10, 205);
            this.dataGridViewHistorial.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dataGridViewHistorial.Name = "dataGridViewHistorial";
            this.dataGridViewHistorial.Size = new System.Drawing.Size(1180, 430);
            this.dataGridViewHistorial.TabIndex = 2;
            this.dataGridViewHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistorial_CellDoubleClick);
            // 
            // tableLayoutPanelFooter
            // 
            this.tableLayoutPanelFooter.ColumnCount = 2;
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.Controls.Add(this.lblTotalRegistros, 0, 0);
            this.tableLayoutPanelFooter.Controls.Add(this.tableLayoutPanelAcciones, 1, 0);
            this.tableLayoutPanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFooter.Location = new System.Drawing.Point(3, 643);
            this.tableLayoutPanelFooter.Name = "tableLayoutPanelFooter";
            this.tableLayoutPanelFooter.RowCount = 1;
            this.tableLayoutPanelFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFooter.Size = new System.Drawing.Size(1194, 54);
            this.tableLayoutPanelFooter.TabIndex = 3;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.Location = new System.Drawing.Point(3, 0);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(591, 54);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Tag = "lblTotalRegistros";
            this.lblTotalRegistros.Text = "Total: 0 registro(s)";
            this.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelAcciones
            // 
            this.tableLayoutPanelAcciones.ColumnCount = 3;
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAcciones.Controls.Add(this.btnExportarPDF, 0, 0);
            this.tableLayoutPanelAcciones.Controls.Add(this.btnExportarExcel, 1, 0);
            this.tableLayoutPanelAcciones.Controls.Add(this.btnCerrar, 2, 0);
            this.tableLayoutPanelAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAcciones.Location = new System.Drawing.Point(600, 3);
            this.tableLayoutPanelAcciones.Name = "tableLayoutPanelAcciones";
            this.tableLayoutPanelAcciones.RowCount = 1;
            this.tableLayoutPanelAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAcciones.Size = new System.Drawing.Size(591, 48);
            this.tableLayoutPanelAcciones.TabIndex = 1;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(3, 3);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(191, 42);
            this.btnExportarPDF.TabIndex = 0;
            this.btnExportarPDF.Tag = "Button_ExportarHistorialDev_GesDev";
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(200, 3);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(191, 42);
            this.btnExportarExcel.TabIndex = 1;
            this.btnExportarExcel.Tag = "Button_ExportarHistorialDev_GesDev";
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(397, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(191, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Tag = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmHistorialDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistorialDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "FormHistorialDevoluciones";
            this.Text = "Historial de Devoluciones";
            this.Load += new System.EventHandler(this.frmHistorialDevoluciones_Load);
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.tableLayoutPanelFiltros.ResumeLayout(false);
            this.tableLayoutPanelFiltros.PerformLayout();
            this.tableLayoutPanelBotonesFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).EndInit();
            this.tableLayoutPanelFooter.ResumeLayout(false);
            this.tableLayoutPanelFooter.PerformLayout();
            this.tableLayoutPanelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFiltros;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.ComboBox cmbVenta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBotonesFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dataGridViewHistorial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFooter;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAcciones;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnCerrar;
    }
}

