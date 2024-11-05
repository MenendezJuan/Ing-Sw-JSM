namespace Form1
{
    partial class frmGestionCotizacionProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionCotizacionProductos));
            this.groupBoxBuscar = new System.Windows.Forms.GroupBox();
            this.btnReestablecer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.labelHasta = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.labelDesde = new System.Windows.Forms.Label();
            this.groupBoxCompra = new System.Windows.Forms.GroupBox();
            this.dataGridViewCotizaciones = new System.Windows.Forms.DataGridView();
            this.btnSolicitarCotizacion = new System.Windows.Forms.Button();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetalle = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelEstado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxBuscar.SuspendLayout();
            this.groupBoxCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotizaciones)).BeginInit();
            this.groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBuscar
            // 
            this.groupBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBuscar.Controls.Add(this.btnReestablecer);
            this.groupBoxBuscar.Controls.Add(this.btnBuscar);
            this.groupBoxBuscar.Controls.Add(this.dateTimePickerHasta);
            this.groupBoxBuscar.Controls.Add(this.labelHasta);
            this.groupBoxBuscar.Controls.Add(this.dateTimePickerDesde);
            this.groupBoxBuscar.Controls.Add(this.labelDesde);
            this.groupBoxBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxBuscar.Location = new System.Drawing.Point(3, 177);
            this.groupBoxBuscar.Name = "groupBoxBuscar";
            this.groupBoxBuscar.Size = new System.Drawing.Size(397, 168);
            this.groupBoxBuscar.TabIndex = 84;
            this.groupBoxBuscar.TabStop = false;
            this.groupBoxBuscar.Text = "Buscar";
            // 
            // btnReestablecer
            // 
            this.btnReestablecer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnReestablecer.FlatAppearance.BorderSize = 2;
            this.btnReestablecer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnReestablecer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnReestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReestablecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReestablecer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnReestablecer.Location = new System.Drawing.Point(253, 82);
            this.btnReestablecer.Name = "btnReestablecer";
            this.btnReestablecer.Size = new System.Drawing.Size(123, 37);
            this.btnReestablecer.TabIndex = 64;
            this.btnReestablecer.Text = "Reestablecer";
            this.btnReestablecer.UseVisualStyleBackColor = true;
            this.btnReestablecer.Click += new System.EventHandler(this.btnReestablecer_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnBuscar.Location = new System.Drawing.Point(254, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 37);
            this.btnBuscar.TabIndex = 63;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(59, 82);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(153, 22);
            this.dateTimePickerHasta.TabIndex = 62;
            // 
            // labelHasta
            // 
            this.labelHasta.AutoSize = true;
            this.labelHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelHasta.Location = new System.Drawing.Point(6, 82);
            this.labelHasta.Name = "labelHasta";
            this.labelHasta.Size = new System.Drawing.Size(47, 18);
            this.labelHasta.TabIndex = 61;
            this.labelHasta.Text = "Hasta";
            this.labelHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(63, 28);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(153, 22);
            this.dateTimePickerDesde.TabIndex = 60;
            // 
            // labelDesde
            // 
            this.labelDesde.AutoSize = true;
            this.labelDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelDesde.Location = new System.Drawing.Point(6, 28);
            this.labelDesde.Name = "labelDesde";
            this.labelDesde.Size = new System.Drawing.Size(51, 18);
            this.labelDesde.TabIndex = 59;
            this.labelDesde.Text = "Desde";
            this.labelDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxCompra
            // 
            this.groupBoxCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCompra.Controls.Add(this.dataGridViewCotizaciones);
            this.groupBoxCompra.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCompra.Name = "groupBoxCompra";
            this.groupBoxCompra.Size = new System.Drawing.Size(396, 272);
            this.groupBoxCompra.TabIndex = 83;
            this.groupBoxCompra.TabStop = false;
            // 
            // dataGridViewCotizaciones
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewCotizaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCotizaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCotizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCotizaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCotizaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCotizaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCotizaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCotizaciones.EnableHeadersVisualStyles = false;
            this.dataGridViewCotizaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewCotizaciones.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewCotizaciones.Name = "dataGridViewCotizaciones";
            this.dataGridViewCotizaciones.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCotizaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCotizaciones.RowHeadersVisible = false;
            this.dataGridViewCotizaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCotizaciones.Size = new System.Drawing.Size(377, 246);
            this.dataGridViewCotizaciones.TabIndex = 43;
            this.dataGridViewCotizaciones.SelectionChanged += new System.EventHandler(this.dataGridViewCotizaciones_SelectionChanged);
            // 
            // btnSolicitarCotizacion
            // 
            this.btnSolicitarCotizacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSolicitarCotizacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSolicitarCotizacion.FlatAppearance.BorderSize = 2;
            this.btnSolicitarCotizacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnSolicitarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSolicitarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitarCotizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSolicitarCotizacion.Location = new System.Drawing.Point(70, 294);
            this.btnSolicitarCotizacion.Name = "btnSolicitarCotizacion";
            this.btnSolicitarCotizacion.Size = new System.Drawing.Size(261, 37);
            this.btnSolicitarCotizacion.TabIndex = 80;
            this.btnSolicitarCotizacion.Text = "Solicitar Orden de Cotizacion";
            this.btnSolicitarCotizacion.UseVisualStyleBackColor = true;
            this.btnSolicitarCotizacion.Click += new System.EventHandler(this.btnSolicitarCotizacion_Click);
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetalle.Controls.Add(this.dataGridViewDetalle);
            this.groupBoxDetalle.Controls.Add(this.panel1);
            this.groupBoxDetalle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxDetalle.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Size = new System.Drawing.Size(397, 168);
            this.groupBoxDetalle.TabIndex = 82;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle de Cotizacion";
            // 
            // dataGridViewDetalle
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDetalle.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetalle.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewDetalle.Enabled = false;
            this.dataGridViewDetalle.EnableHeadersVisualStyles = false;
            this.dataGridViewDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewDetalle.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewDetalle.Name = "dataGridViewDetalle";
            this.dataGridViewDetalle.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDetalle.RowHeadersVisible = false;
            this.dataGridViewDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetalle.Size = new System.Drawing.Size(378, 142);
            this.dataGridViewDetalle.TabIndex = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelEstado);
            this.panel1.Location = new System.Drawing.Point(6, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 21);
            this.panel1.TabIndex = 59;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelEstado.Location = new System.Drawing.Point(309, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(83, 18);
            this.labelEstado.TabIndex = 58;
            this.labelEstado.Text = "Rechazada";
            this.labelEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(104, 25);
            this.lblTitulo.TabIndex = 79;
            this.lblTitulo.Text = "Cotizacion";
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
            this.btnCerrar.Location = new System.Drawing.Point(715, 470);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCerrar.Size = new System.Drawing.Size(95, 30);
            this.btnCerrar.TabIndex = 78;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(813, 503);
            this.tableLayoutPanel1.TabIndex = 85;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxBuscar, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxDetalle, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(408, 52);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(403, 348);
            this.tableLayoutPanel2.TabIndex = 86;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxCompra, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSolicitarCotizacion, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 52);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(402, 348);
            this.tableLayoutPanel3.TabIndex = 87;
            // 
            // frmGestionCotizacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(819, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGestionCotizacionProductos";
            this.Text = "GestionCotizacionProductos";
            this.Load += new System.EventHandler(this.frmGestionCompraProductos_Load);
            this.groupBoxBuscar.ResumeLayout(false);
            this.groupBoxBuscar.PerformLayout();
            this.groupBoxCompra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotizaciones)).EndInit();
            this.groupBoxDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBuscar;
        private System.Windows.Forms.Button btnReestablecer;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label labelHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.Label labelDesde;
        private System.Windows.Forms.GroupBox groupBoxCompra;
        internal System.Windows.Forms.DataGridView dataGridViewCotizaciones;
        private System.Windows.Forms.Button btnSolicitarCotizacion;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        internal System.Windows.Forms.DataGridView dataGridViewDetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}