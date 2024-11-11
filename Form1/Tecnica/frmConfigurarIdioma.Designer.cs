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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dgvTraducciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTraducciones.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTraducciones.Location = new System.Drawing.Point(171, 79);
            this.dgvTraducciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvTraducciones.MultiSelect = false;
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.ReadOnly = true;
            this.dgvTraducciones.RowHeadersWidth = 51;
            this.dgvTraducciones.RowTemplate.Height = 24;
            this.dgvTraducciones.Size = new System.Drawing.Size(282, 255);
            this.dgvTraducciones.TabIndex = 0;
            this.dgvTraducciones.Tag = "Datagrid_Traducciones_ConIdi";
            this.dgvTraducciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraducciones_CellClick);
            // 
            // tboxPalabra
            // 
            this.tboxPalabra.Location = new System.Drawing.Point(23, 105);
            this.tboxPalabra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tboxPalabra.Name = "tboxPalabra";
            this.tboxPalabra.Size = new System.Drawing.Size(123, 20);
            this.tboxPalabra.TabIndex = 1;
            this.tboxPalabra.Tag = "Textbox_Palabra_CIdi";
            // 
            // tboxTraduccion
            // 
            this.tboxTraduccion.Location = new System.Drawing.Point(23, 181);
            this.tboxTraduccion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tboxTraduccion.Name = "tboxTraduccion";
            this.tboxTraduccion.Size = new System.Drawing.Size(123, 20);
            this.tboxTraduccion.TabIndex = 2;
            this.tboxTraduccion.Tag = "Textbox_Traduccion_CIdi";
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPalabra.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPalabra.Location = new System.Drawing.Point(20, 79);
            this.lblPalabra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(61, 15);
            this.lblPalabra.TabIndex = 3;
            this.lblPalabra.Tag = "Label_Palabra_CIdi";
            this.lblPalabra.Text = "Palabra:";
            // 
            // lblTraduccion
            // 
            this.lblTraduccion.AutoSize = true;
            this.lblTraduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTraduccion.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTraduccion.Location = new System.Drawing.Point(20, 155);
            this.lblTraduccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTraduccion.Name = "lblTraduccion";
            this.lblTraduccion.Size = new System.Drawing.Size(82, 15);
            this.lblTraduccion.TabIndex = 4;
            this.lblTraduccion.Tag = "Label_Traduccion_CIdi";
            this.lblTraduccion.Text = "Traducción:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAgregar.Location = new System.Drawing.Point(23, 229);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 27);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Tag = "Button_Agregar_CIdi";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.Location = new System.Drawing.Point(23, 308);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 27);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Tag = "Button_Eliminar_CIdi";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnModificar.Location = new System.Drawing.Point(23, 269);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 27);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Tag = "Button_Modificar_CIdi";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(544, 347);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(135, 15);
            this.lblSeleccionarIdioma.TabIndex = 50;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_CIdi";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(683, 347);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(92, 21);
            this.cboxIdiomas.TabIndex = 49;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_CIdi";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(287, 29);
            this.label8.TabIndex = 51;
            this.label8.Tag = "Label_ConfiguracionIdiomas_CIdi";
            this.label8.Text = "Configuración de Idiomas";
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_Salir.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Salir.Location = new System.Drawing.Point(23, 345);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(98, 27);
            this.button_Salir.TabIndex = 52;
            this.button_Salir.Tag = "Button_Salir_CIdi";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.AllowUserToAddRows = false;
            this.dgvPalabras.AllowUserToDeleteRows = false;
            this.dgvPalabras.AllowUserToResizeColumns = false;
            this.dgvPalabras.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dgvPalabras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPalabras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPalabras.Location = new System.Drawing.Point(484, 79);
            this.dgvPalabras.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvPalabras.MultiSelect = false;
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.ReadOnly = true;
            this.dgvPalabras.RowHeadersWidth = 51;
            this.dgvPalabras.RowTemplate.Height = 24;
            this.dgvPalabras.Size = new System.Drawing.Size(290, 255);
            this.dgvPalabras.TabIndex = 53;
            this.dgvPalabras.Tag = "Datagrid_Traducciones_ConIdi";
            this.dgvPalabras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPalabras_CellClick);
            // 
            // frmConfigurarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(795, 389);
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
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "frmConfigurarIdioma";
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