namespace CheeseLogix.Tecnica
{
    partial class frmVerificacionIntegridad
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelControles = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRestaurarTodos = new System.Windows.Forms.Button();
            this.btnRestaurarSeleccionado = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.dataGridViewInconsistencias = new System.Windows.Forms.DataGridView();
            this.lblInconsistenciasEncontradas = new System.Windows.Forms.Label();
            this.lblEstadoIntegridad = new System.Windows.Forms.Label();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.txtDetalleEntidad = new System.Windows.Forms.TextBox();
            this.lblDetalleEntidad = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.panelResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInconsistencias)).BeginInit();
            this.panelDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(900, 70);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Verificación de Integridad - Dígitos Verificadores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControles
            // 
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelControles.Controls.Add(this.btnCerrar);
            this.panelControles.Controls.Add(this.btnRestaurarTodos);
            this.panelControles.Controls.Add(this.btnRestaurarSeleccionado);
            this.panelControles.Controls.Add(this.btnVerificar);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControles.Location = new System.Drawing.Point(0, 70);
            this.panelControles.Margin = new System.Windows.Forms.Padding(2);
            this.panelControles.Name = "panelControles";
            this.panelControles.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelControles.Size = new System.Drawing.Size(900, 70);
            this.panelControles.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.Location = new System.Drawing.Point(773, 8);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 54);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRestaurarTodos
            // 
            this.btnRestaurarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRestaurarTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRestaurarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarTodos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRestaurarTodos.Location = new System.Drawing.Point(391, 8);
            this.btnRestaurarTodos.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurarTodos.Name = "btnRestaurarTodos";
            this.btnRestaurarTodos.Size = new System.Drawing.Size(188, 54);
            this.btnRestaurarTodos.TabIndex = 2;
            this.btnRestaurarTodos.Text = "Sincronizar BD";
            this.btnRestaurarTodos.UseVisualStyleBackColor = false;
            this.btnRestaurarTodos.Click += new System.EventHandler(this.btnRestaurarTodos_Click);
            // 
            // btnRestaurarSeleccionado
            // 
            this.btnRestaurarSeleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnRestaurarSeleccionado.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRestaurarSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarSeleccionado.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRestaurarSeleccionado.Location = new System.Drawing.Point(203, 8);
            this.btnRestaurarSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurarSeleccionado.Name = "btnRestaurarSeleccionado";
            this.btnRestaurarSeleccionado.Size = new System.Drawing.Size(188, 54);
            this.btnRestaurarSeleccionado.TabIndex = 1;
            this.btnRestaurarSeleccionado.Text = "Restaurar Seleccionado";
            this.btnRestaurarSeleccionado.UseVisualStyleBackColor = false;
            this.btnRestaurarSeleccionado.Click += new System.EventHandler(this.btnRestaurarSeleccionado_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnVerificar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerificar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerificar.Location = new System.Drawing.Point(15, 8);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(188, 54);
            this.btnVerificar.TabIndex = 0;
            this.btnVerificar.Text = "Verificar Integridad";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // panelResultados
            // 
            this.panelResultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelResultados.Controls.Add(this.dataGridViewInconsistencias);
            this.panelResultados.Controls.Add(this.lblInconsistenciasEncontradas);
            this.panelResultados.Controls.Add(this.lblEstadoIntegridad);
            this.panelResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelResultados.Location = new System.Drawing.Point(0, 140);
            this.panelResultados.Margin = new System.Windows.Forms.Padding(2);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Padding = new System.Windows.Forms.Padding(15, 8, 8, 16);
            this.panelResultados.Size = new System.Drawing.Size(562, 388);
            this.panelResultados.TabIndex = 2;
            // 
            // dataGridViewInconsistencias
            // 
            this.dataGridViewInconsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInconsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInconsistencias.Location = new System.Drawing.Point(15, 56);
            this.dataGridViewInconsistencias.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewInconsistencias.Name = "dataGridViewInconsistencias";
            this.dataGridViewInconsistencias.RowHeadersWidth = 51;
            this.dataGridViewInconsistencias.Size = new System.Drawing.Size(539, 316);
            this.dataGridViewInconsistencias.TabIndex = 2;
            // 
            // lblInconsistenciasEncontradas
            // 
            this.lblInconsistenciasEncontradas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInconsistenciasEncontradas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInconsistenciasEncontradas.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInconsistenciasEncontradas.Location = new System.Drawing.Point(15, 32);
            this.lblInconsistenciasEncontradas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInconsistenciasEncontradas.Name = "lblInconsistenciasEncontradas";
            this.lblInconsistenciasEncontradas.Size = new System.Drawing.Size(539, 24);
            this.lblInconsistenciasEncontradas.TabIndex = 1;
            this.lblInconsistenciasEncontradas.Text = "Inconsistencias encontradas: -";
            this.lblInconsistenciasEncontradas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstadoIntegridad
            // 
            this.lblEstadoIntegridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstadoIntegridad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEstadoIntegridad.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEstadoIntegridad.Location = new System.Drawing.Point(15, 8);
            this.lblEstadoIntegridad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstadoIntegridad.Name = "lblEstadoIntegridad";
            this.lblEstadoIntegridad.Size = new System.Drawing.Size(539, 24);
            this.lblEstadoIntegridad.TabIndex = 0;
            this.lblEstadoIntegridad.Text = "Estado: -";
            this.lblEstadoIntegridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDetalle
            // 
            this.panelDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelDetalle.Controls.Add(this.txtDetalleEntidad);
            this.panelDetalle.Controls.Add(this.lblDetalleEntidad);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(562, 140);
            this.panelDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(8, 8, 15, 16);
            this.panelDetalle.Size = new System.Drawing.Size(338, 388);
            this.panelDetalle.TabIndex = 3;
            // 
            // txtDetalleEntidad
            // 
            this.txtDetalleEntidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(119)))), ((int)(((byte)(31)))));
            this.txtDetalleEntidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalleEntidad.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDetalleEntidad.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtDetalleEntidad.Location = new System.Drawing.Point(8, 32);
            this.txtDetalleEntidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtDetalleEntidad.Multiline = true;
            this.txtDetalleEntidad.Name = "txtDetalleEntidad";
            this.txtDetalleEntidad.ReadOnly = true;
            this.txtDetalleEntidad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleEntidad.Size = new System.Drawing.Size(315, 340);
            this.txtDetalleEntidad.TabIndex = 1;
            // 
            // lblDetalleEntidad
            // 
            this.lblDetalleEntidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalleEntidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetalleEntidad.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDetalleEntidad.Location = new System.Drawing.Point(8, 8);
            this.lblDetalleEntidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetalleEntidad.Name = "lblDetalleEntidad";
            this.lblDetalleEntidad.Size = new System.Drawing.Size(315, 24);
            this.lblDetalleEntidad.TabIndex = 0;
            this.lblDetalleEntidad.Text = "Detalle de la Inconsistencia";
            this.lblDetalleEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmVerificacionIntegridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(900, 528);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmVerificacionIntegridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificación de Integridad - CheeseLogix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVerificacionIntegridad_FormClosing);
            this.Load += new System.EventHandler(this.frmVerificacionIntegridad_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInconsistencias)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnRestaurarSeleccionado;
        private System.Windows.Forms.Button btnRestaurarTodos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lblEstadoIntegridad;
        private System.Windows.Forms.Label lblInconsistenciasEncontradas;
        private System.Windows.Forms.DataGridView dataGridViewInconsistencias;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblDetalleEntidad;
        private System.Windows.Forms.TextBox txtDetalleEntidad;
    }
}

