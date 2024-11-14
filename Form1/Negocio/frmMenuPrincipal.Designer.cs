namespace Form1
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.line2 = new System.Windows.Forms.Panel();
            this.line = new System.Windows.Forms.Panel();
            this.panelRedes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.labelNombreUser = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.panelDateHour = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnAdministracion = new FontAwesome.Sharp.IconButton();
            this.PanelEntidades = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonGestionarProveedores = new System.Windows.Forms.Button();
            this.buttonEntidades = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.panelCotizaciones = new System.Windows.Forms.Panel();
            this.buttonEvaluarSolicitudes = new System.Windows.Forms.Button();
            this.buttonSolicitarCotizacion = new System.Windows.Forms.Button();
            this.panelBottomMenu = new System.Windows.Forms.Panel();
            this.btnControl = new System.Windows.Forms.Button();
            this.panelInsumos = new System.Windows.Forms.Panel();
            this.btnComprasProductos = new System.Windows.Forms.Button();
            this.btnStockProductos = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.menuStripPrincipal.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelRedes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.panelDateHour.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.PanelEntidades.SuspendLayout();
            this.panelCotizaciones.SuspendLayout();
            this.panelInsumos.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelMain.Controls.Add(this.panelCentral);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(228, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1015, 578);
            this.panelMain.TabIndex = 1;
            // 
            // panelCentral
            // 
            this.panelCentral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCentral.BackgroundImage = global::Form1.Properties.Resources._32__30__45;
            this.panelCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelCentral.Controls.Add(this.menuStripPrincipal);
            this.panelCentral.Location = new System.Drawing.Point(0, 0);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1015, 510);
            this.panelCentral.TabIndex = 15;
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUsuario,
            this.toolStripMenuItemAdministracion,
            this.toolStripMenuItemAyuda});
            this.menuStripPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(1015, 32);
            this.menuStripPrincipal.TabIndex = 3;
            this.menuStripPrincipal.Text = "menuStripPrincipal";
            // 
            // toolStripMenuItemUsuario
            // 
            this.toolStripMenuItemUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.toolStripMenuItemUsuario.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUsuario.Image")));
            this.toolStripMenuItemUsuario.Name = "toolStripMenuItemUsuario";
            this.toolStripMenuItemUsuario.Size = new System.Drawing.Size(83, 28);
            this.toolStripMenuItemUsuario.Tag = "toolStripMenuUsuario_frmPrincipal";
            this.toolStripMenuItemUsuario.Text = "Usuario";
            this.toolStripMenuItemUsuario.Click += new System.EventHandler(this.toolStripMenuItemUsuario_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logOutToolStripMenuItem.Image")));
            this.logOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(134, 38);
            this.logOutToolStripMenuItem.Tag = "logOutToolStripMenuItem_frmPrincipal";
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItemAdministracion
            // 
            this.toolStripMenuItemAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsuariosToolStripMenuItem,
            this.perfilesToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.bitacoraToolStripMenuItem});
            this.toolStripMenuItemAdministracion.Name = "toolStripMenuItemAdministracion";
            this.toolStripMenuItemAdministracion.Size = new System.Drawing.Size(100, 28);
            this.toolStripMenuItemAdministracion.Tag = "toolStripMenuItemAdministracion_frmPrincipal";
            this.toolStripMenuItemAdministracion.Text = "Administracion";
            // 
            // UsuariosToolStripMenuItem
            // 
            this.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem";
            this.UsuariosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.UsuariosToolStripMenuItem.Tag = "UsuariosToolStripMenuItem_frmPrincipal";
            this.UsuariosToolStripMenuItem.Text = "Gestion de Usuarios";
            this.UsuariosToolStripMenuItem.Click += new System.EventHandler(this.AusuariosToolStripMenuItem_Click);
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.perfilesToolStripMenuItem.Tag = "perfilesToolStripMenuItem_frmPrincipal";
            this.perfilesToolStripMenuItem.Text = "Gestion de Permisos";
            this.perfilesToolStripMenuItem.Click += new System.EventHandler(this.perfilesToolStripMenuItem_Click);
            // 
            // idiomasToolStripMenuItem
            // 
            this.idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            this.idiomasToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.idiomasToolStripMenuItem.Tag = "idiomasToolStripMenuItem_frmPrincipal";
            this.idiomasToolStripMenuItem.Text = "Gestion de Idiomas";
            this.idiomasToolStripMenuItem.Click += new System.EventHandler(this.idiomasToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.bitacoraToolStripMenuItem.Tag = "bitacoraToolStripMenuItem_frmPrincipal";
            this.bitacoraToolStripMenuItem.Text = "Auditar Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // toolStripMenuItemAyuda
            // 
            this.toolStripMenuItemAyuda.Name = "toolStripMenuItemAyuda";
            this.toolStripMenuItemAyuda.Size = new System.Drawing.Size(53, 28);
            this.toolStripMenuItemAyuda.Tag = "toolStripMenuItemAyuda_frmPrincipal";
            this.toolStripMenuItemAyuda.Text = "Ayuda";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelBottom.Controls.Add(this.line2);
            this.panelBottom.Controls.Add(this.line);
            this.panelBottom.Controls.Add(this.panelRedes);
            this.panelBottom.Controls.Add(this.panelUserInfo);
            this.panelBottom.Controls.Add(this.panelDateHour);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 510);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1015, 68);
            this.panelBottom.TabIndex = 14;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.line2.Dock = System.Windows.Forms.DockStyle.Right;
            this.line2.Location = new System.Drawing.Point(837, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(3, 68);
            this.line2.TabIndex = 1;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.line.Dock = System.Windows.Forms.DockStyle.Left;
            this.line.Location = new System.Drawing.Point(225, 0);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(3, 68);
            this.line.TabIndex = 0;
            // 
            // panelRedes
            // 
            this.panelRedes.Controls.Add(this.tableLayoutPanel1);
            this.panelRedes.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRedes.Location = new System.Drawing.Point(0, 0);
            this.panelRedes.Name = "panelRedes";
            this.panelRedes.Size = new System.Drawing.Size(225, 68);
            this.panelRedes.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblSeleccionarIdioma, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 65);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(10, 12);
            this.lblSeleccionarIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(91, 40);
            this.lblSeleccionarIdioma.TabIndex = 50;
            this.lblSeleccionarIdioma.Tag = "Label_Idioma_FormIni";
            this.lblSeleccionarIdioma.Text = "Seleccionar idioma:";
            // 
            // cboxIdiomas
            // 
            this.cboxIdiomas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(116, 18);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(104, 28);
            this.cboxIdiomas.TabIndex = 49;
            this.cboxIdiomas.Tag = "Combobox_Idioma_FormIni";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.Controls.Add(this.labelNombreUser);
            this.panelUserInfo.Controls.Add(this.labelUsuario);
            this.panelUserInfo.Controls.Add(this.labelUser);
            this.panelUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserInfo.Location = new System.Drawing.Point(0, 0);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(840, 68);
            this.panelUserInfo.TabIndex = 15;
            // 
            // labelNombreUser
            // 
            this.labelNombreUser.AutoSize = true;
            this.labelNombreUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelNombreUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelNombreUser.Location = new System.Drawing.Point(306, 0);
            this.labelNombreUser.Name = "labelNombreUser";
            this.labelNombreUser.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.labelNombreUser.Size = new System.Drawing.Size(16, 31);
            this.labelNombreUser.TabIndex = 20;
            this.labelNombreUser.Tag = "";
            this.labelNombreUser.Text = "-";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelUsuario.Location = new System.Drawing.Point(195, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Padding = new System.Windows.Forms.Padding(50, 15, 0, 0);
            this.labelUsuario.Size = new System.Drawing.Size(111, 31);
            this.labelUsuario.TabIndex = 19;
            this.labelUsuario.Tag = "lblUsuario_frmPrincipal";
            this.labelUsuario.Text = "Usuario";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelUser.Location = new System.Drawing.Point(0, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Padding = new System.Windows.Forms.Padding(130, 15, 0, 0);
            this.labelUser.Size = new System.Drawing.Size(195, 31);
            this.labelUser.TabIndex = 17;
            this.labelUser.Text = "Usuario:";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDateHour
            // 
            this.panelDateHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelDateHour.Controls.Add(this.labelDate);
            this.panelDateHour.Controls.Add(this.panel8);
            this.panelDateHour.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDateHour.Location = new System.Drawing.Point(840, 0);
            this.panelDateHour.Name = "panelDateHour";
            this.panelDateHour.Size = new System.Drawing.Size(175, 68);
            this.panelDateHour.TabIndex = 13;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelDate.Location = new System.Drawing.Point(105, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.labelDate.Size = new System.Drawing.Size(70, 31);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "29/10/24";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel8.Location = new System.Drawing.Point(731, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(3, 48);
            this.panel8.TabIndex = 1;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btnAdministracion);
            this.panelSideMenu.Controls.Add(this.PanelEntidades);
            this.panelSideMenu.Controls.Add(this.buttonEntidades);
            this.panelSideMenu.Controls.Add(this.btnReportes);
            this.panelSideMenu.Controls.Add(this.btnCaja);
            this.panelSideMenu.Controls.Add(this.btnFacturar);
            this.panelSideMenu.Controls.Add(this.panelCotizaciones);
            this.panelSideMenu.Controls.Add(this.panelBottomMenu);
            this.panelSideMenu.Controls.Add(this.btnControl);
            this.panelSideMenu.Controls.Add(this.panelInsumos);
            this.panelSideMenu.Controls.Add(this.btnProductos);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(228, 578);
            this.panelSideMenu.TabIndex = 2;
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministracion.FlatAppearance.BorderSize = 0;
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAdministracion.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdministracion.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnAdministracion.IconColor = System.Drawing.Color.Firebrick;
            this.btnAdministracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdministracion.IconSize = 35;
            this.btnAdministracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministracion.Location = new System.Drawing.Point(0, 614);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(211, 36);
            this.btnAdministracion.TabIndex = 34;
            this.btnAdministracion.Tag = "btnAdministracion_formPrincipal";
            this.btnAdministracion.Text = "Administracion";
            this.btnAdministracion.UseVisualStyleBackColor = true;
            this.btnAdministracion.Visible = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
            // 
            // PanelEntidades
            // 
            this.PanelEntidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.PanelEntidades.Controls.Add(this.buttonGestionarProveedores);
            this.PanelEntidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEntidades.Location = new System.Drawing.Point(0, 569);
            this.PanelEntidades.Name = "PanelEntidades";
            this.PanelEntidades.Size = new System.Drawing.Size(211, 45);
            this.PanelEntidades.TabIndex = 4;
            // 
            // buttonGestionarProveedores
            // 
            this.buttonGestionarProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGestionarProveedores.FlatAppearance.BorderSize = 0;
            this.buttonGestionarProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestionarProveedores.ForeColor = System.Drawing.Color.LightGray;
            this.buttonGestionarProveedores.Location = new System.Drawing.Point(3, 3);
            this.buttonGestionarProveedores.Name = "buttonGestionarProveedores";
            this.buttonGestionarProveedores.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonGestionarProveedores.Size = new System.Drawing.Size(211, 42);
            this.buttonGestionarProveedores.TabIndex = 7;
            this.buttonGestionarProveedores.Tag = "btnGestionProv_formPrincipal";
            this.buttonGestionarProveedores.Text = "Gestion Proveedores";
            this.buttonGestionarProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGestionarProveedores.UseVisualStyleBackColor = true;
            this.buttonGestionarProveedores.Visible = false;
            this.buttonGestionarProveedores.Click += new System.EventHandler(this.buttonGestionarProveedores_Click);
            // 
            // buttonEntidades
            // 
            this.buttonEntidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEntidades.FlatAppearance.BorderSize = 0;
            this.buttonEntidades.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonEntidades.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.buttonEntidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntidades.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonEntidades.Image = ((System.Drawing.Image)(resources.GetObject("buttonEntidades.Image")));
            this.buttonEntidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEntidades.Location = new System.Drawing.Point(0, 524);
            this.buttonEntidades.Name = "buttonEntidades";
            this.buttonEntidades.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEntidades.Size = new System.Drawing.Size(211, 45);
            this.buttonEntidades.TabIndex = 32;
            this.buttonEntidades.Tag = "btnEntidades_formPrincipal";
            this.buttonEntidades.Text = "Entidades";
            this.buttonEntidades.UseVisualStyleBackColor = true;
            this.buttonEntidades.Visible = false;
            this.buttonEntidades.Click += new System.EventHandler(this.buttonEntidades_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.Enabled = false;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 479);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(211, 45);
            this.btnReportes.TabIndex = 31;
            this.btnReportes.Tag = "btnReportes_formPrincipal";
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCaja.Enabled = false;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCaja.Image")));
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.Location = new System.Drawing.Point(0, 434);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCaja.Size = new System.Drawing.Size(211, 45);
            this.btnCaja.TabIndex = 30;
            this.btnCaja.Tag = "btnCaja_formPrincipal";
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = true;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturar.Enabled = false;
            this.btnFacturar.FlatAppearance.BorderSize = 0;
            this.btnFacturar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFacturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.Location = new System.Drawing.Point(0, 389);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFacturar.Size = new System.Drawing.Size(211, 45);
            this.btnFacturar.TabIndex = 29;
            this.btnFacturar.Tag = "btnFacturar_formPrincipal";
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // panelCotizaciones
            // 
            this.panelCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelCotizaciones.Controls.Add(this.buttonEvaluarSolicitudes);
            this.panelCotizaciones.Controls.Add(this.buttonSolicitarCotizacion);
            this.panelCotizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCotizaciones.Location = new System.Drawing.Point(0, 306);
            this.panelCotizaciones.Name = "panelCotizaciones";
            this.panelCotizaciones.Size = new System.Drawing.Size(211, 83);
            this.panelCotizaciones.TabIndex = 25;
            // 
            // buttonEvaluarSolicitudes
            // 
            this.buttonEvaluarSolicitudes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEvaluarSolicitudes.FlatAppearance.BorderSize = 0;
            this.buttonEvaluarSolicitudes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvaluarSolicitudes.ForeColor = System.Drawing.Color.LightGray;
            this.buttonEvaluarSolicitudes.Location = new System.Drawing.Point(0, 45);
            this.buttonEvaluarSolicitudes.Name = "buttonEvaluarSolicitudes";
            this.buttonEvaluarSolicitudes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonEvaluarSolicitudes.Size = new System.Drawing.Size(211, 38);
            this.buttonEvaluarSolicitudes.TabIndex = 7;
            this.buttonEvaluarSolicitudes.Tag = "btnEvaluarCotizacion_formPrincipal";
            this.buttonEvaluarSolicitudes.Text = "Evaluar Cotizaciones";
            this.buttonEvaluarSolicitudes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluarSolicitudes.UseVisualStyleBackColor = true;
            this.buttonEvaluarSolicitudes.Visible = false;
            this.buttonEvaluarSolicitudes.Click += new System.EventHandler(this.buttonEvaluarSolicitudes_Click);
            // 
            // buttonSolicitarCotizacion
            // 
            this.buttonSolicitarCotizacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSolicitarCotizacion.FlatAppearance.BorderSize = 0;
            this.buttonSolicitarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSolicitarCotizacion.ForeColor = System.Drawing.Color.LightGray;
            this.buttonSolicitarCotizacion.Location = new System.Drawing.Point(0, 0);
            this.buttonSolicitarCotizacion.Name = "buttonSolicitarCotizacion";
            this.buttonSolicitarCotizacion.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonSolicitarCotizacion.Size = new System.Drawing.Size(211, 45);
            this.buttonSolicitarCotizacion.TabIndex = 6;
            this.buttonSolicitarCotizacion.Tag = "btnSolicitarCotizacion_formPrincipal";
            this.buttonSolicitarCotizacion.Text = "Solicitar Cotizaciones";
            this.buttonSolicitarCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSolicitarCotizacion.UseVisualStyleBackColor = true;
            this.buttonSolicitarCotizacion.Visible = false;
            this.buttonSolicitarCotizacion.Click += new System.EventHandler(this.buttonSolicitarCotizacion_Click);
            // 
            // panelBottomMenu
            // 
            this.panelBottomMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelBottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMenu.Location = new System.Drawing.Point(0, 650);
            this.panelBottomMenu.Name = "panelBottomMenu";
            this.panelBottomMenu.Size = new System.Drawing.Size(211, 89);
            this.panelBottomMenu.TabIndex = 24;
            // 
            // btnControl
            // 
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnControl.Image = ((System.Drawing.Image)(resources.GetObject("btnControl.Image")));
            this.btnControl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControl.Location = new System.Drawing.Point(0, 261);
            this.btnControl.Name = "btnControl";
            this.btnControl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnControl.Size = new System.Drawing.Size(211, 45);
            this.btnControl.TabIndex = 17;
            this.btnControl.Tag = "btnCotizaciones_formPrincipal";
            this.btnControl.Text = "Cotizaciones";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Visible = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // panelInsumos
            // 
            this.panelInsumos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelInsumos.Controls.Add(this.btnComprasProductos);
            this.panelInsumos.Controls.Add(this.btnStockProductos);
            this.panelInsumos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInsumos.Location = new System.Drawing.Point(0, 164);
            this.panelInsumos.Name = "panelInsumos";
            this.panelInsumos.Size = new System.Drawing.Size(211, 97);
            this.panelInsumos.TabIndex = 16;
            // 
            // btnComprasProductos
            // 
            this.btnComprasProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComprasProductos.FlatAppearance.BorderSize = 0;
            this.btnComprasProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprasProductos.ForeColor = System.Drawing.Color.LightGray;
            this.btnComprasProductos.Location = new System.Drawing.Point(0, 45);
            this.btnComprasProductos.Name = "btnComprasProductos";
            this.btnComprasProductos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnComprasProductos.Size = new System.Drawing.Size(211, 52);
            this.btnComprasProductos.TabIndex = 4;
            this.btnComprasProductos.Tag = "btnCompras_formPrincipal";
            this.btnComprasProductos.Text = "Compras";
            this.btnComprasProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprasProductos.UseVisualStyleBackColor = true;
            this.btnComprasProductos.Visible = false;
            this.btnComprasProductos.Click += new System.EventHandler(this.btnComprasProductos_Click);
            // 
            // btnStockProductos
            // 
            this.btnStockProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockProductos.FlatAppearance.BorderSize = 0;
            this.btnStockProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockProductos.ForeColor = System.Drawing.Color.LightGray;
            this.btnStockProductos.Location = new System.Drawing.Point(0, 0);
            this.btnStockProductos.Name = "btnStockProductos";
            this.btnStockProductos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStockProductos.Size = new System.Drawing.Size(211, 45);
            this.btnStockProductos.TabIndex = 2;
            this.btnStockProductos.Tag = "btnStock_formPrincipal";
            this.btnStockProductos.Text = "Stock";
            this.btnStockProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockProductos.UseVisualStyleBackColor = true;
            this.btnStockProductos.Visible = false;
            this.btnStockProductos.Click += new System.EventHandler(this.btnStockProductos_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 119);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(211, 45);
            this.btnProductos.TabIndex = 15;
            this.btnProductos.Tag = "btnProducto_formPrincipal";
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Visible = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(211, 119);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = global::Form1.Properties.Resources.WhatsApp_Image_2024_11_06_at_12_21_14_AM;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(211, 119);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1243, 578);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSideMenu);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMenuPrincipal";
            this.Text = "CheeseLogix";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelRedes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.panelDateHour.ResumeLayout(false);
            this.panelDateHour.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.PanelEntidades.ResumeLayout(false);
            this.panelCotizaciones.ResumeLayout(false);
            this.panelInsumos.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelInsumos;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Panel panelBottomMenu;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel line2;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Panel panelRedes;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Panel panelDateHour;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panelCotizaciones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button buttonSolicitarCotizacion;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnStockProductos;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button buttonEntidades;
        private System.Windows.Forms.FlowLayoutPanel PanelEntidades;
        private System.Windows.Forms.Button buttonGestionarProveedores;
        private System.Windows.Forms.Button buttonEvaluarSolicitudes;
        private System.Windows.Forms.Button btnComprasProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private FontAwesome.Sharp.IconButton btnAdministracion;
        private System.Windows.Forms.Label labelNombreUser;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUsuario;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdministracion;
        private System.Windows.Forms.ToolStripMenuItem UsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAyuda;
    }
}