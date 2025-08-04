using System.ComponentModel;

namespace CheeseLogix.Negocio.Reportes
{
    partial class frmReporteInteligente
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
            this.tableLayoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutSuperior = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutCentral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxRecomendaciones = new System.Windows.Forms.GroupBox();
            this.txtRecomendaciones = new System.Windows.Forms.TextBox();
            this.tableLayoutBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPrincipal.SuspendLayout();
            this.tableLayoutSuperior.SuspendLayout();
            this.tableLayoutCentral.SuspendLayout();
            this.groupBoxRecomendaciones.SuspendLayout();
            this.tableLayoutBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPrincipal
            // 
            this.tableLayoutPrincipal.ColumnCount = 1;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.Controls.Add(this.tableLayoutSuperior, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.tableLayoutCentral, 0, 1);
            this.tableLayoutPrincipal.Controls.Add(this.tableLayoutBotones, 0, 2);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 3;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(1200, 800);
            this.tableLayoutPrincipal.TabIndex = 0;
            // 
            // tableLayoutSuperior
            // 
            this.tableLayoutSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutSuperior.ColumnCount = 6;
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSuperior.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutSuperior.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutSuperior.Controls.Add(this.lblFechaInicio, 2, 0);
            this.tableLayoutSuperior.Controls.Add(this.dtpFechaInicio, 3, 0);
            this.tableLayoutSuperior.Controls.Add(this.lblFechaFin, 4, 0);
            this.tableLayoutSuperior.Controls.Add(this.dtpFechaFin, 5, 0);
            this.tableLayoutSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSuperior.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSuperior.Name = "tableLayoutSuperior";
            this.tableLayoutSuperior.RowCount = 1;
            this.tableLayoutSuperior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSuperior.Size = new System.Drawing.Size(1194, 54);
            this.tableLayoutSuperior.TabIndex = 0;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.White;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(76, 20);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblSeleccionarIdioma.TabIndex = 0;
            this.lblSeleccionarIdioma.Text = "Idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(123, 16);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(140, 21);
            this.cboxIdiomas.TabIndex = 1;
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            this.lblFechaInicio.Location = new System.Drawing.Point(299, 20);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(373, 17);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.ForeColor = System.Drawing.Color.White;
            this.lblFechaFin.Location = new System.Drawing.Point(530, 20);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 4;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(593, 17);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // tableLayoutCentral
            // 
            this.tableLayoutCentral.ColumnCount = 2;
            this.tableLayoutCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutCentral.Controls.Add(this.groupBoxRecomendaciones, 1, 0);
            this.tableLayoutCentral.Controls.Add(this.reportViewer1, 0, 0);
            this.tableLayoutCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCentral.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutCentral.Name = "tableLayoutCentral";
            this.tableLayoutCentral.RowCount = 1;
            this.tableLayoutCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCentral.Size = new System.Drawing.Size(1194, 674);
            this.tableLayoutCentral.TabIndex = 1;
            // 
            // groupBoxRecomendaciones
            // 
            this.groupBoxRecomendaciones.Controls.Add(this.txtRecomendaciones);
            this.groupBoxRecomendaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRecomendaciones.ForeColor = System.Drawing.Color.White;
            this.groupBoxRecomendaciones.Location = new System.Drawing.Point(838, 3);
            this.groupBoxRecomendaciones.Name = "groupBoxRecomendaciones";
            this.groupBoxRecomendaciones.Size = new System.Drawing.Size(353, 668);
            this.groupBoxRecomendaciones.TabIndex = 1;
            this.groupBoxRecomendaciones.TabStop = false;
            this.groupBoxRecomendaciones.Text = "Recomendaciones Inteligentes";
            // 
            // txtRecomendaciones
            // 
            this.txtRecomendaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.txtRecomendaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecomendaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecomendaciones.ForeColor = System.Drawing.Color.White;
            this.txtRecomendaciones.Location = new System.Drawing.Point(3, 16);
            this.txtRecomendaciones.Multiline = true;
            this.txtRecomendaciones.Name = "txtRecomendaciones";
            this.txtRecomendaciones.ReadOnly = true;
            this.txtRecomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecomendaciones.Size = new System.Drawing.Size(347, 649);
            this.txtRecomendaciones.TabIndex = 0;
            // 
            // tableLayoutBotones
            // 
            this.tableLayoutBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutBotones.ColumnCount = 5;
            this.tableLayoutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutBotones.Controls.Add(this.btnExportarPDF, 1, 0);
            this.tableLayoutBotones.Controls.Add(this.btnExportarExcel, 2, 0);
            this.tableLayoutBotones.Controls.Add(this.btnActualizar, 3, 0);
            this.tableLayoutBotones.Controls.Add(this.btnCerrar, 4, 0);
            this.tableLayoutBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBotones.Location = new System.Drawing.Point(3, 743);
            this.tableLayoutBotones.Name = "tableLayoutBotones";
            this.tableLayoutBotones.RowCount = 1;
            this.tableLayoutBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBotones.Size = new System.Drawing.Size(1194, 54);
            this.tableLayoutBotones.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(719, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(839, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnExportarPDF.FlatAppearance.BorderSize = 0;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(479, 15);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(110, 23);
            this.btnExportarPDF.TabIndex = 0;
            this.btnExportarPDF.Text = "📄 PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(126)))), ((int)(((byte)(90)))));
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(599, 15);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(110, 23);
            this.btnExportarExcel.TabIndex = 1;
            this.btnExportarExcel.Text = "📊 Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(829, 668);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmReporteInteligente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tableLayoutPrincipal);
            this.Icon = ((System.Drawing.Icon)(CheeseLogix.Properties.Resources.ResourceManager.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmReporteInteligente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Inteligentes - CheeseLogix";
            this.Load += new System.EventHandler(this.frmReporteInteligente_Load_1);
            this.tableLayoutPrincipal.ResumeLayout(false);
            this.tableLayoutSuperior.ResumeLayout(false);
            this.tableLayoutSuperior.PerformLayout();
            this.tableLayoutCentral.ResumeLayout(false);
            this.groupBoxRecomendaciones.ResumeLayout(false);
            this.groupBoxRecomendaciones.PerformLayout();
            this.tableLayoutBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSuperior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCentral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBotones;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox groupBoxRecomendaciones;
        private System.Windows.Forms.TextBox txtRecomendaciones;
        private System.Windows.Forms.Button btnCerrar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}