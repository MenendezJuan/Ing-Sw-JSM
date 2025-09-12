namespace CheeseLogix.Tecnica
{
    partial class frmControlCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlCambios));
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.lblIdiomas = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelSeleccion = new System.Windows.Forms.Panel();
            this.tableLayoutPanelSeleccion = new System.Windows.Forms.TableLayoutPanel();
            this.lblTipoEntidad = new System.Windows.Forms.Label();
            this.comboTipoEntidad = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.tableLayoutPanelContenido = new System.Windows.Forms.TableLayoutPanel();
            this.panelEntidades = new System.Windows.Forms.Panel();
            this.dataGridEntidades = new System.Windows.Forms.DataGridView();
            this.lblEntidadSeleccionada = new System.Windows.Forms.Label();
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.dataGridHistorial = new System.Windows.Forms.DataGridView();
            this.panelHistorialTitulo = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.lblHistorialInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelSeleccion.SuspendLayout();
            this.tableLayoutPanelSeleccion.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.tableLayoutPanelContenido.SuspendLayout();
            this.panelEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).BeginInit();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistorial)).BeginInit();
            this.panelHistorialTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 1;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelTitulo, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelSeleccion, 0, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelContenido, 0, 2);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 3;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(1200, 700);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelTitulo.Controls.Add(this.btnCerrar);
            this.panelTitulo.Controls.Add(this.lblIdiomas);
            this.panelTitulo.Controls.Add(this.cboxIdiomas);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1200, 80);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(234, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "lblTitulo_ControlCambios";
            this.lblTitulo.Text = "Control de Cambios";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(920, 30);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(150, 23);
            this.cboxIdiomas.TabIndex = 1;
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // lblIdiomas
            // 
            this.lblIdiomas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdiomas.AutoSize = true;
            this.lblIdiomas.ForeColor = System.Drawing.Color.White;
            this.lblIdiomas.Location = new System.Drawing.Point(870, 33);
            this.lblIdiomas.Name = "lblIdiomas";
            this.lblIdiomas.Size = new System.Drawing.Size(44, 15);
            this.lblIdiomas.TabIndex = 2;
            this.lblIdiomas.Tag = "lblIdiomas";
            this.lblIdiomas.Text = "Idioma";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1100, 25);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 30);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Tag = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelSeleccion
            // 
            this.panelSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panelSeleccion.Controls.Add(this.tableLayoutPanelSeleccion);
            this.panelSeleccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeleccion.Location = new System.Drawing.Point(0, 80);
            this.panelSeleccion.Margin = new System.Windows.Forms.Padding(0);
            this.panelSeleccion.Name = "panelSeleccion";
            this.panelSeleccion.Size = new System.Drawing.Size(1200, 60);
            this.panelSeleccion.TabIndex = 1;
            // 
            // tableLayoutPanelSeleccion
            // 
            this.tableLayoutPanelSeleccion.ColumnCount = 3;
            this.tableLayoutPanelSeleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelSeleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelSeleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelSeleccion.Controls.Add(this.lblTipoEntidad, 0, 0);
            this.tableLayoutPanelSeleccion.Controls.Add(this.comboTipoEntidad, 1, 0);
            this.tableLayoutPanelSeleccion.Controls.Add(this.btnActualizar, 2, 0);
            this.tableLayoutPanelSeleccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSeleccion.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSeleccion.Name = "tableLayoutPanelSeleccion";
            this.tableLayoutPanelSeleccion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tableLayoutPanelSeleccion.RowCount = 1;
            this.tableLayoutPanelSeleccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSeleccion.Size = new System.Drawing.Size(1200, 60);
            this.tableLayoutPanelSeleccion.TabIndex = 0;
            // 
            // lblTipoEntidad
            // 
            this.lblTipoEntidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipoEntidad.AutoSize = true;
            this.lblTipoEntidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoEntidad.ForeColor = System.Drawing.Color.White;
            this.lblTipoEntidad.Location = new System.Drawing.Point(23, 20);
            this.lblTipoEntidad.Name = "lblTipoEntidad";
            this.lblTipoEntidad.Size = new System.Drawing.Size(94, 19);
            this.lblTipoEntidad.TabIndex = 0;
            this.lblTipoEntidad.Tag = "lblTipoEntidad";
            this.lblTipoEntidad.Text = "Tipo Entidad";
            // 
            // comboTipoEntidad
            // 
            this.comboTipoEntidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoEntidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboTipoEntidad.FormattingEnabled = true;
            this.comboTipoEntidad.Location = new System.Drawing.Point(143, 17);
            this.comboTipoEntidad.Name = "comboTipoEntidad";
            this.comboTipoEntidad.Size = new System.Drawing.Size(180, 25);
            this.comboTipoEntidad.TabIndex = 1;
            this.comboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.comboTipoEntidad_SelectedIndexChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(343, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Tag = "btnActualizar";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.panelContenido.Controls.Add(this.tableLayoutPanelContenido);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 140);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1200, 560);
            this.panelContenido.TabIndex = 2;
            // 
            // tableLayoutPanelContenido
            // 
            this.tableLayoutPanelContenido.ColumnCount = 2;
            this.tableLayoutPanelContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelContenido.Controls.Add(this.panelEntidades, 0, 0);
            this.tableLayoutPanelContenido.Controls.Add(this.panelHistorial, 1, 0);
            this.tableLayoutPanelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelContenido.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelContenido.Name = "tableLayoutPanelContenido";
            this.tableLayoutPanelContenido.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelContenido.RowCount = 1;
            this.tableLayoutPanelContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContenido.Size = new System.Drawing.Size(1200, 560);
            this.tableLayoutPanelContenido.TabIndex = 0;
            // 
            // panelEntidades
            // 
            this.panelEntidades.Controls.Add(this.dataGridEntidades);
            this.panelEntidades.Controls.Add(this.lblEntidadSeleccionada);
            this.panelEntidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntidades.Location = new System.Drawing.Point(13, 13);
            this.panelEntidades.Name = "panelEntidades";
            this.panelEntidades.Size = new System.Drawing.Size(584, 534);
            this.panelEntidades.TabIndex = 0;
            // 
            // dataGridEntidades
            // 
            this.dataGridEntidades.AllowUserToAddRows = false;
            this.dataGridEntidades.AllowUserToDeleteRows = false;
            this.dataGridEntidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridEntidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEntidades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridEntidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEntidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.dataGridEntidades.Location = new System.Drawing.Point(0, 30);
            this.dataGridEntidades.MultiSelect = false;
            this.dataGridEntidades.Name = "dataGridEntidades";
            this.dataGridEntidades.ReadOnly = true;
            this.dataGridEntidades.RowHeadersVisible = false;
            this.dataGridEntidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEntidades.Size = new System.Drawing.Size(584, 464);
            this.dataGridEntidades.TabIndex = 1;
            this.dataGridEntidades.SelectionChanged += new System.EventHandler(this.dataGridEntidades_SelectionChanged);
            // 
            // lblEntidadSeleccionada
            // 
            this.lblEntidadSeleccionada.AutoSize = true;
            this.lblEntidadSeleccionada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEntidadSeleccionada.ForeColor = System.Drawing.Color.White;
            this.lblEntidadSeleccionada.Location = new System.Drawing.Point(0, 5);
            this.lblEntidadSeleccionada.Name = "lblEntidadSeleccionada";
            this.lblEntidadSeleccionada.Size = new System.Drawing.Size(88, 21);
            this.lblEntidadSeleccionada.TabIndex = 0;
            this.lblEntidadSeleccionada.Tag = "lblEntidadSeleccionada";
            this.lblEntidadSeleccionada.Text = "Entidades";
            // panelBotonesCRUD y botones CRUD eliminados - funcionalidad movida a Gestor Usuarios
            // Configuración de botones CRUD eliminada - funcionalidad movida a Gestor Usuarios
            // 
            // panelHistorial
            // 
            this.panelHistorial.Controls.Add(this.dataGridHistorial);
            this.panelHistorial.Controls.Add(this.panelHistorialTitulo);
            this.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistorial.Location = new System.Drawing.Point(603, 13);
            this.panelHistorial.Name = "panelHistorial";
            this.panelHistorial.Size = new System.Drawing.Size(584, 534);
            this.panelHistorial.TabIndex = 1;
            // 
            // dataGridHistorial
            // 
            this.dataGridHistorial.AllowUserToAddRows = false;
            this.dataGridHistorial.AllowUserToDeleteRows = false;
            this.dataGridHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHistorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.dataGridHistorial.Location = new System.Drawing.Point(0, 60);
            this.dataGridHistorial.MultiSelect = false;
            this.dataGridHistorial.Name = "dataGridHistorial";
            this.dataGridHistorial.ReadOnly = true;
            this.dataGridHistorial.RowHeadersVisible = false;
            this.dataGridHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHistorial.Size = new System.Drawing.Size(584, 474);
            this.dataGridHistorial.TabIndex = 1;
            this.dataGridHistorial.SelectionChanged += new System.EventHandler(this.dataGridHistorial_SelectionChanged);
            // 
            // panelHistorialTitulo
            // 
            this.panelHistorialTitulo.Controls.Add(this.btnRestaurar);
            this.panelHistorialTitulo.Controls.Add(this.lblHistorialInfo);
            this.panelHistorialTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistorialTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelHistorialTitulo.Name = "panelHistorialTitulo";
            this.panelHistorialTitulo.Size = new System.Drawing.Size(584, 60);
            this.panelHistorialTitulo.TabIndex = 0;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRestaurar.Enabled = false;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(484, 15);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(100, 30);
            this.btnRestaurar.TabIndex = 1;
            this.btnRestaurar.Tag = "btnRestaurar";
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // lblHistorialInfo
            // 
            this.lblHistorialInfo.AutoSize = true;
            this.lblHistorialInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistorialInfo.ForeColor = System.Drawing.Color.White;
            this.lblHistorialInfo.Location = new System.Drawing.Point(0, 20);
            this.lblHistorialInfo.Name = "lblHistorialInfo";
            this.lblHistorialInfo.Size = new System.Drawing.Size(355, 21);
            this.lblHistorialInfo.TabIndex = 0;
            this.lblHistorialInfo.Tag = "lblHistorialInfo";
            this.lblHistorialInfo.Text = "Seleccione una entidad para ver su historial";
            // 
            // frmControlCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControlCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control de Cambios";
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelSeleccion.ResumeLayout(false);
            this.tableLayoutPanelSeleccion.ResumeLayout(false);
            this.tableLayoutPanelSeleccion.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.tableLayoutPanelContenido.ResumeLayout(false);
            this.panelEntidades.ResumeLayout(false);
            this.panelEntidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).EndInit();
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistorial)).EndInit();
            this.panelHistorialTitulo.ResumeLayout(false);
            this.panelHistorialTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblIdiomas;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelSeleccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSeleccion;
        private System.Windows.Forms.Label lblTipoEntidad;
        private System.Windows.Forms.ComboBox comboTipoEntidad;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContenido;
        private System.Windows.Forms.Panel panelEntidades;
        private System.Windows.Forms.DataGridView dataGridEntidades;
        private System.Windows.Forms.Label lblEntidadSeleccionada;
        private System.Windows.Forms.Panel panelHistorial;
        private System.Windows.Forms.DataGridView dataGridHistorial;
        private System.Windows.Forms.Panel panelHistorialTitulo;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Label lblHistorialInfo;
        // Controles CRUD eliminados - funcionalidad movida a Gestor Usuarios
    }
}
