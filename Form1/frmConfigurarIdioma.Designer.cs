namespace Form1
{
    partial class frmConfigurarIdioma
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
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.tboxPalabra = new System.Windows.Forms.TextBox();
            this.tboxTraduccion = new System.Windows.Forms.TextBox();
            this.lblPalabra = new System.Windows.Forms.Label();
            this.lblTraduccion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Salir = new System.Windows.Forms.Button();
            this.dgvPalabras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.AllowUserToAddRows = false;
            this.dgvTraducciones.AllowUserToDeleteRows = false;
            this.dgvTraducciones.AllowUserToResizeColumns = false;
            this.dgvTraducciones.AllowUserToResizeRows = false;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTraducciones.Location = new System.Drawing.Point(228, 97);
            this.dgvTraducciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.ReadOnly = true;
            this.dgvTraducciones.RowHeadersWidth = 51;
            this.dgvTraducciones.RowTemplate.Height = 24;
            this.dgvTraducciones.Size = new System.Drawing.Size(376, 314);
            this.dgvTraducciones.TabIndex = 0;
            this.dgvTraducciones.Tag = "Datagrid_Traducciones_ConIdi";
            this.dgvTraducciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraducciones_CellClick);
            // 
            // tboxPalabra
            // 
            this.tboxPalabra.Location = new System.Drawing.Point(31, 129);
            this.tboxPalabra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxPalabra.Name = "tboxPalabra";
            this.tboxPalabra.Size = new System.Drawing.Size(163, 22);
            this.tboxPalabra.TabIndex = 1;
            this.tboxPalabra.Tag = "Textbox_Palabra_CIdi";
            // 
            // tboxTraduccion
            // 
            this.tboxTraduccion.Location = new System.Drawing.Point(31, 223);
            this.tboxTraduccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxTraduccion.Name = "tboxTraduccion";
            this.tboxTraduccion.Size = new System.Drawing.Size(163, 22);
            this.tboxTraduccion.TabIndex = 2;
            this.tboxTraduccion.Tag = "Textbox_Traduccion_CIdi";
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.Location = new System.Drawing.Point(27, 97);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(58, 16);
            this.lblPalabra.TabIndex = 3;
            this.lblPalabra.Tag = "Label_Palabra_CIdi";
            this.lblPalabra.Text = "Palabra:";
            // 
            // lblTraduccion
            // 
            this.lblTraduccion.AutoSize = true;
            this.lblTraduccion.Location = new System.Drawing.Point(27, 191);
            this.lblTraduccion.Name = "lblTraduccion";
            this.lblTraduccion.Size = new System.Drawing.Size(78, 16);
            this.lblTraduccion.TabIndex = 4;
            this.lblTraduccion.Tag = "Label_Traduccion_CIdi";
            this.lblTraduccion.Text = "Traducción:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(64, 279);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 33);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Tag = "Button_Agregar_CIdi";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(64, 377);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 33);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Tag = "Button_Eliminar_CIdi";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(64, 329);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(88, 33);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Tag = "Button_Modificar_CIdi";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(752, 430);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(126, 16);
            this.lblSeleccionarIdioma.TabIndex = 50;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_CIdi";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(911, 427);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(121, 24);
            this.cboxIdiomas.TabIndex = 49;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_CIdi";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(353, 36);
            this.label8.TabIndex = 51;
            this.label8.Tag = "Label_ConfiguracionIdiomas_CIdi";
            this.label8.Text = "Configuración de Idiomas";
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(64, 422);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(88, 33);
            this.button_Salir.TabIndex = 52;
            this.button_Salir.Tag = "Button_Salir_CIdi";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.AllowUserToAddRows = false;
            this.dgvPalabras.AllowUserToDeleteRows = false;
            this.dgvPalabras.AllowUserToResizeColumns = false;
            this.dgvPalabras.AllowUserToResizeRows = false;
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPalabras.Location = new System.Drawing.Point(645, 97);
            this.dgvPalabras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.ReadOnly = true;
            this.dgvPalabras.RowHeadersWidth = 51;
            this.dgvPalabras.RowTemplate.Height = 24;
            this.dgvPalabras.Size = new System.Drawing.Size(387, 314);
            this.dgvPalabras.TabIndex = 53;
            this.dgvPalabras.Tag = "Datagrid_Traducciones_ConIdi";
            this.dgvPalabras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPalabras_CellClick);
            // 
            // ConfigurarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1060, 479);
            this.Controls.Add(this.dgvPalabras);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSeleccionarIdioma);
            this.Controls.Add(this.cboxIdiomas);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTraduccion);
            this.Controls.Add(this.lblPalabra);
            this.Controls.Add(this.tboxTraduccion);
            this.Controls.Add(this.tboxPalabra);
            this.Controls.Add(this.dgvTraducciones);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ConfigurarIdioma";
            this.ShowIcon = false;
            this.Text = "Form_ConfiguracionIdiomas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurarIdioma_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.TextBox tboxPalabra;
        private System.Windows.Forms.TextBox tboxTraduccion;
        private System.Windows.Forms.Label lblPalabra;
        private System.Windows.Forms.Label lblTraduccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.DataGridView dgvPalabras;
    }
}