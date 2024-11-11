namespace Form1.Negocio
{
    partial class frmVerificacionProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBoxLlegaronProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxCondicionesProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxCantidadProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxEmpaqueProductos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.btnAprobarRecepcion = new FontAwesome.Sharp.IconButton();
            this.btnRechazarRecepcion = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewDetalleCompra = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetalleCotizacion = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxFirma = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFirmarConforme = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFirm = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirma)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxLlegaronProductos
            // 
            this.checkBoxLlegaronProductos.AutoSize = true;
            this.checkBoxLlegaronProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLlegaronProductos.Location = new System.Drawing.Point(3, 3);
            this.checkBoxLlegaronProductos.Name = "checkBoxLlegaronProductos";
            this.checkBoxLlegaronProductos.Size = new System.Drawing.Size(322, 28);
            this.checkBoxLlegaronProductos.TabIndex = 4;
            this.checkBoxLlegaronProductos.Text = "¿Llegaron todos los productos?";
            this.checkBoxLlegaronProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxCondicionesProductos
            // 
            this.checkBoxCondicionesProductos.AutoSize = true;
            this.checkBoxCondicionesProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCondicionesProductos.Location = new System.Drawing.Point(3, 103);
            this.checkBoxCondicionesProductos.Name = "checkBoxCondicionesProductos";
            this.checkBoxCondicionesProductos.Size = new System.Drawing.Size(385, 28);
            this.checkBoxCondicionesProductos.TabIndex = 5;
            this.checkBoxCondicionesProductos.Text = "¿Están los productos en condiciones?";
            this.checkBoxCondicionesProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxCantidadProductos
            // 
            this.checkBoxCantidadProductos.AutoSize = true;
            this.checkBoxCantidadProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCantidadProductos.Location = new System.Drawing.Point(3, 68);
            this.checkBoxCantidadProductos.Name = "checkBoxCantidadProductos";
            this.checkBoxCantidadProductos.Size = new System.Drawing.Size(365, 28);
            this.checkBoxCantidadProductos.TabIndex = 6;
            this.checkBoxCantidadProductos.Text = "¿Las cantidades son las solicitadas?";
            this.checkBoxCantidadProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpaqueProductos
            // 
            this.checkBoxEmpaqueProductos.AutoSize = true;
            this.checkBoxEmpaqueProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEmpaqueProductos.Location = new System.Drawing.Point(3, 3);
            this.checkBoxEmpaqueProductos.Name = "checkBoxEmpaqueProductos";
            this.checkBoxEmpaqueProductos.Size = new System.Drawing.Size(396, 28);
            this.checkBoxEmpaqueProductos.TabIndex = 7;
            this.checkBoxEmpaqueProductos.Text = "¿Los empaques estan en buen estado?";
            this.checkBoxEmpaqueProductos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Observaciones";
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservaciones.Location = new System.Drawing.Point(441, 480);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.Size = new System.Drawing.Size(442, 201);
            this.textBoxObservaciones.TabIndex = 9;
            // 
            // btnAprobarRecepcion
            // 
            this.btnAprobarRecepcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAprobarRecepcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAprobarRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobarRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAprobarRecepcion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAprobarRecepcion.IconColor = System.Drawing.Color.Black;
            this.btnAprobarRecepcion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAprobarRecepcion.Location = new System.Drawing.Point(19, 112);
            this.btnAprobarRecepcion.Name = "btnAprobarRecepcion";
            this.btnAprobarRecepcion.Size = new System.Drawing.Size(183, 57);
            this.btnAprobarRecepcion.TabIndex = 10;
            this.btnAprobarRecepcion.Text = "Aprobar Recepcion";
            this.btnAprobarRecepcion.UseVisualStyleBackColor = false;
            this.btnAprobarRecepcion.Click += new System.EventHandler(this.btnAprobarRecepcion_Click);
            // 
            // btnRechazarRecepcion
            // 
            this.btnRechazarRecepcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRechazarRecepcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRechazarRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazarRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRechazarRecepcion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRechazarRecepcion.IconColor = System.Drawing.Color.Black;
            this.btnRechazarRecepcion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRechazarRecepcion.Location = new System.Drawing.Point(240, 111);
            this.btnRechazarRecepcion.Name = "btnRechazarRecepcion";
            this.btnRechazarRecepcion.Size = new System.Drawing.Size(183, 59);
            this.btnRechazarRecepcion.TabIndex = 11;
            this.btnRechazarRecepcion.Text = "Rechazar Recepcion";
            this.btnRechazarRecepcion.UseVisualStyleBackColor = false;
            this.btnRechazarRecepcion.Click += new System.EventHandler(this.btnRechazarRecepcion_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.90207F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.70652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.39141F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDetalleCotizacion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxObservaciones, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDetalleCompra, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1332, 684);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // dataGridViewDetalleCompra
            // 
            this.dataGridViewDetalleCompra.AllowUserToAddRows = false;
            this.dataGridViewDetalleCompra.AllowUserToDeleteRows = false;
            this.dataGridViewDetalleCompra.AllowUserToResizeColumns = false;
            this.dataGridViewDetalleCompra.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewDetalleCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewDetalleCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetalleCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDetalleCompra.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetalleCompra.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewDetalleCompra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetalleCompra.EnableHeadersVisualStyles = false;
            this.dataGridViewDetalleCompra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewDetalleCompra.Location = new System.Drawing.Point(3, 57);
            this.dataGridViewDetalleCompra.MultiSelect = false;
            this.dataGridViewDetalleCompra.Name = "dataGridViewDetalleCompra";
            this.dataGridViewDetalleCompra.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewDetalleCompra.RowHeadersVisible = false;
            this.dataGridViewDetalleCompra.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetalleCompra.Size = new System.Drawing.Size(432, 281);
            this.dataGridViewDetalleCompra.TabIndex = 85;
            // 
            // dataGridViewDetalleCotizacion
            // 
            this.dataGridViewDetalleCotizacion.AllowUserToAddRows = false;
            this.dataGridViewDetalleCotizacion.AllowUserToDeleteRows = false;
            this.dataGridViewDetalleCotizacion.AllowUserToResizeColumns = false;
            this.dataGridViewDetalleCotizacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewDetalleCotizacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewDetalleCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetalleCotizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetalleCotizacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDetalleCotizacion.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCotizacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewDetalleCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetalleCotizacion.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewDetalleCotizacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetalleCotizacion.EnableHeadersVisualStyles = false;
            this.dataGridViewDetalleCotizacion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewDetalleCotizacion.Location = new System.Drawing.Point(889, 57);
            this.dataGridViewDetalleCotizacion.MultiSelect = false;
            this.dataGridViewDetalleCotizacion.Name = "dataGridViewDetalleCotizacion";
            this.dataGridViewDetalleCotizacion.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetalleCotizacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewDetalleCotizacion.RowHeadersVisible = false;
            this.dataGridViewDetalleCotizacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewDetalleCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetalleCotizacion.Size = new System.Drawing.Size(440, 281);
            this.dataGridViewDetalleCotizacion.TabIndex = 86;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxLlegaronProductos, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCondicionesProductos, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 480);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 201);
            this.tableLayoutPanel2.TabIndex = 87;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxEmpaqueProductos, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxCantidadProductos, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 344);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(432, 130);
            this.tableLayoutPanel3.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalle de la Orden";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(889, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Productos Solicitados";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnAprobarRecepcion, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnRechazarRecepcion, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(441, 57);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(442, 281);
            this.tableLayoutPanel4.TabIndex = 89;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBoxFirma, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(889, 480);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(440, 201);
            this.tableLayoutPanel5.TabIndex = 90;
            // 
            // pictureBoxFirma
            // 
            this.pictureBoxFirma.BackColor = System.Drawing.Color.Snow;
            this.pictureBoxFirma.Location = new System.Drawing.Point(3, 23);
            this.pictureBoxFirma.Name = "pictureBoxFirma";
            this.pictureBoxFirma.Size = new System.Drawing.Size(434, 175);
            this.pictureBoxFirma.TabIndex = 0;
            this.pictureBoxFirma.TabStop = false;
            this.pictureBoxFirma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFirma_MouseDown);
            this.pictureBoxFirma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFirma_MouseMove);
            this.pictureBoxFirma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFirma_MouseUp);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnFirmarConforme, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnLimpiarFirm, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(889, 344);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(440, 130);
            this.tableLayoutPanel6.TabIndex = 91;
            // 
            // btnFirmarConforme
            // 
            this.btnFirmarConforme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFirmarConforme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnFirmarConforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmarConforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFirmarConforme.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnFirmarConforme.IconColor = System.Drawing.Color.Black;
            this.btnFirmarConforme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFirmarConforme.Location = new System.Drawing.Point(18, 69);
            this.btnFirmarConforme.Name = "btnFirmarConforme";
            this.btnFirmarConforme.Size = new System.Drawing.Size(183, 57);
            this.btnFirmarConforme.TabIndex = 11;
            this.btnFirmarConforme.Text = "Firmar";
            this.btnFirmarConforme.UseVisualStyleBackColor = false;
            this.btnFirmarConforme.Click += new System.EventHandler(this.btnFirmarConforme_Click);
            // 
            // btnLimpiarFirm
            // 
            this.btnLimpiarFirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiarFirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnLimpiarFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFirm.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnLimpiarFirm.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarFirm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarFirm.Location = new System.Drawing.Point(238, 69);
            this.btnLimpiarFirm.Name = "btnLimpiarFirm";
            this.btnLimpiarFirm.Size = new System.Drawing.Size(183, 57);
            this.btnLimpiarFirm.TabIndex = 12;
            this.btnLimpiarFirm.Text = "Limpiar Firma";
            this.btnLimpiarFirm.UseVisualStyleBackColor = false;
            this.btnLimpiarFirm.Click += new System.EventHandler(this.btnLimpiarFirm_Click);
            // 
            // frmVerificacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1332, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "frmVerificacionProductos";
            this.Text = "frmVerificacionProductos";
            this.Load += new System.EventHandler(this.frmVerificacionProductos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirma)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxLlegaronProductos;
        private System.Windows.Forms.CheckBox checkBoxCondicionesProductos;
        private System.Windows.Forms.CheckBox checkBoxCantidadProductos;
        private System.Windows.Forms.CheckBox checkBoxEmpaqueProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxObservaciones;
        private FontAwesome.Sharp.IconButton btnAprobarRecepcion;
        private FontAwesome.Sharp.IconButton btnRechazarRecepcion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.DataGridView dataGridViewDetalleCompra;
        internal System.Windows.Forms.DataGridView dataGridViewDetalleCotizacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pictureBoxFirma;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private FontAwesome.Sharp.IconButton btnFirmarConforme;
        private FontAwesome.Sharp.IconButton btnLimpiarFirm;
    }
}