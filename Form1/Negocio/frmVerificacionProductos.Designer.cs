namespace Form1.Negocio
{
    partial class frmVerificacionProductos
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
            this.dataGridViewDetalleCotizacion = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetalleCompra = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLlegaronProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxCondicionesProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxCantidadProductos = new System.Windows.Forms.CheckBox();
            this.checkBoxPrecioProductos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.btnAprobarRecepcion = new FontAwesome.Sharp.IconButton();
            this.btnRechazarRecepcion = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDetalleCotizacion
            // 
            this.dataGridViewDetalleCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalleCotizacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetalleCotizacion.Location = new System.Drawing.Point(634, 88);
            this.dataGridViewDetalleCotizacion.MultiSelect = false;
            this.dataGridViewDetalleCotizacion.Name = "dataGridViewDetalleCotizacion";
            this.dataGridViewDetalleCotizacion.ReadOnly = true;
            this.dataGridViewDetalleCotizacion.Size = new System.Drawing.Size(466, 220);
            this.dataGridViewDetalleCotizacion.TabIndex = 0;
            // 
            // dataGridViewDetalleCompra
            // 
            this.dataGridViewDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalleCompra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetalleCompra.Location = new System.Drawing.Point(84, 88);
            this.dataGridViewDetalleCompra.MultiSelect = false;
            this.dataGridViewDetalleCompra.Name = "dataGridViewDetalleCompra";
            this.dataGridViewDetalleCompra.ReadOnly = true;
            this.dataGridViewDetalleCompra.Size = new System.Drawing.Size(466, 220);
            this.dataGridViewDetalleCompra.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalle de la Orden";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Productos Solicitados";
            // 
            // checkBoxLlegaronProductos
            // 
            this.checkBoxLlegaronProductos.AutoSize = true;
            this.checkBoxLlegaronProductos.Location = new System.Drawing.Point(84, 362);
            this.checkBoxLlegaronProductos.Name = "checkBoxLlegaronProductos";
            this.checkBoxLlegaronProductos.Size = new System.Drawing.Size(174, 17);
            this.checkBoxLlegaronProductos.TabIndex = 4;
            this.checkBoxLlegaronProductos.Text = "¿Llegaron todos los productos?";
            this.checkBoxLlegaronProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxCondicionesProductos
            // 
            this.checkBoxCondicionesProductos.AutoSize = true;
            this.checkBoxCondicionesProductos.Location = new System.Drawing.Point(84, 401);
            this.checkBoxCondicionesProductos.Name = "checkBoxCondicionesProductos";
            this.checkBoxCondicionesProductos.Size = new System.Drawing.Size(206, 17);
            this.checkBoxCondicionesProductos.TabIndex = 5;
            this.checkBoxCondicionesProductos.Text = "¿Están los productos en condiciones?";
            this.checkBoxCondicionesProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxCantidadProductos
            // 
            this.checkBoxCantidadProductos.AutoSize = true;
            this.checkBoxCantidadProductos.Location = new System.Drawing.Point(84, 441);
            this.checkBoxCantidadProductos.Name = "checkBoxCantidadProductos";
            this.checkBoxCantidadProductos.Size = new System.Drawing.Size(198, 17);
            this.checkBoxCantidadProductos.TabIndex = 6;
            this.checkBoxCantidadProductos.Text = "¿Las cantidades son las solicitadas?";
            this.checkBoxCantidadProductos.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrecioProductos
            // 
            this.checkBoxPrecioProductos.AutoSize = true;
            this.checkBoxPrecioProductos.Location = new System.Drawing.Point(84, 475);
            this.checkBoxPrecioProductos.Name = "checkBoxPrecioProductos";
            this.checkBoxPrecioProductos.Size = new System.Drawing.Size(146, 17);
            this.checkBoxPrecioProductos.TabIndex = 7;
            this.checkBoxPrecioProductos.Text = "¿El precio es el correcto?";
            this.checkBoxPrecioProductos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Observaciones";
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.Location = new System.Drawing.Point(84, 548);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.Size = new System.Drawing.Size(466, 54);
            this.textBoxObservaciones.TabIndex = 9;
            // 
            // btnAprobarRecepcion
            // 
            this.btnAprobarRecepcion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAprobarRecepcion.IconColor = System.Drawing.Color.Black;
            this.btnAprobarRecepcion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAprobarRecepcion.Location = new System.Drawing.Point(678, 401);
            this.btnAprobarRecepcion.Name = "btnAprobarRecepcion";
            this.btnAprobarRecepcion.Size = new System.Drawing.Size(150, 40);
            this.btnAprobarRecepcion.TabIndex = 10;
            this.btnAprobarRecepcion.Text = "Aprobar Recepcion";
            this.btnAprobarRecepcion.UseVisualStyleBackColor = true;
            this.btnAprobarRecepcion.Click += new System.EventHandler(this.btnAprobarRecepcion_Click);
            // 
            // btnRechazarRecepcion
            // 
            this.btnRechazarRecepcion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRechazarRecepcion.IconColor = System.Drawing.Color.Black;
            this.btnRechazarRecepcion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRechazarRecepcion.Location = new System.Drawing.Point(678, 475);
            this.btnRechazarRecepcion.Name = "btnRechazarRecepcion";
            this.btnRechazarRecepcion.Size = new System.Drawing.Size(150, 44);
            this.btnRechazarRecepcion.TabIndex = 11;
            this.btnRechazarRecepcion.Text = "Rechazar Recepcion";
            this.btnRechazarRecepcion.UseVisualStyleBackColor = true;
            this.btnRechazarRecepcion.Click += new System.EventHandler(this.btnRechazarRecepcion_Click);
            // 
            // frmVerificacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 649);
            this.Controls.Add(this.btnRechazarRecepcion);
            this.Controls.Add(this.btnAprobarRecepcion);
            this.Controls.Add(this.textBoxObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxPrecioProductos);
            this.Controls.Add(this.checkBoxCantidadProductos);
            this.Controls.Add(this.checkBoxCondicionesProductos);
            this.Controls.Add(this.checkBoxLlegaronProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewDetalleCompra);
            this.Controls.Add(this.dataGridViewDetalleCotizacion);
            this.Name = "frmVerificacionProductos";
            this.Text = "frmVerificacionProductos";
            this.Load += new System.EventHandler(this.frmVerificacionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCotizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetalleCotizacion;
        private System.Windows.Forms.DataGridView dataGridViewDetalleCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxLlegaronProductos;
        private System.Windows.Forms.CheckBox checkBoxCondicionesProductos;
        private System.Windows.Forms.CheckBox checkBoxCantidadProductos;
        private System.Windows.Forms.CheckBox checkBoxPrecioProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxObservaciones;
        private FontAwesome.Sharp.IconButton btnAprobarRecepcion;
        private FontAwesome.Sharp.IconButton btnRechazarRecepcion;
    }
}