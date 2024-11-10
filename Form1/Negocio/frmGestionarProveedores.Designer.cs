namespace Form1.Negocio
{
    partial class frmGestionarProveedores
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBorrarBusqueda = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.comboBuscar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeleccionadoEspecifico = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.estadolbl = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrarIngresoDatos = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblDatos = new System.Windows.Forms.Label();
            this.dataGridViewProveedor = new System.Windows.Forms.DataGridView();
            this.buttonEliminarProducto = new System.Windows.Forms.Button();
            this.buttonActualizarProducto = new System.Windows.Forms.Button();
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.buttonAgregarProductoProveedorSelec = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProveedor)).BeginInit();
            this.SuspendLayout();
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
            this.btnRefresh.Location = new System.Drawing.Point(937, 372);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 32);
            this.btnRefresh.TabIndex = 122;
            this.btnRefresh.Tag = "btnRefresh";
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.panel1.Location = new System.Drawing.Point(780, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 217);
            this.panel1.TabIndex = 121;
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
            this.btnBorrarBusqueda.Location = new System.Drawing.Point(11, 169);
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
            this.btnBuscar.Location = new System.Drawing.Point(138, 169);
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
            this.txtBuscar.Location = new System.Drawing.Point(11, 118);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(246, 21);
            this.txtBuscar.TabIndex = 61;
            // 
            // comboBuscar
            // 
            this.comboBuscar.FormattingEnabled = true;
            this.comboBuscar.Location = new System.Drawing.Point(11, 79);
            this.comboBuscar.Name = "comboBuscar";
            this.comboBuscar.Size = new System.Drawing.Size(246, 23);
            this.comboBuscar.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
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
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 58;
            this.label8.Tag = "lblBuscarEnLaGrilla";
            this.label8.Text = "Buscar en la Grilla";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTelefono);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblSeleccionadoEspecifico);
            this.panel2.Controls.Add(this.txtUbicacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblSeleccionado);
            this.panel2.Controls.Add(this.txtMail);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.estadolbl);
            this.panel2.Controls.Add(this.comboEstado);
            this.panel2.Controls.Add(this.txtDocumento);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnBorrarIngresoDatos);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.lblDatos);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(69, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 217);
            this.panel2.TabIndex = 120;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(427, 79);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(156, 21);
            this.txtTelefono.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(424, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 81;
            this.label4.Tag = "Telefono";
            this.label4.Text = "Teléfono";
            // 
            // lblSeleccionadoEspecifico
            // 
            this.lblSeleccionadoEspecifico.AutoSize = true;
            this.lblSeleccionadoEspecifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionadoEspecifico.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionadoEspecifico.Location = new System.Drawing.Point(424, 140);
            this.lblSeleccionadoEspecifico.Name = "lblSeleccionadoEspecifico";
            this.lblSeleccionadoEspecifico.Size = new System.Drawing.Size(11, 16);
            this.lblSeleccionadoEspecifico.TabIndex = 79;
            this.lblSeleccionadoEspecifico.Text = "-";
            this.lblSeleccionadoEspecifico.Visible = false;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(14, 133);
            this.txtUbicacion.Multiline = true;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(180, 23);
            this.txtUbicacion.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(227, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 84;
            this.label5.Tag = "Estado";
            this.label5.Text = "Estado";
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionado.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionado.Location = new System.Drawing.Point(424, 121);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(167, 15);
            this.lblSeleccionado.TabIndex = 77;
            this.lblSeleccionado.Tag = "ProveedorSeleccionado";
            this.lblSeleccionado.Text = "Proveedor Seleccionado:";
            this.lblSeleccionado.Visible = false;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(223, 77);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(180, 21);
            this.txtMail.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(11, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 80;
            this.label3.Tag = "Ubicacion";
            this.label3.Text = "Ubicacion";
            // 
            // estadolbl
            // 
            this.estadolbl.AutoSize = true;
            this.estadolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadolbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.estadolbl.Location = new System.Drawing.Point(220, 61);
            this.estadolbl.Name = "estadolbl";
            this.estadolbl.Size = new System.Drawing.Size(31, 15);
            this.estadolbl.TabIndex = 76;
            this.estadolbl.Tag = "Email";
            this.estadolbl.Text = "Mail";
            // 
            // comboEstado
            // 
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Items.AddRange(new object[] {
            "Activado",
            "Desactivado"});
            this.comboEstado.Location = new System.Drawing.Point(224, 133);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(179, 23);
            this.comboEstado.TabIndex = 78;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(14, 77);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(180, 21);
            this.txtDocumento.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 75;
            this.label1.Tag = "Documento";
            this.label1.Text = "Documento";
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
            this.btnBorrarIngresoDatos.Location = new System.Drawing.Point(290, 169);
            this.btnBorrarIngresoDatos.Name = "btnBorrarIngresoDatos";
            this.btnBorrarIngresoDatos.Size = new System.Drawing.Size(144, 35);
            this.btnBorrarIngresoDatos.TabIndex = 68;
            this.btnBorrarIngresoDatos.Tag = "btnBorrar";
            this.btnBorrarIngresoDatos.Text = "Borrar";
            this.btnBorrarIngresoDatos.UseVisualStyleBackColor = false;
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
            this.btnAceptar.Location = new System.Drawing.Point(440, 169);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(144, 35);
            this.btnAceptar.TabIndex = 61;
            this.btnAceptar.Tag = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDatos.Location = new System.Drawing.Point(7, 11);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(129, 20);
            this.lblDatos.TabIndex = 58;
            this.lblDatos.Text = "Ingresar Datos";
            // 
            // dataGridViewProveedor
            // 
            this.dataGridViewProveedor.AllowUserToAddRows = false;
            this.dataGridViewProveedor.AllowUserToDeleteRows = false;
            this.dataGridViewProveedor.AllowUserToResizeColumns = false;
            this.dataGridViewProveedor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewProveedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProveedor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProveedor.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProveedor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProveedor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProveedor.EnableHeadersVisualStyles = false;
            this.dataGridViewProveedor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewProveedor.Location = new System.Drawing.Point(69, 69);
            this.dataGridViewProveedor.Name = "dataGridViewProveedor";
            this.dataGridViewProveedor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProveedor.RowHeadersVisible = false;
            this.dataGridViewProveedor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProveedor.Size = new System.Drawing.Size(985, 262);
            this.dataGridViewProveedor.TabIndex = 114;
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
            this.buttonEliminarProducto.Location = new System.Drawing.Point(471, 366);
            this.buttonEliminarProducto.Name = "buttonEliminarProducto";
            this.buttonEliminarProducto.Size = new System.Drawing.Size(164, 38);
            this.buttonEliminarProducto.TabIndex = 119;
            this.buttonEliminarProducto.Text = "Eliminar";
            this.buttonEliminarProducto.UseVisualStyleBackColor = true;
            this.buttonEliminarProducto.Click += new System.EventHandler(this.buttonEliminarProducto_Click);
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
            this.buttonActualizarProducto.Location = new System.Drawing.Point(278, 366);
            this.buttonActualizarProducto.Name = "buttonActualizarProducto";
            this.buttonActualizarProducto.Size = new System.Drawing.Size(164, 38);
            this.buttonActualizarProducto.TabIndex = 118;
            this.buttonActualizarProducto.Text = "Actualizar";
            this.buttonActualizarProducto.UseVisualStyleBackColor = true;
            this.buttonActualizarProducto.Click += new System.EventHandler(this.buttonActualizarProducto_Click);
            // 
            // lblTituloProductos
            // 
            this.lblTituloProductos.AutoSize = true;
            this.lblTituloProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTituloProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTituloProductos.Location = new System.Drawing.Point(18, 16);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Size = new System.Drawing.Size(212, 25);
            this.lblTituloProductos.TabIndex = 116;
            this.lblTituloProductos.Text = "Gestionar Proveedores";
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
            this.btnExportar.Location = new System.Drawing.Point(780, 372);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(133, 32);
            this.btnExportar.TabIndex = 123;
            this.btnExportar.Tag = "btnExportExcel";
            this.btnExportar.Text = "Export Excel";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
            this.buttonAgregarProductoProveedorSelec.Location = new System.Drawing.Point(85, 366);
            this.buttonAgregarProductoProveedorSelec.Name = "buttonAgregarProductoProveedorSelec";
            this.buttonAgregarProductoProveedorSelec.Size = new System.Drawing.Size(164, 38);
            this.buttonAgregarProductoProveedorSelec.TabIndex = 117;
            this.buttonAgregarProductoProveedorSelec.Text = "Agregar";
            this.buttonAgregarProductoProveedorSelec.UseVisualStyleBackColor = true;
            this.buttonAgregarProductoProveedorSelec.Click += new System.EventHandler(this.buttonAgregarProductoProveedorSelec_Click);
            // 
            // frmGestionarProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1101, 671);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewProveedor);
            this.Controls.Add(this.buttonEliminarProducto);
            this.Controls.Add(this.buttonActualizarProducto);
            this.Controls.Add(this.buttonAgregarProductoProveedorSelec);
            this.Controls.Add(this.lblTituloProductos);
            this.Name = "frmGestionarProveedores";
            this.Text = "frmGestionarProveedores";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnExportar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBorrarBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox comboBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBorrarIngresoDatos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblDatos;
        internal System.Windows.Forms.DataGridView dataGridViewProveedor;
        private System.Windows.Forms.Button buttonEliminarProducto;
        private System.Windows.Forms.Button buttonActualizarProducto;
        private System.Windows.Forms.Label lblTituloProductos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeleccionadoEspecifico;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSeleccionado;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label estadolbl;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAgregarProductoProveedorSelec;
    }
}