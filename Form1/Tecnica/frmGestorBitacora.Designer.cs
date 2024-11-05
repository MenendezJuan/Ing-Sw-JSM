namespace Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_PorFecha.SuspendLayout();
            this.groupBox_PorTipo.SuspendLayout();
            this.groupBox_PorUsuario.SuspendLayout();
            this.groupBox_Combo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(231, 239);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(658, 281);
            this.dataGridView1.TabIndex = 40;
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(55, 219);
            this.button_Filtrar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(100, 32);
            this.button_Filtrar.TabIndex = 1;
            this.button_Filtrar.Tag = "Button_Filtrar_GBit";
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
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
            this.comboBox_Filtro.Location = new System.Drawing.Point(15, 131);
            this.comboBox_Filtro.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(144, 28);
            this.comboBox_Filtro.TabIndex = 0;
            this.comboBox_Filtro.Tag = "cbox_Filtrar_GBit";
            this.comboBox_Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filtro_SelectedIndexChanged);
            // 
            // dateTimePicker_Desde
            // 
            this.dateTimePicker_Desde.Location = new System.Drawing.Point(19, 52);
            this.dateTimePicker_Desde.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dateTimePicker_Desde.Name = "dateTimePicker_Desde";
            this.dateTimePicker_Desde.Size = new System.Drawing.Size(201, 26);
            this.dateTimePicker_Desde.TabIndex = 4;
            this.dateTimePicker_Desde.Tag = "dtpicker_Desde_GBit";
            // 
            // dateTimePicker_Hasta
            // 
            this.dateTimePicker_Hasta.Location = new System.Drawing.Point(269, 52);
            this.dateTimePicker_Hasta.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dateTimePicker_Hasta.Name = "dateTimePicker_Hasta";
            this.dateTimePicker_Hasta.Size = new System.Drawing.Size(201, 26);
            this.dateTimePicker_Hasta.TabIndex = 5;
            this.dateTimePicker_Hasta.Tag = "dtpicker_Hasta_GBit";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(26, 26);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(60, 20);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Tag = "Label_Desde_GBit";
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(276, 26);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(56, 20);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Tag = "Label_Hasta_GBit";
            this.lblHasta.Text = "Hasta:";
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Location = new System.Drawing.Point(10, 111);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(76, 20);
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
            this.comboBox_Tipos.Location = new System.Drawing.Point(22, 54);
            this.comboBox_Tipos.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBox_Tipos.Name = "comboBox_Tipos";
            this.comboBox_Tipos.Size = new System.Drawing.Size(120, 28);
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
            this.comboBox_Usuarios.Location = new System.Drawing.Point(0, 51);
            this.comboBox_Usuarios.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBox_Usuarios.Name = "comboBox_Usuarios";
            this.comboBox_Usuarios.Size = new System.Drawing.Size(194, 28);
            this.comboBox_Usuarios.TabIndex = 10;
            this.comboBox_Usuarios.Tag = "cbox_Usuarios_GBit";
            // 
            // lblTipos
            // 
            this.lblTipos.AutoSize = true;
            this.lblTipos.Location = new System.Drawing.Point(18, 21);
            this.lblTipos.Name = "lblTipos";
            this.lblTipos.Size = new System.Drawing.Size(47, 20);
            this.lblTipos.TabIndex = 11;
            this.lblTipos.Tag = "Label_Tipos_GBit";
            this.lblTipos.Text = "Tipos";
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(26, 29);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(72, 20);
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
            this.groupBox_PorFecha.Location = new System.Drawing.Point(324, 131);
            this.groupBox_PorFecha.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorFecha.Name = "groupBox_PorFecha";
            this.groupBox_PorFecha.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorFecha.Size = new System.Drawing.Size(500, 100);
            this.groupBox_PorFecha.TabIndex = 30;
            this.groupBox_PorFecha.TabStop = false;
            this.groupBox_PorFecha.Visible = false;
            // 
            // groupBox_PorTipo
            // 
            this.groupBox_PorTipo.Controls.Add(this.comboBox_Tipos);
            this.groupBox_PorTipo.Controls.Add(this.lblTipos);
            this.groupBox_PorTipo.Location = new System.Drawing.Point(10, 255);
            this.groupBox_PorTipo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorTipo.Name = "groupBox_PorTipo";
            this.groupBox_PorTipo.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorTipo.Size = new System.Drawing.Size(199, 100);
            this.groupBox_PorTipo.TabIndex = 10;
            this.groupBox_PorTipo.TabStop = false;
            this.groupBox_PorTipo.Visible = false;
            // 
            // groupBox_PorUsuario
            // 
            this.groupBox_PorUsuario.Controls.Add(this.comboBox_Usuarios);
            this.groupBox_PorUsuario.Controls.Add(this.lblUsuarios);
            this.groupBox_PorUsuario.Location = new System.Drawing.Point(10, 360);
            this.groupBox_PorUsuario.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorUsuario.Name = "groupBox_PorUsuario";
            this.groupBox_PorUsuario.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_PorUsuario.Size = new System.Drawing.Size(199, 100);
            this.groupBox_PorUsuario.TabIndex = 20;
            this.groupBox_PorUsuario.TabStop = false;
            this.groupBox_PorUsuario.Visible = false;
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(37, 481);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(144, 39);
            this.button_Salir.TabIndex = 41;
            this.button_Salir.Tag = "Button_Salir_GBit";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // checkCombinado
            // 
            this.checkCombinado.AutoSize = true;
            this.checkCombinado.Location = new System.Drawing.Point(17, 165);
            this.checkCombinado.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.checkCombinado.Name = "checkCombinado";
            this.checkCombinado.Size = new System.Drawing.Size(116, 24);
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
            this.comboBox_cobinado.Location = new System.Drawing.Point(3, 21);
            this.comboBox_cobinado.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.comboBox_cobinado.Name = "comboBox_cobinado";
            this.comboBox_cobinado.Size = new System.Drawing.Size(144, 28);
            this.comboBox_cobinado.TabIndex = 43;
            this.comboBox_cobinado.Tag = "cbox_Combinado_GBit";
            this.comboBox_cobinado.SelectedIndexChanged += new System.EventHandler(this.comboBox_cobinado_SelectedIndexChanged);
            // 
            // lblYpor
            // 
            this.lblYpor.AutoSize = true;
            this.lblYpor.Location = new System.Drawing.Point(17, 0);
            this.lblYpor.Name = "lblYpor";
            this.lblYpor.Size = new System.Drawing.Size(47, 20);
            this.lblYpor.TabIndex = 44;
            this.lblYpor.Tag = "Label_Combinado_GBit";
            this.lblYpor.Text = "Y por";
            // 
            // groupBox_Combo
            // 
            this.groupBox_Combo.Controls.Add(this.comboBox_cobinado);
            this.groupBox_Combo.Controls.Add(this.lblYpor);
            this.groupBox_Combo.Location = new System.Drawing.Point(174, 111);
            this.groupBox_Combo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_Combo.Name = "groupBox_Combo";
            this.groupBox_Combo.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox_Combo.Size = new System.Drawing.Size(153, 68);
            this.groupBox_Combo.TabIndex = 8;
            this.groupBox_Combo.TabStop = false;
            this.groupBox_Combo.Visible = false;
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(748, 541);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(136, 28);
            this.cboxIdiomas.TabIndex = 43;
            this.cboxIdiomas.Tag = "cbox_Idiomas_GBit";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(574, 544);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(146, 20);
            this.lblSeleccionarIdioma.TabIndex = 44;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_GBit";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 40);
            this.label8.TabIndex = 45;
            this.label8.Tag = "Label_GestorBitacora_GBit";
            this.label8.Text = "Gestor Bitácora";
            // 
            // GestorBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(901, 601);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSeleccionarIdioma);
            this.Controls.Add(this.cboxIdiomas);
            this.Controls.Add(this.groupBox_Combo);
            this.Controls.Add(this.checkCombinado);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.groupBox_PorUsuario);
            this.Controls.Add(this.groupBox_PorTipo);
            this.Controls.Add(this.groupBox_PorFecha);
            this.Controls.Add(this.lblFiltrarPor);
            this.Controls.Add(this.comboBox_Filtro);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.MaximizeBox = false;
            this.Name = "GestorBitacora";
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}