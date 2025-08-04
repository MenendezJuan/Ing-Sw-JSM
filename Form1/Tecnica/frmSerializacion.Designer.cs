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
            this.panelControlesDeserializacion = new System.Windows.Forms.Panel();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardarSerializado = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelIdioma = new System.Windows.Forms.Panel();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.labelIdioma = new System.Windows.Forms.Label();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.groupBoxSerializacion.SuspendLayout();
            this.tableLayoutPanelSerializacion.SuspendLayout();
            this.panelControlesSerializacion.SuspendLayout();
            this.groupBoxDeserializacion.SuspendLayout();
            this.tableLayoutPanelDeserializacion.SuspendLayout();
            this.panelControlesDeserializacion.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelIdioma.SuspendLayout();
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
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // groupBoxSerializacion
            // 
            this.groupBoxSerializacion.Controls.Add(this.tableLayoutPanelSerializacion);
            this.groupBoxSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSerializacion.ForeColor = System.Drawing.Color.White;
            this.groupBoxSerializacion.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSerializacion.Name = "groupBoxSerializacion";
            this.groupBoxSerializacion.Size = new System.Drawing.Size(794, 264);
            this.groupBoxSerializacion.TabIndex = 0;
            this.groupBoxSerializacion.TabStop = false;
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
            this.tableLayoutPanelSerializacion.Size = new System.Drawing.Size(788, 245);
            this.tableLayoutPanelSerializacion.TabIndex = 0;
            // 
            // panelControlesSerializacion
            // 
            this.panelControlesSerializacion.Controls.Add(this.btnSerializar);
            this.panelControlesSerializacion.Controls.Add(this.cboTipoDato);
            this.panelControlesSerializacion.Controls.Add(this.lblTipoDato);
            this.panelControlesSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlesSerializacion.Location = new System.Drawing.Point(3, 3);
            this.panelControlesSerializacion.Name = "panelControlesSerializacion";
            this.panelControlesSerializacion.Size = new System.Drawing.Size(782, 43);
            this.panelControlesSerializacion.TabIndex = 0;
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
            this.txtContenidoSerializar.Size = new System.Drawing.Size(782, 190);
            this.txtContenidoSerializar.TabIndex = 3;
            // 
            // btnSerializar
            // 
            this.btnSerializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnSerializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerializar.ForeColor = System.Drawing.Color.White;
            this.btnSerializar.Location = new System.Drawing.Point(650, 8);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(120, 30);
            this.btnSerializar.TabIndex = 2;
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = false;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // cboTipoDato
            // 
            this.cboTipoDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
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
            this.lblTipoDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTipoDato.AutoSize = true;
            this.lblTipoDato.ForeColor = System.Drawing.Color.White;
            this.lblTipoDato.Location = new System.Drawing.Point(20, 13);
            this.lblTipoDato.Name = "lblTipoDato";
            this.lblTipoDato.Size = new System.Drawing.Size(54, 13);
            this.lblTipoDato.TabIndex = 0;
            this.lblTipoDato.Text = "Tipo dato:";
            // 
            // groupBoxDeserializacion
            // 
            this.groupBoxDeserializacion.Controls.Add(this.tableLayoutPanelDeserializacion);
            this.groupBoxDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDeserializacion.ForeColor = System.Drawing.Color.White;
            this.groupBoxDeserializacion.Location = new System.Drawing.Point(3, 273);
            this.groupBoxDeserializacion.Name = "groupBoxDeserializacion";
            this.groupBoxDeserializacion.Size = new System.Drawing.Size(794, 204);
            this.groupBoxDeserializacion.TabIndex = 1;
            this.groupBoxDeserializacion.TabStop = false;
            this.groupBoxDeserializacion.Text = "Deserialización";
            // 
            // tableLayoutPanelDeserializacion
            // 
            this.tableLayoutPanelDeserializacion.ColumnCount = 1;
            this.tableLayoutPanelDeserializacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDeserializacion.Controls.Add(this.txtContenidoDeserializar, 0, 1);
            this.tableLayoutPanelDeserializacion.Controls.Add(this.panelControlesDeserializacion, 0, 0);
            this.tableLayoutPanelDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDeserializacion.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelDeserializacion.Name = "tableLayoutPanelDeserializacion";
            this.tableLayoutPanelDeserializacion.RowCount = 2;
            this.tableLayoutPanelDeserializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDeserializacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelDeserializacion.Size = new System.Drawing.Size(788, 185);
            this.tableLayoutPanelDeserializacion.TabIndex = 0;
            // 
            // panelControlesDeserializacion
            // 
            this.panelControlesDeserializacion.Controls.Add(this.btnDeserializar);
            this.panelControlesDeserializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlesDeserializacion.Location = new System.Drawing.Point(3, 3);
            this.panelControlesDeserializacion.Name = "panelControlesDeserializacion";
            this.panelControlesDeserializacion.Size = new System.Drawing.Size(782, 31);
            this.panelControlesDeserializacion.TabIndex = 0;
            // 
            // txtContenidoDeserializar
            // 
            this.txtContenidoDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtContenidoDeserializar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContenidoDeserializar.ForeColor = System.Drawing.Color.White;
            this.txtContenidoDeserializar.Location = new System.Drawing.Point(3, 40);
            this.txtContenidoDeserializar.Multiline = true;
            this.txtContenidoDeserializar.Name = "txtContenidoDeserializar";
            this.txtContenidoDeserializar.ReadOnly = true;
            this.txtContenidoDeserializar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContenidoDeserializar.Size = new System.Drawing.Size(782, 142);
            this.txtContenidoDeserializar.TabIndex = 2;
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnDeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeserializar.ForeColor = System.Drawing.Color.White;
            this.btnDeserializar.Location = new System.Drawing.Point(20, 3);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(120, 25);
            this.btnDeserializar.TabIndex = 1;
            this.btnDeserializar.Text = "Deserializar";
            this.btnDeserializar.UseVisualStyleBackColor = false;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnGuardarSerializado);
            this.panelBotones.Controls.Add(this.btnSalir);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones.Location = new System.Drawing.Point(3, 483);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(794, 54);
            this.panelBotones.TabIndex = 2;
            // 
            // btnGuardarSerializado
            // 
            this.btnGuardarSerializado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardarSerializado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGuardarSerializado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSerializado.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSerializado.Location = new System.Drawing.Point(20, 12);
            this.btnGuardarSerializado.Name = "btnGuardarSerializado";
            this.btnGuardarSerializado.Size = new System.Drawing.Size(120, 30);
            this.btnGuardarSerializado.TabIndex = 2;
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
            this.btnSalir.Location = new System.Drawing.Point(650, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 30);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelIdioma
            // 
            this.panelIdioma.Controls.Add(this.cboxIdiomas);
            this.panelIdioma.Controls.Add(this.labelIdioma);
            this.panelIdioma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIdioma.Location = new System.Drawing.Point(3, 543);
            this.panelIdioma.Name = "panelIdioma";
            this.panelIdioma.Size = new System.Drawing.Size(794, 54);
            this.panelIdioma.TabIndex = 3;
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIdiomas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIdiomas.ForeColor = System.Drawing.Color.White;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(650, 15);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(120, 21);
            this.cboxIdiomas.TabIndex = 4;
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // labelIdioma
            // 
            this.labelIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIdioma.AutoSize = true;
            this.labelIdioma.ForeColor = System.Drawing.Color.White;
            this.labelIdioma.Location = new System.Drawing.Point(600, 18);
            this.labelIdioma.Name = "labelIdioma";
            this.labelIdioma.Size = new System.Drawing.Size(41, 13);
            this.labelIdioma.TabIndex = 5;
            this.labelIdioma.Text = "Idioma:";
            // 
            // frmSerializacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "frmSerializacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serialización de Datos - CheeseLogix";
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.groupBoxSerializacion.ResumeLayout(false);
            this.tableLayoutPanelSerializacion.ResumeLayout(false);
            this.panelControlesSerializacion.ResumeLayout(false);
            this.panelControlesSerializacion.PerformLayout();
            this.groupBoxDeserializacion.ResumeLayout(false);
            this.tableLayoutPanelDeserializacion.ResumeLayout(false);
            this.panelControlesDeserializacion.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.panelIdioma.ResumeLayout(false);
            this.panelIdioma.PerformLayout();
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
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnGuardarSerializado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label labelIdioma;
    }
}