namespace CheeseLogix
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
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelBottomMenu = new System.Windows.Forms.Panel();
            this.btnAdministracion = new FontAwesome.Sharp.IconButton();
            this.btnReportes = new System.Windows.Forms.Button();
            this.PanelEntidades = new System.Windows.Forms.Panel();
            this.buttonGestionarProveedores = new System.Windows.Forms.Button();
            this.buttonGestionarClientes = new System.Windows.Forms.Button();
            this.buttonEntidades = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.panelInsumos = new System.Windows.Forms.Panel();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnComprasProductos = new System.Windows.Forms.Button();
            this.btnStockProductos = new System.Windows.Forms.Button();
            this.btnGestionProducto = new System.Windows.Forms.Button();
            this.panelCotizaciones = new System.Windows.Forms.Panel();
            this.buttonEvaluarSolicitudes = new System.Windows.Forms.Button();
            this.buttonSolicitarCotizacion = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelCaja = new System.Windows.Forms.Panel();
            this.btnCobrarVenta = new System.Windows.Forms.Button();
            this.btnDespachoProducto = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelRedes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.panelDateHour.SuspendLayout();
            this.menuStripPrincipal.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.PanelEntidades.SuspendLayout();
            this.panelInsumos.SuspendLayout();
            this.panelCotizaciones.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelCaja.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelMain.Controls.Add(this.panelCentral);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Controls.Add(this.menuStripPrincipal);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(228, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1015, 578);
            this.panelMain.TabIndex = 1;
            // 
            // panelCentral
            // 
            this.panelCentral.BackgroundImage = global::CheeseLogix.Properties.Resources._32__30__45;
            this.panelCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 32);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1015, 478);
            this.panelCentral.TabIndex = 20;
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
            this.labelDate.Location = new System.Drawing.Point(158, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.labelDate.Size = new System.Drawing.Size(17, 31);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "-";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel8.Location = new System.Drawing.Point(731, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(3, 48);
            this.panel8.TabIndex = 1;
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
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.panelBottomMenu);
            this.panelSideMenu.Controls.Add(this.btnAdministracion);
            this.panelSideMenu.Controls.Add(this.btnReportes);
            this.panelSideMenu.Controls.Add(this.PanelEntidades);
            this.panelSideMenu.Controls.Add(this.buttonEntidades);
            this.panelSideMenu.Controls.Add(this.panelCaja);
            this.panelSideMenu.Controls.Add(this.btnCaja);
            this.panelSideMenu.Controls.Add(this.panelInsumos);
            this.panelSideMenu.Controls.Add(this.btnGestionProducto);
            this.panelSideMenu.Controls.Add(this.panelCotizaciones);
            this.panelSideMenu.Controls.Add(this.btnControl);
            this.panelSideMenu.Controls.Add(this.btnProductos);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(228, 578);
            this.panelSideMenu.TabIndex = 2;
            // 
            // panelBottomMenu
            // 
            this.panelBottomMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelBottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMenu.Location = new System.Drawing.Point(0, 814);
            this.panelBottomMenu.Name = "panelBottomMenu";
            this.panelBottomMenu.Size = new System.Drawing.Size(211, 89);
            this.panelBottomMenu.TabIndex = 19;
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
            this.btnAdministracion.Location = new System.Drawing.Point(0, 776);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(211, 38);
            this.btnAdministracion.TabIndex = 18;
            this.btnAdministracion.Tag = "btnAdministracion_formPrincipal";
            this.btnAdministracion.Text = "Administracion";
            this.btnAdministracion.UseVisualStyleBackColor = true;
            this.btnAdministracion.Visible = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
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
            this.btnReportes.Location = new System.Drawing.Point(0, 744);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(211, 32);
            this.btnReportes.TabIndex = 17;
            this.btnReportes.Tag = "btnReportes_formPrincipal";
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // PanelEntidades
            // 
            this.PanelEntidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.PanelEntidades.Controls.Add(this.buttonGestionarProveedores);
            this.PanelEntidades.Controls.Add(this.buttonGestionarClientes);
            this.PanelEntidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEntidades.Location = new System.Drawing.Point(0, 652);
            this.PanelEntidades.Name = "PanelEntidades";
            this.PanelEntidades.Size = new System.Drawing.Size(211, 92);
            this.PanelEntidades.TabIndex = 17;
            // 
            // buttonGestionarProveedores
            // 
            this.buttonGestionarProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGestionarProveedores.FlatAppearance.BorderSize = 0;
            this.buttonGestionarProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestionarProveedores.ForeColor = System.Drawing.Color.LightGray;
            this.buttonGestionarProveedores.Location = new System.Drawing.Point(0, 45);
            this.buttonGestionarProveedores.Name = "buttonGestionarProveedores";
            this.buttonGestionarProveedores.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonGestionarProveedores.Size = new System.Drawing.Size(211, 42);
            this.buttonGestionarProveedores.TabIndex = 16;
            this.buttonGestionarProveedores.Tag = "btnGestionProv_formPrincipal";
            this.buttonGestionarProveedores.Text = "Gestion Proveedores";
            this.buttonGestionarProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGestionarProveedores.UseVisualStyleBackColor = true;
            this.buttonGestionarProveedores.Visible = false;
            this.buttonGestionarProveedores.Click += new System.EventHandler(this.buttonGestionarProveedores_Click);
            // 
            // buttonGestionarClientes
            // 
            this.buttonGestionarClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGestionarClientes.FlatAppearance.BorderSize = 0;
            this.buttonGestionarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestionarClientes.ForeColor = System.Drawing.Color.LightGray;
            this.buttonGestionarClientes.Location = new System.Drawing.Point(0, 0);
            this.buttonGestionarClientes.Name = "buttonGestionarClientes";
            this.buttonGestionarClientes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonGestionarClientes.Size = new System.Drawing.Size(211, 45);
            this.buttonGestionarClientes.TabIndex = 15;
            this.buttonGestionarClientes.Tag = "btnGestionClientes_formPrincipal";
            this.buttonGestionarClientes.Text = "Gestion Clientes";
            this.buttonGestionarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGestionarClientes.UseVisualStyleBackColor = true;
            this.buttonGestionarClientes.Visible = false;
            this.buttonGestionarClientes.Click += new System.EventHandler(this.buttonGestionarClientes_Click);
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
            this.buttonEntidades.Location = new System.Drawing.Point(0, 610);
            this.buttonEntidades.Name = "buttonEntidades";
            this.buttonEntidades.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEntidades.Size = new System.Drawing.Size(211, 42);
            this.buttonEntidades.TabIndex = 14;
            this.buttonEntidades.Tag = "btnEntidades_formPrincipal";
            this.buttonEntidades.Text = "Entidades";
            this.buttonEntidades.UseVisualStyleBackColor = true;
            this.buttonEntidades.Visible = false;
            this.buttonEntidades.Click += new System.EventHandler(this.buttonEntidades_Click);
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
            this.btnCaja.Location = new System.Drawing.Point(0, 517);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCaja.Size = new System.Drawing.Size(211, 45);
            this.btnCaja.TabIndex = 12;
            this.btnCaja.Tag = "btnCaja_formPrincipal";
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = true;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // panelInsumos
            // 
            this.panelInsumos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelInsumos.Controls.Add(this.btnDespachoProducto);
            this.panelInsumos.Controls.Add(this.btnVentas);
            this.panelInsumos.Controls.Add(this.btnComprasProductos);
            this.panelInsumos.Controls.Add(this.btnStockProductos);
            this.panelInsumos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInsumos.Location = new System.Drawing.Point(0, 336);
            this.panelInsumos.Name = "panelInsumos";
            this.panelInsumos.Size = new System.Drawing.Size(211, 181);
            this.panelInsumos.TabIndex = 7;
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.ForeColor = System.Drawing.Color.LightGray;
            this.btnVentas.Location = new System.Drawing.Point(0, 90);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(211, 45);
            this.btnVentas.TabIndex = 10;
            this.btnVentas.Tag = "btnVenta_formPrincipal";
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Visible = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
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
            this.btnComprasProductos.Size = new System.Drawing.Size(211, 45);
            this.btnComprasProductos.TabIndex = 9;
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
            this.btnStockProductos.TabIndex = 8;
            this.btnStockProductos.Tag = "btnStock_formPrincipal";
            this.btnStockProductos.Text = "Stock";
            this.btnStockProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockProductos.UseVisualStyleBackColor = true;
            this.btnStockProductos.Visible = false;
            this.btnStockProductos.Click += new System.EventHandler(this.btnStockProductos_Click);
            // 
            // btnGestionProducto
            // 
            this.btnGestionProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionProducto.Enabled = false;
            this.btnGestionProducto.FlatAppearance.BorderSize = 0;
            this.btnGestionProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGestionProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(11)))), ((int)(((byte)(28)))));
            this.btnGestionProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionProducto.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGestionProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionProducto.Image")));
            this.btnGestionProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionProducto.Location = new System.Drawing.Point(0, 292);
            this.btnGestionProducto.Name = "btnGestionProducto";
            this.btnGestionProducto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGestionProducto.Size = new System.Drawing.Size(211, 44);
            this.btnGestionProducto.TabIndex = 6;
            this.btnGestionProducto.Tag = "btnGestionProductos_formPrincipal";
            this.btnGestionProducto.Text = "Gestionar Productos";
            this.btnGestionProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestionProducto.UseVisualStyleBackColor = true;
            this.btnGestionProducto.Click += new System.EventHandler(this.btnGestionProducto_Click);
            // 
            // panelCotizaciones
            // 
            this.panelCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelCotizaciones.Controls.Add(this.buttonEvaluarSolicitudes);
            this.panelCotizaciones.Controls.Add(this.buttonSolicitarCotizacion);
            this.panelCotizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCotizaciones.Location = new System.Drawing.Point(0, 209);
            this.panelCotizaciones.Name = "panelCotizaciones";
            this.panelCotizaciones.Size = new System.Drawing.Size(211, 83);
            this.panelCotizaciones.TabIndex = 3;
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
            this.buttonEvaluarSolicitudes.TabIndex = 5;
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
            this.buttonSolicitarCotizacion.TabIndex = 4;
            this.buttonSolicitarCotizacion.Tag = "btnSolicitarCotizacion_formPrincipal";
            this.buttonSolicitarCotizacion.Text = "Solicitar Cotizaciones";
            this.buttonSolicitarCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSolicitarCotizacion.UseVisualStyleBackColor = true;
            this.buttonSolicitarCotizacion.Visible = false;
            this.buttonSolicitarCotizacion.Click += new System.EventHandler(this.buttonSolicitarCotizacion_Click);
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
            this.btnControl.Location = new System.Drawing.Point(0, 164);
            this.btnControl.Name = "btnControl";
            this.btnControl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnControl.Size = new System.Drawing.Size(211, 45);
            this.btnControl.TabIndex = 2;
            this.btnControl.Tag = "btnCotizaciones_formPrincipal";
            this.btnControl.Text = "Cotizaciones";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Visible = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
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
            this.btnProductos.TabIndex = 1;
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
            this.pictureBoxLogo.Image = global::CheeseLogix.Properties.Resources.WhatsApp_Image_2024_11_06_at_12_21_14_AM;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(211, 119);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelCaja
            // 
            this.panelCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelCaja.Controls.Add(this.btnCobrarVenta);
            this.panelCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaja.Location = new System.Drawing.Point(0, 562);
            this.panelCaja.Name = "panelCaja";
            this.panelCaja.Size = new System.Drawing.Size(211, 48);
            this.panelCaja.TabIndex = 26;
            this.panelCaja.Visible = false;
            // 
            // btnCobrarVenta
            // 
            this.btnCobrarVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCobrarVenta.FlatAppearance.BorderSize = 0;
            this.btnCobrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrarVenta.ForeColor = System.Drawing.Color.LightGray;
            this.btnCobrarVenta.Location = new System.Drawing.Point(0, 0);
            this.btnCobrarVenta.Name = "btnCobrarVenta";
            this.btnCobrarVenta.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCobrarVenta.Size = new System.Drawing.Size(211, 45);
            this.btnCobrarVenta.TabIndex = 13;
            this.btnCobrarVenta.Tag = "btnCobrarVenta_formPrincipal";
            this.btnCobrarVenta.Text = "Cobrar";
            this.btnCobrarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrarVenta.UseVisualStyleBackColor = true;
            this.btnCobrarVenta.Visible = false;
            this.btnCobrarVenta.Click += new System.EventHandler(this.btnCobrarVenta_Click);
            // 
            // btnDespachoProducto
            // 
            this.btnDespachoProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDespachoProducto.FlatAppearance.BorderSize = 0;
            this.btnDespachoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDespachoProducto.ForeColor = System.Drawing.Color.LightGray;
            this.btnDespachoProducto.Location = new System.Drawing.Point(0, 135);
            this.btnDespachoProducto.Name = "btnDespachoProducto";
            this.btnDespachoProducto.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDespachoProducto.Size = new System.Drawing.Size(211, 45);
            this.btnDespachoProducto.TabIndex = 11;
            this.btnDespachoProducto.Tag = "btnDespachoProducto_formPrincipal";
            this.btnDespachoProducto.Text = "Despachar Productos";
            this.btnDespachoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDespachoProducto.UseVisualStyleBackColor = true;
            this.btnDespachoProducto.Visible = false;
            this.btnDespachoProducto.Click += new System.EventHandler(this.btnDespachoProducto_Click);
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
            this.MdiChildActivate += new System.EventHandler(this.frmMenuPrincipal_MdiChildActivate);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelRedes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.panelDateHour.ResumeLayout(false);
            this.panelDateHour.PerformLayout();
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.PanelEntidades.ResumeLayout(false);
            this.panelInsumos.ResumeLayout(false);
            this.panelCotizaciones.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelCaja.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelInsumos;
        private System.Windows.Forms.Panel panelCentral;
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
        private System.Windows.Forms.Button btnGestionProducto;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnStockProductos;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button buttonEntidades;
        private System.Windows.Forms.Button btnComprasProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
        private System.Windows.Forms.ComboBox cboxIdiomas;
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
        private FontAwesome.Sharp.IconButton btnAdministracion;
        private System.Windows.Forms.Button buttonGestionarProveedores;
        private System.Windows.Forms.Button buttonEvaluarSolicitudes;
        private System.Windows.Forms.Button buttonSolicitarCotizacion;
        private System.Windows.Forms.Panel panelBottomMenu;
        private System.Windows.Forms.Panel panelCaja;
        private System.Windows.Forms.Button btnCobrarVenta;
        private System.Windows.Forms.Panel PanelEntidades;
        private System.Windows.Forms.Button buttonGestionarClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnDespachoProducto;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}