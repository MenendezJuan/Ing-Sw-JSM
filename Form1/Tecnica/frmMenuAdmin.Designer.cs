namespace CheeseLogix
{
    partial class frmMenuAdmin
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
            this.button_Usuarios = new System.Windows.Forms.Button();
            this.button_Bitacora = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.button_Permisos = new System.Windows.Forms.Button();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.btnIdioma = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_MenuAdmin = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Usuarios
            // 
            this.button_Usuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Usuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Usuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Usuarios.Location = new System.Drawing.Point(19, 48);
            this.button_Usuarios.Margin = new System.Windows.Forms.Padding(2);
            this.button_Usuarios.Name = "button_Usuarios";
            this.button_Usuarios.Size = new System.Drawing.Size(94, 83);
            this.button_Usuarios.TabIndex = 1;
            this.button_Usuarios.Tag = "Button_GestionUsuarios_FormIni";
            this.button_Usuarios.Text = "Gestion de Usuarios";
            this.button_Usuarios.UseVisualStyleBackColor = false;
            this.button_Usuarios.Visible = false;
            this.button_Usuarios.Click += new System.EventHandler(this.button_Usuarios_Click);
            // 
            // button_Bitacora
            // 
            this.button_Bitacora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Bitacora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Bitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Bitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Bitacora.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Bitacora.Location = new System.Drawing.Point(286, 48);
            this.button_Bitacora.Margin = new System.Windows.Forms.Padding(2);
            this.button_Bitacora.Name = "button_Bitacora";
            this.button_Bitacora.Size = new System.Drawing.Size(88, 82);
            this.button_Bitacora.TabIndex = 2;
            this.button_Bitacora.Tag = "Button_GestionBitacora_FormIni";
            this.button_Bitacora.Text = "Gestion de bitacora";
            this.button_Bitacora.UseVisualStyleBackColor = false;
            this.button_Bitacora.Visible = false;
            this.button_Bitacora.Click += new System.EventHandler(this.button_Bitacora_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Salir.Location = new System.Drawing.Point(471, 439);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(2);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(126, 30);
            this.button_Salir.TabIndex = 3;
            this.button_Salir.Tag = "Button_Salir_FormIni";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click_1);
            // 
            // button_Permisos
            // 
            this.button_Permisos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Permisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Permisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Permisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Permisos.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Permisos.Location = new System.Drawing.Point(154, 48);
            this.button_Permisos.Margin = new System.Windows.Forms.Padding(2);
            this.button_Permisos.Name = "button_Permisos";
            this.button_Permisos.Size = new System.Drawing.Size(88, 83);
            this.button_Permisos.TabIndex = 5;
            this.button_Permisos.Tag = "Button_GestionPermisos_FormIni";
            this.button_Permisos.Text = "Gestion de Permiso";
            this.button_Permisos.UseVisualStyleBackColor = false;
            this.button_Permisos.Visible = false;
            this.button_Permisos.Click += new System.EventHandler(this.button_Permisos_Click);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(18, 71);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(94, 32);
            this.lblSeleccionarIdioma.TabIndex = 46;
            this.lblSeleccionarIdioma.Tag = "Label_Idioma_FormIni";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(141, 73);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(112, 28);
            this.cboxIdiomas.TabIndex = 45;
            this.cboxIdiomas.Tag = "Combobox_Idioma_FormIni";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // btnIdioma
            // 
            this.btnIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnIdioma.Location = new System.Drawing.Point(415, 48);
            this.btnIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.btnIdioma.Name = "btnIdioma";
            this.btnIdioma.Size = new System.Drawing.Size(94, 82);
            this.btnIdioma.TabIndex = 47;
            this.btnIdioma.Tag = "Button_GestionIdiomas_FormIni";
            this.btnIdioma.Text = "Gestion de idioma";
            this.btnIdioma.UseVisualStyleBackColor = false;
            this.btnIdioma.Visible = false;
            this.btnIdioma.Click += new System.EventHandler(this.btnIdioma_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Salir, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_MenuAdmin, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1071, 545);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.button_Usuarios, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnIdioma, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Permisos, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Bitacora, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(270, 182);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(529, 179);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(805, 367);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(263, 175);
            this.tableLayoutPanel3.TabIndex = 49;
            // 
            // label_MenuAdmin
            // 
            this.label_MenuAdmin.AutoSize = true;
            this.label_MenuAdmin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MenuAdmin.ForeColor = System.Drawing.Color.Gainsboro;
            this.label_MenuAdmin.Location = new System.Drawing.Point(3, 0);
            this.label_MenuAdmin.Name = "label_MenuAdmin";
            this.label_MenuAdmin.Size = new System.Drawing.Size(128, 25);
            this.label_MenuAdmin.TabIndex = 50;
            this.label_MenuAdmin.Tag = "label_MenuAdmin_frmPrin";
            this.label_MenuAdmin.Text = "Menú Admin";
            // 
            // frmMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1070, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMenuAdmin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Form_MenuInicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuInicio_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Usuarios;
        private System.Windows.Forms.Button button_Bitacora;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button_Permisos;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Button btnIdioma;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_MenuAdmin;
    }
}