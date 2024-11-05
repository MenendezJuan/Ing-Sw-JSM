namespace Form1
{
    partial class frmGestorIdiomas
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
            this.dgvIdiomas = new System.Windows.Forms.DataGridView();
            this.tboxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIdiomas
            // 
            this.dgvIdiomas.AllowUserToAddRows = false;
            this.dgvIdiomas.AllowUserToDeleteRows = false;
            this.dgvIdiomas.AllowUserToResizeColumns = false;
            this.dgvIdiomas.AllowUserToResizeRows = false;
            this.dgvIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdiomas.Location = new System.Drawing.Point(260, 114);
            this.dgvIdiomas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvIdiomas.Name = "dgvIdiomas";
            this.dgvIdiomas.ReadOnly = true;
            this.dgvIdiomas.RowHeadersWidth = 51;
            this.dgvIdiomas.RowTemplate.Height = 24;
            this.dgvIdiomas.Size = new System.Drawing.Size(566, 349);
            this.dgvIdiomas.TabIndex = 0;
            this.dgvIdiomas.Tag = "Datagrid_Idiomas_GIdi";
            this.dgvIdiomas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIdiomas_CellClick_1);
            // 
            // tboxNombre
            // 
            this.tboxNombre.Location = new System.Drawing.Point(40, 146);
            this.tboxNombre.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tboxNombre.Name = "tboxNombre";
            this.tboxNombre.Size = new System.Drawing.Size(167, 26);
            this.tboxNombre.TabIndex = 1;
            this.tboxNombre.Tag = "Textbox_Nombre_GIdi";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(40, 114);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Tag = "Label_Nombre_GIdi";
            this.lblNombre.Text = "Nombre:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(68, 209);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 49);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Tag = "Button_Agregar_GIdi";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(68, 279);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(107, 49);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Tag = "Button_Modificar_GIdi";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(68, 348);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 49);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Tag = "Button_Eliminar_GIdi";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 40);
            this.label8.TabIndex = 46;
            this.label8.Tag = "Label_GestorIdiomas_GIdi";
            this.label8.Text = "Gestor Idiomas";
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(512, 492);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(146, 20);
            this.lblSeleccionarIdioma.TabIndex = 48;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_GIdi";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(687, 492);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(136, 28);
            this.cboxIdiomas.TabIndex = 47;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_GIdi";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Location = new System.Drawing.Point(68, 415);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(107, 49);
            this.btnConfigurar.TabIndex = 49;
            this.btnConfigurar.Tag = "Button_Configurar_GIdi";
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(68, 481);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(107, 48);
            this.button_Salir.TabIndex = 53;
            this.button_Salir.Tag = "Button_Salir_GIdi";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // GestorIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(854, 552);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.btnConfigurar);
            this.Controls.Add(this.lblSeleccionarIdioma);
            this.Controls.Add(this.cboxIdiomas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tboxNombre);
            this.Controls.Add(this.dgvIdiomas);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "GestorIdiomas";
            this.ShowIcon = false;
            this.Tag = "From_GestorIdiomas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GestorIdiomas_FormClosing_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdiomas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIdiomas;
        private System.Windows.Forms.TextBox tboxNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Button button_Salir;
    }
}