namespace CheeseLogix.Tecnica
{
    partial class frmSerializacion
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
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSerializacion = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSerializacion = new System.Windows.Forms.TableLayoutPanel();
            this.txtContenidoSerializar = new System.Windows.Forms.TextBox();
            this.panelControlesSerializacion = new System.Windows.Forms.Panel();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.cboTipoDato = new System.Windows.Forms.ComboBox();
            this.lblTipoDato = new System.Windows.Forms.Label();
            this.groupBoxDeserializacion = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDeserializacion = new System.Windows.Forms.TableLayoutPanel();
            this.txtContenidoDeserializar = new System.Windows.Forms.TextBox();
            this.treeViewDeserializado = new System.Windows.Forms.TreeView();
            this.panelControlesDeserializacion = new System.Windows.Forms.Panel();
            this.btnCambiarVista = new System.Windows.Forms.Button();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardarSerializado = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelIdioma = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.groupBoxSerializacion.SuspendLayout();
            this.tableLayoutPanelSerializacion.SuspendLayout();
            this.panelControlesSerializacion.SuspendLayout();
            this.groupBoxDeserializacion.SuspendLayout();
            this.tableLayoutPanelDeserializacion.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelIdioma.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 1;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.groupBoxSerializacion, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.groupBoxDeserializacion, 0, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelBotones, 0, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelIdioma, 0, 3);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 4;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(1000, 700);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // groupBoxSerializacion
            // 
            this.groupBoxSerializacion.Controls.Add(this.tableLayoutPanelSerializacion);
            this.groupBoxSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSerializacion.ForeColor = System.Drawing.Color.White;
            this.groupBoxSerializacion.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSerializacion.Name = "groupBoxSerializacion";
            this.groupBoxSerializacion.Size = new System.Drawing.Size(994, 274);
            this.groupBoxSerializacion.TabIndex = 0;
            this.groupBoxSerializacion.TabStop = false;
            this.groupBoxSerializacion.Tag = "groupBoxSerializacion_frmSer";
            this.groupBoxSerializacion.Text = "Serialización";
            // 
            // tableLayoutPanelSerializacion
            // 
            this.tableLayoutPanelSerializacion.ColumnCount = 1;
            this.tableLayoutPanelSerializacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSerializacion.Controls.Add(this.txtContenidoSerializar, 0, 1);
            this.tableLayoutPanelSerializacion.Controls.Add(this.panelControlesSerializacion, 0, 0);
            this.tableLayoutPanelSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSerializacion.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelSerializacion.Name = "tableLayoutPanelSerializacion";
            this.tableLayoutPanelSerializacion.RowCount = 2;
            this.tableLayoutPanelSerializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSerializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelSerializacion.Size = new System.Drawing.Size(988, 255);
            this.tableLayoutPanelSerializacion.TabIndex = 0;
            // 
            // txtContenidoSerializar
            // 
            this.txtContenidoSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtContenidoSerializar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContenidoSerializar.ForeColor = System.Drawing.Color.White;
            this.txtContenidoSerializar.Location = new System.Drawing.Point(3, 52);
            this.txtContenidoSerializar.Multiline = true;
            this.txtContenidoSerializar.Name = "txtContenidoSerializar";
            this.txtContenidoSerializar.ReadOnly = true;
            this.txtContenidoSerializar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContenidoSerializar.Size = new System.Drawing.Size(982, 200);
            this.txtContenidoSerializar.TabIndex = 3;
            // 
            // panelControlesSerializacion
            // 
            this.panelControlesSerializacion.Controls.Add(this.btnSerializar);
            this.panelControlesSerializacion.Controls.Add(this.cboTipoDato);
            this.panelControlesSerializacion.Controls.Add(this.lblTipoDato);
            this.panelControlesSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlesSerializacion.Location = new System.Drawing.Point(3, 3);
            this.panelControlesSerializacion.Name = "panelControlesSerializacion";
            this.panelControlesSerializacion.Size = new System.Drawing.Size(982, 45);
            this.panelControlesSerializacion.TabIndex = 0;
            // 
            // btnSerializar
            // 
            this.btnSerializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSerializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerializar.ForeColor = System.Drawing.Color.White;
            this.btnSerializar.Location = new System.Drawing.Point(850, 10);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(120, 30);
            this.btnSerializar.TabIndex = 2;
            this.btnSerializar.Tag = "btnSerializar_frmSer";
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = false;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // cboTipoDato
            // 
            this.cboTipoDato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDato.ForeColor = System.Drawing.Color.White;
            this.cboTipoDato.FormattingEnabled = true;
            this.cboTipoDato.Location = new System.Drawing.Point(80, 10);
            this.cboTipoDato.Name = "cboTipoDato";
            this.cboTipoDato.Size = new System.Drawing.Size(150, 21);
            this.cboTipoDato.TabIndex = 1;
            // 
            // lblTipoDato
            // 
            this.lblTipoDato.AutoSize = true;
            this.lblTipoDato.ForeColor = System.Drawing.Color.White;
            this.lblTipoDato.Location = new System.Drawing.Point(20, 13);
            this.lblTipoDato.Name = "lblTipoDato";
            this.lblTipoDato.Size = new System.Drawing.Size(55, 13);
            this.lblTipoDato.TabIndex = 0;
            this.lblTipoDato.Tag = "lblTipoDato_frmSer";
            this.lblTipoDato.Text = "Tipo dato:";
            // 
            // groupBoxDeserializacion
            // 
            this.groupBoxDeserializacion.Controls.Add(this.tableLayoutPanelDeserializacion);
            this.groupBoxDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDeserializacion.ForeColor = System.Drawing.Color.White;
            this.groupBoxDeserializacion.Location = new System.Drawing.Point(3, 273);
            this.groupBoxDeserializacion.Name = "groupBoxDeserializacion";
            this.groupBoxDeserializacion.Size = new System.Drawing.Size(994, 310);
            this.groupBoxDeserializacion.TabIndex = 1;
            this.groupBoxDeserializacion.TabStop = false;
            this.groupBoxDeserializacion.Tag = "groupBoxDeserializacion_frmSer";
            this.groupBoxDeserializacion.Text = "Deserialización";
            // 
            // tableLayoutPanelDeserializacion
            // 
            this.tableLayoutPanelDeserializacion.ColumnCount = 2;
            this.tableLayoutPanelDeserializacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDeserializacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDeserializacion.Controls.Add(this.txtContenidoDeserializar, 0, 0);
            this.tableLayoutPanelDeserializacion.Controls.Add(this.treeViewDeserializado, 1, 0);
            this.tableLayoutPanelDeserializacion.Controls.Add(this.panelControlesDeserializacion, 0, 1);
            this.tableLayoutPanelDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDeserializacion.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelDeserializacion.Name = "tableLayoutPanelDeserializacion";
            this.tableLayoutPanelDeserializacion.RowCount = 2;
            this.tableLayoutPanelDeserializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanelDeserializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelDeserializacion.Size = new System.Drawing.Size(988, 291);
            this.tableLayoutPanelDeserializacion.TabIndex = 0;
            // 
            // txtContenidoDeserializar
            // 
            this.txtContenidoDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtContenidoDeserializar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContenidoDeserializar.ForeColor = System.Drawing.Color.White;
            this.txtContenidoDeserializar.Location = new System.Drawing.Point(3, 3);
            this.txtContenidoDeserializar.Multiline = true;
            this.txtContenidoDeserializar.Name = "txtContenidoDeserializar";
            this.txtContenidoDeserializar.ReadOnly = true;
            this.txtContenidoDeserializar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContenidoDeserializar.Size = new System.Drawing.Size(488, 241);
            this.txtContenidoDeserializar.TabIndex = 2;
            // 
            // treeViewDeserializado
            // 
            this.treeViewDeserializado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.treeViewDeserializado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDeserializado.ForeColor = System.Drawing.Color.White;
            this.treeViewDeserializado.Location = new System.Drawing.Point(497, 3);
            this.treeViewDeserializado.Name = "treeViewDeserializado";
            this.treeViewDeserializado.Size = new System.Drawing.Size(488, 241);
            this.treeViewDeserializado.TabIndex = 3;
            this.treeViewDeserializado.Visible = false;
            // 
            // panelControlesDeserializacion
            // 
            this.tableLayoutPanelDeserializacion.SetColumnSpan(this.panelControlesDeserializacion, 2);
            this.panelControlesDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlesDeserializacion.Location = new System.Drawing.Point(3, 250);
            this.panelControlesDeserializacion.Name = "panelControlesDeserializacion";
            this.panelControlesDeserializacion.Size = new System.Drawing.Size(982, 38);
            this.panelControlesDeserializacion.TabIndex = 0;
            // 
            // btnCambiarVista
            // 
            this.btnCambiarVista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnCambiarVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarVista.ForeColor = System.Drawing.Color.White;
            this.btnCambiarVista.Location = new System.Drawing.Point(450, 6);
            this.btnCambiarVista.Name = "btnCambiarVista";
            this.btnCambiarVista.Size = new System.Drawing.Size(120, 25);
            this.btnCambiarVista.TabIndex = 2;
            this.btnCambiarVista.Tag = "btnCambiarVista_frmSer";
            this.btnCambiarVista.Text = "Vista Estructurada";
            this.btnCambiarVista.UseVisualStyleBackColor = false;
            this.btnCambiarVista.Click += new System.EventHandler(this.btnCambiarVista_Click);
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnDeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeserializar.ForeColor = System.Drawing.Color.White;
            this.btnDeserializar.Location = new System.Drawing.Point(320, 6);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(120, 25);
            this.btnDeserializar.TabIndex = 1;
            this.btnDeserializar.Tag = "btnDeserializar_frmSer";
            this.btnDeserializar.Text = "Deserializar";
            this.btnDeserializar.UseVisualStyleBackColor = false;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnCambiarVista);
            this.panelBotones.Controls.Add(this.btnGuardarSerializado);
            this.panelBotones.Controls.Add(this.btnDeserializar);
            this.panelBotones.Controls.Add(this.btnSalir);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones.Location = new System.Drawing.Point(3, 483);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(994, 52);
            this.panelBotones.TabIndex = 2;
            // 
            // btnGuardarSerializado
            // 
            this.btnGuardarSerializado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGuardarSerializado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSerializado.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSerializado.Location = new System.Drawing.Point(20, 12);
            this.btnGuardarSerializado.Name = "btnGuardarSerializado";
            this.btnGuardarSerializado.Size = new System.Drawing.Size(120, 30);
            this.btnGuardarSerializado.TabIndex = 2;
            this.btnGuardarSerializado.Tag = "btnGuardarSerializado_frmSer";
            this.btnGuardarSerializado.Text = "Guardar";
            this.btnGuardarSerializado.UseVisualStyleBackColor = false;
            this.btnGuardarSerializado.Click += new System.EventHandler(this.btnGuardarSerializado_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(850, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 30);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Tag = "btnSalir_frmSer";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelIdioma
            // 
            this.panelIdioma.Controls.Add(this.tableLayoutPanel1);
            this.panelIdioma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIdioma.Location = new System.Drawing.Point(3, 543);
            this.panelIdioma.Name = "panelIdioma";
            this.panelIdioma.Size = new System.Drawing.Size(994, 45);
            this.panelIdioma.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 45);
            this.tableLayoutPanel1.TabIndex = 70;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(500, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(491, 39);
            this.tableLayoutPanel6.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(2, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 15);
            this.label7.TabIndex = 46;
            this.label7.Tag = "Label_SelecIdioma_GPer";
            this.label7.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIdiomas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIdiomas.ForeColor = System.Drawing.Color.White;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(268, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(120, 21);
            this.cboxIdiomas.TabIndex = 4;
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // frmSerializacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "frmSerializacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serialización de Datos - CheeseLogix";
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.groupBoxSerializacion.ResumeLayout(false);
            this.tableLayoutPanelSerializacion.ResumeLayout(false);
            this.tableLayoutPanelSerializacion.PerformLayout();
            this.panelControlesSerializacion.ResumeLayout(false);
            this.panelControlesSerializacion.PerformLayout();
            this.groupBoxDeserializacion.ResumeLayout(false);
            this.tableLayoutPanelDeserializacion.ResumeLayout(false);
            this.tableLayoutPanelDeserializacion.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelIdioma.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.GroupBox groupBoxSerializacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerializacion;
        private System.Windows.Forms.TextBox txtContenidoSerializar;
        private System.Windows.Forms.Panel panelControlesSerializacion;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.ComboBox cboTipoDato;
        private System.Windows.Forms.Label lblTipoDato;
        private System.Windows.Forms.GroupBox groupBoxDeserializacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDeserializacion;
        private System.Windows.Forms.TextBox txtContenidoDeserializar;
        private System.Windows.Forms.Panel panelControlesDeserializacion;
        private System.Windows.Forms.Button btnDeserializar;
        private System.Windows.Forms.Button btnCambiarVista;
        private System.Windows.Forms.TreeView treeViewDeserializado;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnGuardarSerializado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label7;
    }
}