namespace CheeseLogix
{
    partial class frmGestorBitacora
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.comboBox_Filtro = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_Desde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Hasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.comboBox_Tipos = new System.Windows.Forms.ComboBox();
            this.comboBox_Usuarios = new System.Windows.Forms.ComboBox();
            this.lblTipos = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.groupBox_PorFecha = new System.Windows.Forms.GroupBox();
            this.groupBox_PorTipo = new System.Windows.Forms.GroupBox();
            this.groupBox_PorUsuario = new System.Windows.Forms.GroupBox();
            this.button_Salir = new System.Windows.Forms.Button();
            this.checkCombinado = new System.Windows.Forms.CheckBox();
            this.comboBox_cobinado = new System.Windows.Forms.ComboBox();
            this.lblYpor = new System.Windows.Forms.Label();
            this.groupBox_Combo = new System.Windows.Forms.GroupBox();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_PorFecha.SuspendLayout();
            this.groupBox_PorTipo.SuspendLayout();
            this.groupBox_PorUsuario.SuspendLayout();
            this.groupBox_Combo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(361, 49);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(496, 274);
            this.dataGridView1.TabIndex = 40;
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Filtrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Filtrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_Filtrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Filtrar.Location = new System.Drawing.Point(112, 80);
            this.button_Filtrar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(122, 35);
            this.button_Filtrar.TabIndex = 1;
            this.button_Filtrar.Tag = "Button_Filtrar_GBit";
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = false;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // comboBox_Filtro
            // 
            this.comboBox_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filtro.FormattingEnabled = true;
            this.comboBox_Filtro.Items.AddRange(new object[] {
            "Fecha",
            "Tipo",
            "Usuario"});
            this.comboBox_Filtro.Location = new System.Drawing.Point(2, 34);
            this.comboBox_Filtro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(97, 21);
            this.comboBox_Filtro.TabIndex = 0;
            this.comboBox_Filtro.Tag = "cbox_Filtrar_GBit";
            this.comboBox_Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filtro_SelectedIndexChanged);
            // 
            // dateTimePicker_Desde
            // 
            this.dateTimePicker_Desde.Location = new System.Drawing.Point(13, 34);
            this.dateTimePicker_Desde.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePicker_Desde.Name = "dateTimePicker_Desde";
            this.dateTimePicker_Desde.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker_Desde.TabIndex = 4;
            this.dateTimePicker_Desde.Tag = "dtpicker_Desde_GBit";
            // 
            // dateTimePicker_Hasta
            // 
            this.dateTimePicker_Hasta.Location = new System.Drawing.Point(179, 34);
            this.dateTimePicker_Hasta.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePicker_Hasta.Name = "dateTimePicker_Hasta";
            this.dateTimePicker_Hasta.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker_Hasta.TabIndex = 5;
            this.dateTimePicker_Hasta.Tag = "dtpicker_Hasta_GBit";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDesde.Location = new System.Drawing.Point(17, 17);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(52, 15);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Tag = "Label_Desde_GBit";
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHasta.Location = new System.Drawing.Point(184, 17);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(48, 15);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Tag = "Label_Hasta_GBit";
            this.lblHasta.Text = "Hasta:";
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltrarPor.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFiltrarPor.Location = new System.Drawing.Point(2, 0);
            this.lblFiltrarPor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(70, 15);
            this.lblFiltrarPor.TabIndex = 8;
            this.lblFiltrarPor.Tag = "Lable_Filtrar_GBit";
            this.lblFiltrarPor.Text = "Filtrar por";
            // 
            // comboBox_Tipos
            // 
            this.comboBox_Tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipos.FormattingEnabled = true;
            this.comboBox_Tipos.Items.AddRange(new object[] {
            "Fecha",
            "Tipo",
            "Usuario"});
            this.comboBox_Tipos.Location = new System.Drawing.Point(15, 35);
            this.comboBox_Tipos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Tipos.Name = "comboBox_Tipos";
            this.comboBox_Tipos.Size = new System.Drawing.Size(200, 21);
            this.comboBox_Tipos.TabIndex = 9;
            this.comboBox_Tipos.Tag = "cbox_Tipos_GBit";
            // 
            // comboBox_Usuarios
            // 
            this.comboBox_Usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Usuarios.FormattingEnabled = true;
            this.comboBox_Usuarios.Items.AddRange(new object[] {
            "Fecha",
            "Tipo",
            "Usuario"});
            this.comboBox_Usuarios.Location = new System.Drawing.Point(4, 35);
            this.comboBox_Usuarios.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Usuarios.Name = "comboBox_Usuarios";
            this.comboBox_Usuarios.Size = new System.Drawing.Size(204, 21);
            this.comboBox_Usuarios.TabIndex = 10;
            this.comboBox_Usuarios.Tag = "cbox_Usuarios_GBit";
            // 
            // lblTipos
            // 
            this.lblTipos.AutoSize = true;
            this.lblTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipos.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTipos.Location = new System.Drawing.Point(12, 14);
            this.lblTipos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipos.Name = "lblTipos";
            this.lblTipos.Size = new System.Drawing.Size(42, 15);
            this.lblTipos.TabIndex = 11;
            this.lblTipos.Tag = "Label_Tipos_GBit";
            this.lblTipos.Text = "Tipos";
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblUsuarios.Location = new System.Drawing.Point(4, 14);
            this.lblUsuarios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(64, 15);
            this.lblUsuarios.TabIndex = 12;
            this.lblUsuarios.Tag = "Label_Usuarios_GBit";
            this.lblUsuarios.Text = "Usuarios";
            // 
            // groupBox_PorFecha
            // 
            this.groupBox_PorFecha.Controls.Add(this.dateTimePicker_Hasta);
            this.groupBox_PorFecha.Controls.Add(this.dateTimePicker_Desde);
            this.groupBox_PorFecha.Controls.Add(this.lblDesde);
            this.groupBox_PorFecha.Controls.Add(this.lblHasta);
            this.groupBox_PorFecha.Location = new System.Drawing.Point(2, 1);
            this.groupBox_PorFecha.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorFecha.Name = "groupBox_PorFecha";
            this.groupBox_PorFecha.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorFecha.Size = new System.Drawing.Size(333, 63);
            this.groupBox_PorFecha.TabIndex = 30;
            this.groupBox_PorFecha.TabStop = false;
            this.groupBox_PorFecha.Visible = false;
            // 
            // groupBox_PorTipo
            // 
            this.groupBox_PorTipo.Controls.Add(this.comboBox_Tipos);
            this.groupBox_PorTipo.Controls.Add(this.lblTipos);
            this.groupBox_PorTipo.Location = new System.Drawing.Point(2, 1);
            this.groupBox_PorTipo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorTipo.Name = "groupBox_PorTipo";
            this.groupBox_PorTipo.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorTipo.Size = new System.Drawing.Size(243, 67);
            this.groupBox_PorTipo.TabIndex = 10;
            this.groupBox_PorTipo.TabStop = false;
            this.groupBox_PorTipo.Visible = false;
            // 
            // groupBox_PorUsuario
            // 
            this.groupBox_PorUsuario.Controls.Add(this.comboBox_Usuarios);
            this.groupBox_PorUsuario.Controls.Add(this.lblUsuarios);
            this.groupBox_PorUsuario.Location = new System.Drawing.Point(249, 1);
            this.groupBox_PorUsuario.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorUsuario.Name = "groupBox_PorUsuario";
            this.groupBox_PorUsuario.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_PorUsuario.Size = new System.Drawing.Size(243, 67);
            this.groupBox_PorUsuario.TabIndex = 20;
            this.groupBox_PorUsuario.TabStop = false;
            this.groupBox_PorUsuario.Visible = false;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_Salir.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Salir.Location = new System.Drawing.Point(132, 138);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(122, 29);
            this.button_Salir.TabIndex = 41;
            this.button_Salir.Tag = "Button_Salir_GBit";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // checkCombinado
            // 
            this.checkCombinado.AutoSize = true;
            this.checkCombinado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.checkCombinado.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkCombinado.Location = new System.Drawing.Point(2, 136);
            this.checkCombinado.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.checkCombinado.Name = "checkCombinado";
            this.checkCombinado.Size = new System.Drawing.Size(99, 19);
            this.checkCombinado.TabIndex = 42;
            this.checkCombinado.Tag = "Checkbox_Combinado_GBit";
            this.checkCombinado.Text = "Combinado";
            this.checkCombinado.UseVisualStyleBackColor = true;
            this.checkCombinado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox_cobinado
            // 
            this.comboBox_cobinado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cobinado.FormattingEnabled = true;
            this.comboBox_cobinado.Items.AddRange(new object[] {
            "Tipo",
            "Usuario"});
            this.comboBox_cobinado.Location = new System.Drawing.Point(2, 14);
            this.comboBox_cobinado.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_cobinado.Name = "comboBox_cobinado";
            this.comboBox_cobinado.Size = new System.Drawing.Size(97, 21);
            this.comboBox_cobinado.TabIndex = 43;
            this.comboBox_cobinado.Tag = "cbox_Combinado_GBit";
            this.comboBox_cobinado.SelectedIndexChanged += new System.EventHandler(this.comboBox_cobinado_SelectedIndexChanged);
            // 
            // lblYpor
            // 
            this.lblYpor.AutoSize = true;
            this.lblYpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblYpor.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblYpor.Location = new System.Drawing.Point(4, -3);
            this.lblYpor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYpor.Name = "lblYpor";
            this.lblYpor.Size = new System.Drawing.Size(40, 15);
            this.lblYpor.TabIndex = 44;
            this.lblYpor.Tag = "Label_Combinado_GBit";
            this.lblYpor.Text = "Y por";
            // 
            // groupBox_Combo
            // 
            this.groupBox_Combo.Controls.Add(this.comboBox_cobinado);
            this.groupBox_Combo.Controls.Add(this.lblYpor);
            this.groupBox_Combo.Location = new System.Drawing.Point(2, 34);
            this.groupBox_Combo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_Combo.Name = "groupBox_Combo";
            this.groupBox_Combo.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox_Combo.Size = new System.Drawing.Size(102, 44);
            this.groupBox_Combo.TabIndex = 8;
            this.groupBox_Combo.TabStop = false;
            this.groupBox_Combo.Visible = false;
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(132, 3);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(122, 21);
            this.cboxIdiomas.TabIndex = 43;
            this.cboxIdiomas.Tag = "cbox_Idiomas_GBit";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(2, 0);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(87, 30);
            this.lblSeleccionarIdioma.TabIndex = 44;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_GBit";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 29);
            this.label8.TabIndex = 45;
            this.label8.Tag = "Label_GestorBitacora_GBit";
            this.label8.Text = "Gestor Bitácora";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.95739F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.49378F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.62345F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.024692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.67901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.2963F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1126, 605);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Salir, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(862, 327);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(261, 275);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 327);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(353, 275);
            this.tableLayoutPanel3.TabIndex = 47;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkCombinado, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(353, 270);
            this.tableLayoutPanel4.TabIndex = 48;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblFiltrarPor, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBox_Filtro, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.4186F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(170, 129);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox_PorTipo, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox_PorUsuario, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(362, 327);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(494, 275);
            this.tableLayoutPanel6.TabIndex = 48;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.button_Filtrar, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.groupBox_PorFecha, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(347, 131);
            this.tableLayoutPanel7.TabIndex = 31;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.groupBox_Combo, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(179, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.4186F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(171, 129);
            this.tableLayoutPanel8.TabIndex = 49;
            // 
            // frmGestorBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1127, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "frmGestorBitacora";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_PorFecha.ResumeLayout(false);
            this.groupBox_PorFecha.PerformLayout();
            this.groupBox_PorTipo.ResumeLayout(false);
            this.groupBox_PorTipo.PerformLayout();
            this.groupBox_PorUsuario.ResumeLayout(false);
            this.groupBox_PorUsuario.PerformLayout();
            this.groupBox_Combo.ResumeLayout(false);
            this.groupBox_Combo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.ComboBox comboBox_Filtro;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Desde;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Hasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.ComboBox comboBox_Tipos;
        private System.Windows.Forms.ComboBox comboBox_Usuarios;
        private System.Windows.Forms.Label lblTipos;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.GroupBox groupBox_PorFecha;
        private System.Windows.Forms.GroupBox groupBox_PorTipo;
        private System.Windows.Forms.GroupBox groupBox_PorUsuario;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.CheckBox checkCombinado;
        private System.Windows.Forms.ComboBox comboBox_cobinado;
        private System.Windows.Forms.Label lblYpor;
        private System.Windows.Forms.GroupBox groupBox_Combo;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}