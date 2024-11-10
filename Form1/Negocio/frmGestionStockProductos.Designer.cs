namespace Form1
{
    partial class frmGestionStockProductos
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
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.buttonAgregarProductoProveedorSelec = new System.Windows.Forms.Button();
            this.buttonActualizarProducto = new System.Windows.Forms.Button();
            this.buttonEliminarProducto = new System.Windows.Forms.Button();
            this.panelDatosProducto = new System.Windows.Forms.Panel();
            this.numericUpDownPrecioCompra = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeleccionadoEspecifico = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBorrarIngresoDatos = new System.Windows.Forms.Button();
            this.estadolbl = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.lblDatos = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBorrarBusqueda = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.comboBuscar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.panelDatosProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioCompra)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloProductos
            // 
            this.lblTituloProductos.AutoSize = true;
            this.lblTituloProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTituloProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTituloProductos.Location = new System.Drawing.Point(12, 18);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Size = new System.Drawing.Size(189, 25);
            this.lblTituloProductos.TabIndex = 101;
            this.lblTituloProductos.Text = "Gestionar Productos";
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.AllowUserToResizeColumns = false;
            this.dataGridViewProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProductos.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProductos.EnableHeadersVisualStyles = false;
            this.dataGridViewProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewProductos.Location = new System.Drawing.Point(75, 65);
            this.dataGridViewProductos.MultiSelect = false;
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProductos.RowHeadersVisible = false;
            this.dataGridViewProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductos.Size = new System.Drawing.Size(973, 272);
            this.dataGridViewProductos.TabIndex = 84;
            this.dataGridViewProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewProductos_CellFormatting);
            this.dataGridViewProductos.SelectionChanged += new System.EventHandler(this.dataGridViewProductos_SelectionChanged);
            // 
            // buttonAgregarProductoProveedorSelec
            // 
            this.buttonAgregarProductoProveedorSelec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonAgregarProductoProveedorSelec.FlatAppearance.BorderSize = 2;
            this.buttonAgregarProductoProveedorSelec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.buttonAgregarProductoProveedorSelec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonAgregarProductoProveedorSelec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarProductoProveedorSelec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarProductoProveedorSelec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonAgregarProductoProveedorSelec.Location = new System.Drawing.Point(79, 368);
            this.buttonAgregarProductoProveedorSelec.Name = "buttonAgregarProductoProveedorSelec";
            this.buttonAgregarProductoProveedorSelec.Size = new System.Drawing.Size(164, 38);
            this.buttonAgregarProductoProveedorSelec.TabIndex = 107;
            this.buttonAgregarProductoProveedorSelec.Text = "Agregar";
            this.buttonAgregarProductoProveedorSelec.UseVisualStyleBackColor = true;
            this.buttonAgregarProductoProveedorSelec.Click += new System.EventHandler(this.buttonAgregarProductoProveedorSelec_Click);
            // 
            // buttonActualizarProducto
            // 
            this.buttonActualizarProducto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonActualizarProducto.FlatAppearance.BorderSize = 2;
            this.buttonActualizarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.buttonActualizarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonActualizarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActualizarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActualizarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonActualizarProducto.Location = new System.Drawing.Point(272, 368);
            this.buttonActualizarProducto.Name = "buttonActualizarProducto";
            this.buttonActualizarProducto.Size = new System.Drawing.Size(164, 38);
            this.buttonActualizarProducto.TabIndex = 108;
            this.buttonActualizarProducto.Text = "Actualizar";
            this.buttonActualizarProducto.UseVisualStyleBackColor = true;
            this.buttonActualizarProducto.Click += new System.EventHandler(this.buttonActualizarProducto_Click);
            // 
            // buttonEliminarProducto
            // 
            this.buttonEliminarProducto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonEliminarProducto.FlatAppearance.BorderSize = 2;
            this.buttonEliminarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.buttonEliminarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonEliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.buttonEliminarProducto.Location = new System.Drawing.Point(465, 368);
            this.buttonEliminarProducto.Name = "buttonEliminarProducto";
            this.buttonEliminarProducto.Size = new System.Drawing.Size(164, 38);
            this.buttonEliminarProducto.TabIndex = 109;
            this.buttonEliminarProducto.Text = "Eliminar";
            this.buttonEliminarProducto.UseVisualStyleBackColor = true;
            this.buttonEliminarProducto.Click += new System.EventHandler(this.buttonEliminarProducto_Click);
            // 
            // panelDatosProducto
            // 
            this.panelDatosProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelDatosProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosProducto.Controls.Add(this.checkBoxActivo);
            this.panelDatosProducto.Controls.Add(this.numericUpDownPrecioCompra);
            this.panelDatosProducto.Controls.Add(this.label6);
            this.panelDatosProducto.Controls.Add(this.comboCategoria);
            this.panelDatosProducto.Controls.Add(this.label4);
            this.panelDatosProducto.Controls.Add(this.lblSeleccionadoEspecifico);
            this.panelDatosProducto.Controls.Add(this.txtDescripcion);
            this.panelDatosProducto.Controls.Add(this.label5);
            this.panelDatosProducto.Controls.Add(this.lblSeleccionado);
            this.panelDatosProducto.Controls.Add(this.txtNombre);
            this.panelDatosProducto.Controls.Add(this.label3);
            this.panelDatosProducto.Controls.Add(this.btnBorrarIngresoDatos);
            this.panelDatosProducto.Controls.Add(this.estadolbl);
            this.panelDatosProducto.Controls.Add(this.btnAceptar);
            this.panelDatosProducto.Controls.Add(this.comboProveedor);
            this.panelDatosProducto.Controls.Add(this.lblDatos);
            this.panelDatosProducto.Controls.Add(this.txtCodigo);
            this.panelDatosProducto.Controls.Add(this.label1);
            this.panelDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDatosProducto.Location = new System.Drawing.Point(63, 439);
            this.panelDatosProducto.Name = "panelDatosProducto";
            this.panelDatosProducto.Size = new System.Drawing.Size(681, 283);
            this.panelDatosProducto.TabIndex = 110;
            this.panelDatosProducto.Visible = false;
            // 
            // numericUpDownPrecioCompra
            // 
            this.numericUpDownPrecioCompra.Location = new System.Drawing.Point(428, 118);
            this.numericUpDownPrecioCompra.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDownPrecioCompra.Name = "numericUpDownPrecioCompra";
            this.numericUpDownPrecioCompra.Size = new System.Drawing.Size(180, 21);
            this.numericUpDownPrecioCompra.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(425, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 74;
            this.label6.Tag = "Descripcion";
            this.label6.Text = "Precio Compra";
            // 
            // comboCategoria
            // 
            this.comboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategoria.FormattingEnabled = true;
            this.comboCategoria.Location = new System.Drawing.Point(428, 61);
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(180, 23);
            this.comboCategoria.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(425, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 71;
            this.label4.Tag = "Categoria";
            this.label4.Text = "Categoría";
            // 
            // lblSeleccionadoEspecifico
            // 
            this.lblSeleccionadoEspecifico.AutoSize = true;
            this.lblSeleccionadoEspecifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionadoEspecifico.Location = new System.Drawing.Point(12, 182);
            this.lblSeleccionadoEspecifico.Name = "lblSeleccionadoEspecifico";
            this.lblSeleccionadoEspecifico.Size = new System.Drawing.Size(11, 16);
            this.lblSeleccionadoEspecifico.TabIndex = 69;
            this.lblSeleccionadoEspecifico.Text = "-";
            this.lblSeleccionadoEspecifico.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(15, 115);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(180, 23);
            this.txtDescripcion.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 72;
            this.label5.Tag = "estado";
            this.label5.Text = "Proveedor";
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionado.Location = new System.Drawing.Point(12, 163);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(159, 15);
            this.lblSeleccionado.TabIndex = 68;
            this.lblSeleccionado.Tag = "ProductoSeleccionado";
            this.lblSeleccionado.Text = "Producto Seleccionado:";
            this.lblSeleccionado.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(224, 59);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 21);
            this.txtNombre.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 70;
            this.label3.Tag = "Descripcion";
            this.label3.Text = "Descripción";
            // 
            // btnBorrarIngresoDatos
            // 
            this.btnBorrarIngresoDatos.AutoEllipsis = true;
            this.btnBorrarIngresoDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBorrarIngresoDatos.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBorrarIngresoDatos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.btnBorrarIngresoDatos.FlatAppearance.BorderSize = 0;
            this.btnBorrarIngresoDatos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(20)))), ((int)(((byte)(57)))));
            this.btnBorrarIngresoDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarIngresoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarIngresoDatos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarIngresoDatos.Location = new System.Drawing.Point(341, 231);
            this.btnBorrarIngresoDatos.Name = "btnBorrarIngresoDatos";
            this.btnBorrarIngresoDatos.Size = new System.Drawing.Size(144, 35);
            this.btnBorrarIngresoDatos.TabIndex = 68;
            this.btnBorrarIngresoDatos.Tag = "btnBorrar";
            this.btnBorrarIngresoDatos.Text = "Borrar";
            this.btnBorrarIngresoDatos.UseVisualStyleBackColor = false;
            this.btnBorrarIngresoDatos.Click += new System.EventHandler(this.btnBorrarIngresoDatos_Click);
            // 
            // estadolbl
            // 
            this.estadolbl.AutoSize = true;
            this.estadolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadolbl.Location = new System.Drawing.Point(221, 43);
            this.estadolbl.Name = "estadolbl";
            this.estadolbl.Size = new System.Drawing.Size(52, 15);
            this.estadolbl.TabIndex = 63;
            this.estadolbl.Tag = "lblNombre";
            this.estadolbl.Text = "Nombre";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoEllipsis = true;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(20)))), ((int)(((byte)(57)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAceptar.Location = new System.Drawing.Point(517, 231);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(144, 35);
            this.btnAceptar.TabIndex = 61;
            this.btnAceptar.Tag = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboProveedor
            // 
            this.comboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProveedor.FormattingEnabled = true;
            this.comboProveedor.Items.AddRange(new object[] {
            "Activado",
            "Desactivado"});
            this.comboProveedor.Location = new System.Drawing.Point(225, 115);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(179, 23);
            this.comboProveedor.TabIndex = 68;
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.Location = new System.Drawing.Point(7, 11);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(129, 20);
            this.lblDatos.TabIndex = 58;
            this.lblDatos.Text = "Ingresar Datos";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 59);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(180, 21);
            this.txtCodigo.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 51;
            this.label1.Tag = "codigo";
            this.label1.Text = "Código";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBorrarBusqueda);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.comboBuscar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(774, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 283);
            this.panel1.TabIndex = 111;
            // 
            // btnBorrarBusqueda
            // 
            this.btnBorrarBusqueda.AutoEllipsis = true;
            this.btnBorrarBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBorrarBusqueda.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBorrarBusqueda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.btnBorrarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnBorrarBusqueda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(20)))), ((int)(((byte)(57)))));
            this.btnBorrarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarBusqueda.Location = new System.Drawing.Point(11, 200);
            this.btnBorrarBusqueda.Name = "btnBorrarBusqueda";
            this.btnBorrarBusqueda.Size = new System.Drawing.Size(121, 35);
            this.btnBorrarBusqueda.TabIndex = 67;
            this.btnBorrarBusqueda.Tag = "btnBorrar";
            this.btnBorrarBusqueda.Text = "Borrar";
            this.btnBorrarBusqueda.UseVisualStyleBackColor = false;
            this.btnBorrarBusqueda.Click += new System.EventHandler(this.btnBorrarBusqueda_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoEllipsis = true;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(20)))), ((int)(((byte)(57)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscar.Location = new System.Drawing.Point(138, 200);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 35);
            this.btnBuscar.TabIndex = 66;
            this.btnBuscar.Tag = "lblBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(11, 146);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(246, 21);
            this.txtBuscar.TabIndex = 61;
            // 
            // comboBuscar
            // 
            this.comboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBuscar.FormattingEnabled = true;
            this.comboBuscar.Location = new System.Drawing.Point(11, 85);
            this.comboBuscar.Name = "comboBuscar";
            this.comboBuscar.Size = new System.Drawing.Size(246, 23);
            this.comboBuscar.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 59;
            this.label2.Tag = "lblBuscarPor";
            this.label2.Text = "Buscar por:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 58;
            this.label8.Tag = "lblBuscarEnLaGrilla";
            this.label8.Text = "Buscar en la Grilla";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoEllipsis = true;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRefresh.Location = new System.Drawing.Point(931, 374);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 32);
            this.btnRefresh.TabIndex = 112;
            this.btnRefresh.Tag = "btnRefresh";
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnExportar.IconColor = System.Drawing.Color.White;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 18;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(774, 374);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(133, 32);
            this.btnExportar.TabIndex = 113;
            this.btnExportar.Tag = "btnExportExcel";
            this.btnExportar.Text = "Export Excel";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.AutoSize = true;
            this.checkBoxActivo.Location = new System.Drawing.Point(224, 163);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(91, 19);
            this.checkBoxActivo.TabIndex = 77;
            this.checkBoxActivo.Text = "Esta activo?";
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            this.checkBoxActivo.Visible = false;
            // 
            // frmGestionStockProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1110, 754);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDatosProducto);
            this.Controls.Add(this.dataGridViewProductos);
            this.Controls.Add(this.buttonEliminarProducto);
            this.Controls.Add(this.buttonActualizarProducto);
            this.Controls.Add(this.buttonAgregarProductoProveedorSelec);
            this.Controls.Add(this.lblTituloProductos);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "frmGestionStockProductos";
            this.Text = "GestionStockProductos";
            this.Load += new System.EventHandler(this.frmGestionStockProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.panelDatosProducto.ResumeLayout(false);
            this.panelDatosProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloProductos;
        internal System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Button buttonAgregarProductoProveedorSelec;
        private System.Windows.Forms.Button buttonActualizarProducto;
        private System.Windows.Forms.Button buttonEliminarProducto;
        private System.Windows.Forms.Panel panelDatosProducto;
        private System.Windows.Forms.ComboBox comboCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeleccionadoEspecifico;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSeleccionado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBorrarIngresoDatos;
        private System.Windows.Forms.Label estadolbl;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox comboProveedor;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBorrarBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox comboBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btnExportar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecioCompra;
        private System.Windows.Forms.CheckBox checkBoxActivo;
    }
}