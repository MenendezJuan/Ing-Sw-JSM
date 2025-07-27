namespace CheeseLogix.Negocio.Ventas
{
    partial class frmCobroVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.dataGridViewDetalleCotizacion = new System.Windows.Forms.DataGridView();
            this.lblTxtResumenVenta = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.comboBoxMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblTxtTotal = new System.Windows.Forms.Label();
            this.lblTxtEstado = new System.Windows.Forms.Label();
            this.lblTxtCliente = new System.Windows.Forms.Label();
            this.lblTxtFech = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImprimirTicket = new System.Windows.Forms.Button();
            this.btnConfirmarPago = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.29546F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.70455F));
            this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDetalleCotizacion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTxtResumenVenta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.46571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.03616F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.49812F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1355, 686);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(1257, 653);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCerrar.Size = new System.Drawing.Size(95, 30);
            this.btnCerrar.TabIndex = 79;
            this.btnCerrar.Tag = "btnCerrar_frmGestionCot";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(792, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(560, 72);
            this.tableLayoutPanel7.TabIndex = 92;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(69, 26);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(142, 20);
            this.lblSeleccionarIdioma.TabIndex = 50;
            this.lblSeleccionarIdioma.Tag = "Label_Idioma_FormIni";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(335, 22);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(170, 28);
            this.cboxIdiomas.TabIndex = 49;
            this.cboxIdiomas.Tag = "Combobox_Idioma_FormIni";
            // 
            // dataGridViewDetalleCotizacion
            // 
            this.dataGridViewDetalleCotizacion.AllowUserToAddRows = false;
            this.dataGridViewDetalleCotizacion.AllowUserToDeleteRows = false;
            this.dataGridViewDetalleCotizacion.AllowUserToResizeColumns = false;
            this.dataGridViewDetalleCotizacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewDetalleCotizacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewDetalleCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetalleCotizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetalleCotizacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDetalleCotizacion.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCotizacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewDetalleCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetalleCotizacion.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewDetalleCotizacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetalleCotizacion.EnableHeadersVisualStyles = false;
            this.dataGridViewDetalleCotizacion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewDetalleCotizacion.Location = new System.Drawing.Point(3, 81);
            this.dataGridViewDetalleCotizacion.MultiSelect = false;
            this.dataGridViewDetalleCotizacion.Name = "dataGridViewDetalleCotizacion";
            this.dataGridViewDetalleCotizacion.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCotizacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewDetalleCotizacion.RowHeadersVisible = false;
            this.dataGridViewDetalleCotizacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewDetalleCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetalleCotizacion.Size = new System.Drawing.Size(783, 447);
            this.dataGridViewDetalleCotizacion.TabIndex = 86;
            // 
            // lblTxtResumenVenta
            // 
            this.lblTxtResumenVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTxtResumenVenta.AutoSize = true;
            this.lblTxtResumenVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtResumenVenta.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTxtResumenVenta.Location = new System.Drawing.Point(3, 54);
            this.lblTxtResumenVenta.Name = "lblTxtResumenVenta";
            this.lblTxtResumenVenta.Size = new System.Drawing.Size(268, 24);
            this.lblTxtResumenVenta.TabIndex = 3;
            this.lblTxtResumenVenta.Tag = "labelResumenVenta_frmCobroVenta";
            this.lblTxtResumenVenta.Text = "Resumen venta (productos)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelFecha, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelCliente, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelEstado, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxMetodoPago, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMetodoPago, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTxtTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTxtCliente, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTxtFech, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblTxtEstado, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(792, 81);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(560, 447);
            this.tableLayoutPanel2.TabIndex = 101;
            // 
            // labelFecha
            // 
            this.labelFecha.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelFecha.Location = new System.Drawing.Point(283, 356);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(250, 91);
            this.labelFecha.TabIndex = 99;
            this.labelFecha.Text = "-";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCliente
            // 
            this.labelCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelCliente.Location = new System.Drawing.Point(283, 267);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(250, 89);
            this.labelCliente.TabIndex = 98;
            this.labelCliente.Text = "-";
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEstado
            // 
            this.labelEstado.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelEstado.Location = new System.Drawing.Point(283, 178);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(250, 89);
            this.labelEstado.TabIndex = 97;
            this.labelEstado.Text = "-";
            this.labelEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMetodoPago
            // 
            this.comboBoxMetodoPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMetodoPago.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMetodoPago.FormattingEnabled = true;
            this.comboBoxMetodoPago.Location = new System.Drawing.Point(335, 119);
            this.comboBoxMetodoPago.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            this.comboBoxMetodoPago.Size = new System.Drawing.Size(170, 28);
            this.comboBoxMetodoPago.TabIndex = 96;
            this.comboBoxMetodoPago.Tag = "Combobox_MetodoPago_FrmCobroVenta";
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTotal.Location = new System.Drawing.Point(283, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(250, 89);
            this.lblTotal.TabIndex = 93;
            this.lblTotal.Text = "-";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblMetodoPago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMetodoPago.Location = new System.Drawing.Point(3, 89);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(274, 89);
            this.lblMetodoPago.TabIndex = 86;
            this.lblMetodoPago.Tag = "lblTxtMetodoPago_frmGestCoti";
            this.lblMetodoPago.Text = "Método de pago";
            this.lblMetodoPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTxtTotal
            // 
            this.lblTxtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTxtTotal.Location = new System.Drawing.Point(3, 0);
            this.lblTxtTotal.Name = "lblTxtTotal";
            this.lblTxtTotal.Size = new System.Drawing.Size(274, 89);
            this.lblTxtTotal.TabIndex = 84;
            this.lblTxtTotal.Tag = "lblTxtTotal_frmGestCoti";
            this.lblTxtTotal.Text = "Total";
            this.lblTxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTxtEstado
            // 
            this.lblTxtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTxtEstado.Location = new System.Drawing.Point(3, 178);
            this.lblTxtEstado.Name = "lblTxtEstado";
            this.lblTxtEstado.Size = new System.Drawing.Size(274, 89);
            this.lblTxtEstado.TabIndex = 92;
            this.lblTxtEstado.Tag = "lblTxtEstado_frmGestCoti";
            this.lblTxtEstado.Text = "Estado";
            this.lblTxtEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTxtCliente
            // 
            this.lblTxtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTxtCliente.Location = new System.Drawing.Point(3, 267);
            this.lblTxtCliente.Name = "lblTxtCliente";
            this.lblTxtCliente.Size = new System.Drawing.Size(274, 89);
            this.lblTxtCliente.TabIndex = 94;
            this.lblTxtCliente.Tag = "lblTxtCliente___frmCobroVenta";
            this.lblTxtCliente.Text = "Cliente";
            this.lblTxtCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTxtFech
            // 
            this.lblTxtFech.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxtFech.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtFech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtFech.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTxtFech.Location = new System.Drawing.Point(3, 356);
            this.lblTxtFech.Name = "lblTxtFech";
            this.lblTxtFech.Size = new System.Drawing.Size(274, 91);
            this.lblTxtFech.TabIndex = 95;
            this.lblTxtFech.Tag = "lblTxtEstado_frmGestCoti";
            this.lblTxtFech.Text = "Fecha";
            this.lblTxtFech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.Controls.Add(this.btnImprimirTicket, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConfirmarPago, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 534);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(783, 149);
            this.tableLayoutPanel3.TabIndex = 102;
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImprimirTicket.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnImprimirTicket.FlatAppearance.BorderSize = 2;
            this.btnImprimirTicket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnImprimirTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnImprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnImprimirTicket.Location = new System.Drawing.Point(590, 52);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(123, 44);
            this.btnImprimirTicket.TabIndex = 98;
            this.btnImprimirTicket.Tag = "btnImprimirTicket__frmCobroVenta";
            this.btnImprimirTicket.Text = "Imprimir Ticket";
            this.btnImprimirTicket.UseVisualStyleBackColor = true;
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // btnConfirmarPago
            // 
            this.btnConfirmarPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmarPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnConfirmarPago.FlatAppearance.BorderSize = 2;
            this.btnConfirmarPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnConfirmarPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnConfirmarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnConfirmarPago.Location = new System.Drawing.Point(68, 52);
            this.btnConfirmarPago.Name = "btnConfirmarPago";
            this.btnConfirmarPago.Size = new System.Drawing.Size(123, 44);
            this.btnConfirmarPago.TabIndex = 68;
            this.btnConfirmarPago.Tag = "btnConfirmarPago__frmCobroVenta";
            this.btnConfirmarPago.Text = "Confirmar Pago";
            this.btnConfirmarPago.UseVisualStyleBackColor = true;
            this.btnConfirmarPago.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnCancelar.Location = new System.Drawing.Point(329, 52);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 44);
            this.btnCancelar.TabIndex = 99;
            this.btnCancelar.Tag = "btnCancelar__frmCobroVenta";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCobroVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 685);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCobroVenta";
            this.Text = "frmDespachoProducto";
            this.Load += new System.EventHandler(this.frmCobroVenta_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        internal System.Windows.Forms.DataGridView dataGridViewDetalleCotizacion;
        private System.Windows.Forms.Label lblTxtResumenVenta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox comboBoxMetodoPago;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblTxtTotal;
        private System.Windows.Forms.Label lblTxtEstado;
        private System.Windows.Forms.Label lblTxtCliente;
        private System.Windows.Forms.Label lblTxtFech;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnImprimirTicket;
        private System.Windows.Forms.Button btnConfirmarPago;
        private System.Windows.Forms.Button btnCancelar;
    }
}