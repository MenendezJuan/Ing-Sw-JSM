namespace Form1
{
    partial class frmGenerarOrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarOrdenCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.labelP1 = new System.Windows.Forms.Label();
            this.lblTxtProveedor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.lblTxtFech = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSimbolo = new System.Windows.Forms.Label();
            this.labelP3 = new System.Windows.Forms.Label();
            this.lblTxtTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.lblTxtMarca = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblMedidaPr = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lbltxtFor = new System.Windows.Forms.Label();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.lblTxtPrecio = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnG = new System.Windows.Forms.RadioButton();
            this.btnK = new System.Windows.Forms.RadioButton();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.lblTxtCantidad = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBoxProv = new System.Windows.Forms.ComboBox();
            this.lblTxtProv = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.lblTxtRubro = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cbPago = new System.Windows.Forms.ComboBox();
            this.lblTxtPago = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxProducto = new System.Windows.Forms.ComboBox();
            this.lblTxtProducto = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPago
            // 
            this.btnPago.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.btnPago.FlatAppearance.BorderSize = 2;
            this.btnPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.btnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPago.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnPago.Location = new System.Drawing.Point(120, 487);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(148, 37);
            this.btnPago.TabIndex = 82;
            this.btnPago.Text = "Realizar Pago";
            this.btnPago.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(702, 459);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCerrar.Size = new System.Drawing.Size(95, 30);
            this.btnCerrar.TabIndex = 104;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewLista);
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Location = new System.Drawing.Point(17, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 366);
            this.groupBox3.TabIndex = 103;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewLista
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLista.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dataGridViewLista.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLista.RowHeadersVisible = false;
            this.dataGridViewLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(378, 223);
            this.dataGridViewLista.TabIndex = 84;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnEliminar.Location = new System.Drawing.Point(272, 261);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 74);
            this.btnEliminar.TabIndex = 78;
            this.btnEliminar.Text = "Eliminar de  Lista";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProveedor);
            this.panel1.Controls.Add(this.labelP1);
            this.panel1.Controls.Add(this.lblTxtProveedor);
            this.panel1.Location = new System.Drawing.Point(1, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 29);
            this.panel1.TabIndex = 81;
            // 
            // lblProveedor
            // 
            this.lblProveedor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblProveedor.Location = new System.Drawing.Point(125, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(137, 29);
            this.lblProveedor.TabIndex = 81;
            this.lblProveedor.Text = "-";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelP1
            // 
            this.labelP1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelP1.Location = new System.Drawing.Point(112, 0);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(13, 29);
            this.labelP1.TabIndex = 79;
            this.labelP1.Text = ":";
            this.labelP1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtProveedor
            // 
            this.lblTxtProveedor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtProveedor.Location = new System.Drawing.Point(0, 0);
            this.lblTxtProveedor.Name = "lblTxtProveedor";
            this.lblTxtProveedor.Size = new System.Drawing.Size(112, 29);
            this.lblTxtProveedor.TabIndex = 80;
            this.lblTxtProveedor.Text = "Proveedor";
            this.lblTxtProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFecha);
            this.panel2.Controls.Add(this.labelP2);
            this.panel2.Controls.Add(this.lblTxtFech);
            this.panel2.Location = new System.Drawing.Point(1, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 29);
            this.panel2.TabIndex = 82;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblFecha.Location = new System.Drawing.Point(122, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(140, 29);
            this.lblFecha.TabIndex = 81;
            this.lblFecha.Text = "-";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelP2
            // 
            this.labelP2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelP2.Location = new System.Drawing.Point(109, 0);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(13, 29);
            this.labelP2.TabIndex = 79;
            this.labelP2.Text = ":";
            this.labelP2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtFech
            // 
            this.lblTxtFech.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtFech.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtFech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtFech.Location = new System.Drawing.Point(0, 0);
            this.lblTxtFech.Name = "lblTxtFech";
            this.lblTxtFech.Size = new System.Drawing.Size(109, 29);
            this.lblTxtFech.TabIndex = 80;
            this.lblTxtFech.Text = "Fecha";
            this.lblTxtFech.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.lblSimbolo);
            this.panel3.Controls.Add(this.labelP3);
            this.panel3.Controls.Add(this.lblTxtTotal);
            this.panel3.Location = new System.Drawing.Point(1, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 29);
            this.panel3.TabIndex = 83;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTotal.Location = new System.Drawing.Point(138, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 29);
            this.lblTotal.TabIndex = 82;
            this.lblTotal.Text = "-";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSimbolo
            // 
            this.lblSimbolo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSimbolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblSimbolo.Location = new System.Drawing.Point(122, 0);
            this.lblSimbolo.Name = "lblSimbolo";
            this.lblSimbolo.Size = new System.Drawing.Size(16, 29);
            this.lblSimbolo.TabIndex = 81;
            this.lblSimbolo.Text = "$";
            this.lblSimbolo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelP3
            // 
            this.labelP3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.labelP3.Location = new System.Drawing.Point(109, 0);
            this.labelP3.Name = "labelP3";
            this.labelP3.Size = new System.Drawing.Size(13, 29);
            this.labelP3.TabIndex = 79;
            this.labelP3.Text = ":";
            this.labelP3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtTotal
            // 
            this.lblTxtTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTxtTotal.Name = "lblTxtTotal";
            this.lblTxtTotal.Size = new System.Drawing.Size(109, 29);
            this.lblTxtTotal.TabIndex = 80;
            this.lblTxtTotal.Text = "Total";
            this.lblTxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel11);
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(417, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 366);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.comboBoxMarca);
            this.panel11.Controls.Add(this.lblTxtMarca);
            this.panel11.Location = new System.Drawing.Point(3, 93);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(372, 39);
            this.panel11.TabIndex = 93;
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxMarca.Enabled = false;
            this.comboBoxMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(125, 9);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(223, 24);
            this.comboBoxMarca.TabIndex = 81;
            // 
            // lblTxtMarca
            // 
            this.lblTxtMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtMarca.Location = new System.Drawing.Point(0, 0);
            this.lblTxtMarca.Name = "lblTxtMarca";
            this.lblTxtMarca.Size = new System.Drawing.Size(119, 39);
            this.lblTxtMarca.TabIndex = 80;
            this.lblTxtMarca.Text = "Marca";
            this.lblTxtMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel8);
            this.panel10.Controls.Add(this.textBoxPrecio);
            this.panel10.Controls.Add(this.lblTxtPrecio);
            this.panel10.Location = new System.Drawing.Point(4, 171);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(372, 39);
            this.panel10.TabIndex = 92;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblMedidaPr);
            this.panel8.Controls.Add(this.lblP);
            this.panel8.Controls.Add(this.lbltxtFor);
            this.panel8.Location = new System.Drawing.Point(274, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(95, 36);
            this.panel8.TabIndex = 94;
            // 
            // lblMedidaPr
            // 
            this.lblMedidaPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidaPr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblMedidaPr.Location = new System.Drawing.Point(45, -4);
            this.lblMedidaPr.Name = "lblMedidaPr";
            this.lblMedidaPr.Size = new System.Drawing.Size(42, 36);
            this.lblMedidaPr.TabIndex = 95;
            this.lblMedidaPr.Text = "Kg";
            this.lblMedidaPr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP
            // 
            this.lblP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblP.Location = new System.Drawing.Point(33, -5);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(10, 36);
            this.lblP.TabIndex = 83;
            this.lblP.Text = ":";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltxtFor
            // 
            this.lbltxtFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxtFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lbltxtFor.Location = new System.Drawing.Point(0, -4);
            this.lbltxtFor.Name = "lbltxtFor";
            this.lbltxtFor.Size = new System.Drawing.Size(33, 36);
            this.lbltxtFor.TabIndex = 94;
            this.lbltxtFor.Text = "Por";
            this.lbltxtFor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Enabled = false;
            this.textBoxPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrecio.Location = new System.Drawing.Point(122, 9);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(146, 22);
            this.textBoxPrecio.TabIndex = 82;
            // 
            // lblTxtPrecio
            // 
            this.lblTxtPrecio.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtPrecio.Location = new System.Drawing.Point(0, 0);
            this.lblTxtPrecio.Name = "lblTxtPrecio";
            this.lblTxtPrecio.Size = new System.Drawing.Size(116, 39);
            this.lblTxtPrecio.TabIndex = 80;
            this.lblTxtPrecio.Text = "Precio";
            this.lblTxtPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnAdd.Location = new System.Drawing.Point(88, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(223, 37);
            this.btnAdd.TabIndex = 91;
            this.btnAdd.Text = "Agregar a Lista";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnG);
            this.panel6.Controls.Add(this.btnK);
            this.panel6.Controls.Add(this.textBoxCantidad);
            this.panel6.Controls.Add(this.lblTxtCantidad);
            this.panel6.Location = new System.Drawing.Point(7, 208);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(369, 39);
            this.panel6.TabIndex = 87;
            // 
            // btnG
            // 
            this.btnG.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnG.AutoSize = true;
            this.btnG.BackColor = System.Drawing.Color.Gray;
            this.btnG.Enabled = false;
            this.btnG.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnG.ForeColor = System.Drawing.SystemColors.Control;
            this.btnG.Location = new System.Drawing.Point(271, 6);
            this.btnG.Name = "btnG";
            this.btnG.Size = new System.Drawing.Size(33, 28);
            this.btnG.TabIndex = 84;
            this.btnG.Text = "Gr";
            this.btnG.UseVisualStyleBackColor = false;
            // 
            // btnK
            // 
            this.btnK.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnK.AutoSize = true;
            this.btnK.BackColor = System.Drawing.Color.Gray;
            this.btnK.Checked = true;
            this.btnK.Enabled = false;
            this.btnK.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnK.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnK.ForeColor = System.Drawing.SystemColors.Control;
            this.btnK.Location = new System.Drawing.Point(309, 6);
            this.btnK.Name = "btnK";
            this.btnK.Size = new System.Drawing.Size(35, 28);
            this.btnK.TabIndex = 83;
            this.btnK.TabStop = true;
            this.btnK.Text = "Kg";
            this.btnK.UseVisualStyleBackColor = false;
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Enabled = false;
            this.textBoxCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCantidad.Location = new System.Drawing.Point(119, 8);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(146, 22);
            this.textBoxCantidad.TabIndex = 81;
            // 
            // lblTxtCantidad
            // 
            this.lblTxtCantidad.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtCantidad.Location = new System.Drawing.Point(0, 0);
            this.lblTxtCantidad.Name = "lblTxtCantidad";
            this.lblTxtCantidad.Size = new System.Drawing.Size(113, 39);
            this.lblTxtCantidad.TabIndex = 80;
            this.lblTxtCantidad.Text = "Cantidad";
            this.lblTxtCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.comboBoxProv);
            this.panel7.Controls.Add(this.lblTxtProv);
            this.panel7.Location = new System.Drawing.Point(2, 132);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(372, 39);
            this.panel7.TabIndex = 88;
            // 
            // comboBoxProv
            // 
            this.comboBoxProv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxProv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxProv.Enabled = false;
            this.comboBoxProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProv.FormattingEnabled = true;
            this.comboBoxProv.Location = new System.Drawing.Point(125, 9);
            this.comboBoxProv.Name = "comboBoxProv";
            this.comboBoxProv.Size = new System.Drawing.Size(223, 24);
            this.comboBoxProv.TabIndex = 81;
            // 
            // lblTxtProv
            // 
            this.lblTxtProv.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtProv.Location = new System.Drawing.Point(0, 0);
            this.lblTxtProv.Name = "lblTxtProv";
            this.lblTxtProv.Size = new System.Drawing.Size(119, 39);
            this.lblTxtProv.TabIndex = 80;
            this.lblTxtProv.Text = "Proveedor";
            this.lblTxtProv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxRubro);
            this.panel5.Controls.Add(this.lblTxtRubro);
            this.panel5.Location = new System.Drawing.Point(3, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(372, 39);
            this.panel5.TabIndex = 86;
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(125, 9);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(223, 24);
            this.comboBoxRubro.TabIndex = 81;
            // 
            // lblTxtRubro
            // 
            this.lblTxtRubro.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtRubro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtRubro.Location = new System.Drawing.Point(0, 0);
            this.lblTxtRubro.Name = "lblTxtRubro";
            this.lblTxtRubro.Size = new System.Drawing.Size(119, 39);
            this.lblTxtRubro.TabIndex = 80;
            this.lblTxtRubro.Text = "Rubro";
            this.lblTxtRubro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cbPago);
            this.panel9.Controls.Add(this.lblTxtPago);
            this.panel9.Location = new System.Drawing.Point(4, 247);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(372, 39);
            this.panel9.TabIndex = 90;
            // 
            // cbPago
            // 
            this.cbPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPago.FormattingEnabled = true;
            this.cbPago.Location = new System.Drawing.Point(122, 9);
            this.cbPago.Name = "cbPago";
            this.cbPago.Size = new System.Drawing.Size(225, 24);
            this.cbPago.TabIndex = 81;
            // 
            // lblTxtPago
            // 
            this.lblTxtPago.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtPago.Location = new System.Drawing.Point(0, 0);
            this.lblTxtPago.Name = "lblTxtPago";
            this.lblTxtPago.Size = new System.Drawing.Size(116, 39);
            this.lblTxtPago.TabIndex = 80;
            this.lblTxtPago.Text = "Pago";
            this.lblTxtPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxProducto);
            this.panel4.Controls.Add(this.lblTxtProducto);
            this.panel4.Location = new System.Drawing.Point(3, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(372, 39);
            this.panel4.TabIndex = 85;
            // 
            // comboBoxProducto
            // 
            this.comboBoxProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProducto.Enabled = false;
            this.comboBoxProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProducto.FormattingEnabled = true;
            this.comboBoxProducto.Location = new System.Drawing.Point(125, 9);
            this.comboBoxProducto.Name = "comboBoxProducto";
            this.comboBoxProducto.Size = new System.Drawing.Size(223, 24);
            this.comboBoxProducto.TabIndex = 81;
            // 
            // lblTxtProducto
            // 
            this.lblTxtProducto.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTxtProducto.Location = new System.Drawing.Point(0, 0);
            this.lblTxtProducto.Name = "lblTxtProducto";
            this.lblTxtProducto.Size = new System.Drawing.Size(119, 39);
            this.lblTxtProducto.TabIndex = 80;
            this.lblTxtProducto.Text = "Producto";
            this.lblTxtProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerar
            // 
            this.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnGenerar.FlatAppearance.BorderSize = 2;
            this.btnGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.btnGenerar.Location = new System.Drawing.Point(21, 423);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(395, 37);
            this.btnGenerar.TabIndex = 101;
            this.btnGenerar.Text = "Generar Orden de Compra";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.lblTitulo.Location = new System.Drawing.Point(21, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(157, 25);
            this.lblTitulo.TabIndex = 100;
            this.lblTitulo.Text = "Agregar Compra";
            // 
            // frmGenerarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 560);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnPago);
            this.Name = "frmGenerarOrdenCompra";
            this.Text = "frmEvaluarSolicitudesCotizacion";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label lblTxtProveedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label lblTxtFech;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSimbolo;
        private System.Windows.Forms.Label labelP3;
        private System.Windows.Forms.Label lblTxtTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.Label lblTxtMarca;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblMedidaPr;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lbltxtFor;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label lblTxtPrecio;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton btnG;
        private System.Windows.Forms.RadioButton btnK;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label lblTxtCantidad;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox comboBoxProv;
        private System.Windows.Forms.Label lblTxtProv;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.Label lblTxtRubro;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cbPago;
        private System.Windows.Forms.Label lblTxtPago;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxProducto;
        private System.Windows.Forms.Label lblTxtProducto;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblTitulo;
    }
}