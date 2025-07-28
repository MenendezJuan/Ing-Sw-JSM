namespace CheeseLogix.Tecnica
{
    partial class frmBackupRestore
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGestorBackupRestore = new System.Windows.Forms.Label();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCrearBackup = new System.Windows.Forms.Label();
            this.labelNombreBackup = new System.Windows.Forms.Label();
            this.txtNombreBackup = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRestaurarBackup = new System.Windows.Forms.Label();
            this.labelBackupDisp = new System.Windows.Forms.Label();
            this.cmbBackupDisponibles = new System.Windows.Forms.ComboBox();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.23413F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.76587F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGestorBackupRestore, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.76529F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.23471F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 507);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // lblGestorBackupRestore
            // 
            this.lblGestorBackupRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGestorBackupRestore.AutoSize = true;
            this.lblGestorBackupRestore.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestorBackupRestore.ForeColor = System.Drawing.SystemColors.Window;
            this.lblGestorBackupRestore.Location = new System.Drawing.Point(123, 24);
            this.lblGestorBackupRestore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGestorBackupRestore.Name = "lblGestorBackupRestore";
            this.lblGestorBackupRestore.Size = new System.Drawing.Size(340, 37);
            this.lblGestorBackupRestore.TabIndex = 48;
            this.lblGestorBackupRestore.Tag = "Label_GestorBackupRestore_GUs";
            this.lblGestorBackupRestore.Text = "Gestor Backup / Restore";
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_Agregar.ForeColor = System.Drawing.SystemColors.Window;
            this.button_Agregar.Location = new System.Drawing.Point(458, 76);
            this.button_Agregar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(91, 49);
            this.button_Agregar.TabIndex = 0;
            this.button_Agregar.Tag = "Button_Agregar_GUs";
            this.button_Agregar.Text = "Crear";
            this.button_Agregar.UseVisualStyleBackColor = false;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblSeleccionarIdioma, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cboxIdiomas, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(590, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(415, 79);
            this.tableLayoutPanel5.TabIndex = 52;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(27, 48);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(152, 21);
            this.lblSeleccionarIdioma.TabIndex = 46;
            this.lblSeleccionarIdioma.Tag = "Label_Seleccionar_GUs";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(209, 48);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(196, 21);
            this.cboxIdiomas.TabIndex = 45;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_GUs";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSalir.Location = new System.Drawing.Point(272, 287);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 49);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Tag = "Button_Salir_GUs";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 88);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(581, 416);
            this.tableLayoutPanel2.TabIndex = 54;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.5463F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.4537F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel3.Controls.Add(this.button_Agregar, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNombreBackup, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(575, 202);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.5463F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.4537F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel6.Controls.Add(this.btnRestaurar, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cmbBackupDisponibles, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 211);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(575, 202);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.labelCrearBackup, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelNombreBackup, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.83673F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.16327F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(221, 196);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // labelCrearBackup
            // 
            this.labelCrearBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrearBackup.AutoSize = true;
            this.labelCrearBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrearBackup.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCrearBackup.Location = new System.Drawing.Point(57, 6);
            this.labelCrearBackup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCrearBackup.Name = "labelCrearBackup";
            this.labelCrearBackup.Size = new System.Drawing.Size(106, 21);
            this.labelCrearBackup.TabIndex = 47;
            this.labelCrearBackup.Tag = "labelCrearBackup_GUs";
            this.labelCrearBackup.Text = "Crear Backup";
            // 
            // labelNombreBackup
            // 
            this.labelNombreBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNombreBackup.AutoSize = true;
            this.labelNombreBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreBackup.ForeColor = System.Drawing.SystemColors.Window;
            this.labelNombreBackup.Location = new System.Drawing.Point(46, 104);
            this.labelNombreBackup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombreBackup.Name = "labelNombreBackup";
            this.labelNombreBackup.Size = new System.Drawing.Size(128, 21);
            this.labelNombreBackup.TabIndex = 48;
            this.labelNombreBackup.Tag = "labelNombreBackup_GUs";
            this.labelNombreBackup.Text = "Nombre Backup";
            // 
            // txtNombreBackup
            // 
            this.txtNombreBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreBackup.Location = new System.Drawing.Point(255, 91);
            this.txtNombreBackup.Name = "txtNombreBackup";
            this.txtNombreBackup.Size = new System.Drawing.Size(149, 20);
            this.txtNombreBackup.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.labelRestaurarBackup, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelBackupDisp, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.83673F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.16327F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(221, 196);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // labelRestaurarBackup
            // 
            this.labelRestaurarBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRestaurarBackup.AutoSize = true;
            this.labelRestaurarBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestaurarBackup.ForeColor = System.Drawing.SystemColors.Window;
            this.labelRestaurarBackup.Location = new System.Drawing.Point(42, 6);
            this.labelRestaurarBackup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRestaurarBackup.Name = "labelRestaurarBackup";
            this.labelRestaurarBackup.Size = new System.Drawing.Size(136, 21);
            this.labelRestaurarBackup.TabIndex = 47;
            this.labelRestaurarBackup.Tag = "labelRestaurarBackup_GUs";
            this.labelRestaurarBackup.Text = "Restaurar Backup";
            // 
            // labelBackupDisp
            // 
            this.labelBackupDisp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBackupDisp.AutoSize = true;
            this.labelBackupDisp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackupDisp.ForeColor = System.Drawing.SystemColors.Window;
            this.labelBackupDisp.Location = new System.Drawing.Point(34, 104);
            this.labelBackupDisp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBackupDisp.Name = "labelBackupDisp";
            this.labelBackupDisp.Size = new System.Drawing.Size(152, 21);
            this.labelBackupDisp.TabIndex = 48;
            this.labelBackupDisp.Tag = "labelBackupDisp_GUs";
            this.labelBackupDisp.Text = "Backup Disponibles";
            // 
            // cmbBackupDisponibles
            // 
            this.cmbBackupDisponibles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbBackupDisponibles.FormattingEnabled = true;
            this.cmbBackupDisponibles.Location = new System.Drawing.Point(254, 90);
            this.cmbBackupDisponibles.Name = "cmbBackupDisponibles";
            this.cmbBackupDisponibles.Size = new System.Drawing.Size(151, 21);
            this.cmbBackupDisponibles.TabIndex = 2;
            this.cmbBackupDisponibles.SelectedIndexChanged += new System.EventHandler(this.cmbBackupDisponibles_SelectedIndexChanged);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRestaurar.Location = new System.Drawing.Point(460, 76);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(87, 49);
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.Tag = "btnRestaurar_GUs";
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(590, 88);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(415, 416);
            this.tableLayoutPanel4.TabIndex = 55;
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBackupRestore";
            this.Text = "frmBackupRestore";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblGestorBackupRestore;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label labelRestaurarBackup;
        private System.Windows.Forms.Label labelBackupDisp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label labelCrearBackup;
        private System.Windows.Forms.Label labelNombreBackup;
        private System.Windows.Forms.TextBox txtNombreBackup;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.ComboBox cmbBackupDisponibles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}