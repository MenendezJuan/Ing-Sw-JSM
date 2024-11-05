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
            this.dgvIdiomas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdiomas.Location = new System.Drawing.Point(173, 74);
            this.dgvIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvIdiomas.Name = "dgvIdiomas";
            this.dgvIdiomas.ReadOnly = true;
            this.dgvIdiomas.RowHeadersWidth = 51;
            this.dgvIdiomas.RowTemplate.Height = 24;
            this.dgvIdiomas.Size = new System.Drawing.Size(377, 227);
            this.dgvIdiomas.TabIndex = 0;
            this.dgvIdiomas.Tag = "Datagrid_Idiomas_GIdi";
            this.dgvIdiomas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIdiomas_CellClick_1);
            // 
            // tboxNombre
            // 
            this.tboxNombre.Location = new System.Drawing.Point(27, 95);
            this.tboxNombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tboxNombre.Name = "tboxNombre";
            this.tboxNombre.Size = new System.Drawing.Size(113, 20);
            this.tboxNombre.TabIndex = 1;
            this.tboxNombre.Tag = "Textbox_Nombre_GIdi";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNombre.Location = new System.Drawing.Point(27, 74);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Tag = "Label_Nombre_GIdi";
            this.lblNombre.Text = "Nombre:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAgregar.Location = new System.Drawing.Point(27, 136);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 32);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Tag = "Button_Agregar_GIdi";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnModificar.Location = new System.Drawing.Point(27, 181);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(113, 32);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Tag = "Button_Modificar_GIdi";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.Location = new System.Drawing.Point(27, 226);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(113, 32);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Tag = "Button_Eliminar_GIdi";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(18, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 29);
            this.label8.TabIndex = 46;
            this.label8.Tag = "Label_GestorIdiomas_GIdi";
            this.label8.Text = "Gestor Idiomas";
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(319, 321);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(135, 15);
            this.lblSeleccionarIdioma.TabIndex = 48;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_GIdi";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(458, 320);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(92, 21);
            this.cboxIdiomas.TabIndex = 47;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_GIdi";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnConfigurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfigurar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfigurar.Location = new System.Drawing.Point(27, 270);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(113, 32);
            this.btnConfigurar.TabIndex = 49;
            this.btnConfigurar.Tag = "Button_Configurar_GIdi";
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = false;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_Salir.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Salir.Location = new System.Drawing.Point(27, 313);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(113, 31);
            this.button_Salir.TabIndex = 53;
            this.button_Salir.Tag = "Button_Salir_GIdi";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // frmGestorIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(569, 359);
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
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "frmGestorIdiomas";
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