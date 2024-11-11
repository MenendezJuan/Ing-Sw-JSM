namespace Form1
{
    partial class frmGestorPermisos
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.comboBox_Grupos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxIdiomas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_CrearGrupo = new System.Windows.Forms.Button();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Permisos = new System.Windows.Forms.ComboBox();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.button_BorrarGrupo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Usuarios = new System.Windows.Forms.ComboBox();
            this.comboBox_PermisosAsignados = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_AsignarGrupo = new System.Windows.Forms.Button();
            this.button_DesasignarGrupo = new System.Windows.Forms.Button();
            this.button_LimpiarArbol = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.treeView1.Location = new System.Drawing.Point(379, 131);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(499, 292);
            this.treeView1.TabIndex = 0;
            this.treeView1.Tag = "Treeview_Permisos_GPer";
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Agregar.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Agregar.Location = new System.Drawing.Point(25, 30);
            this.button_Agregar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(131, 48);
            this.button_Agregar.TabIndex = 1;
            this.button_Agregar.Tag = "Button_Agregar_GPer";
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = false;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Salir.Location = new System.Drawing.Point(123, 596);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(131, 48);
            this.button_Salir.TabIndex = 4;
            this.button_Salir.Tag = "Button_Salir_GPer";
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // comboBox_Grupos
            // 
            this.comboBox_Grupos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_Grupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Grupos.FormattingEnabled = true;
            this.comboBox_Grupos.Location = new System.Drawing.Point(297, 82);
            this.comboBox_Grupos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Grupos.Name = "comboBox_Grupos";
            this.comboBox_Grupos.Size = new System.Drawing.Size(151, 21);
            this.comboBox_Grupos.TabIndex = 5;
            this.comboBox_Grupos.Tag = "Combobox_Grupos_GPer";
            this.comboBox_Grupos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Grupos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(333, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 6;
            this.label2.Tag = "Label_Grupos_GPer";
            this.label2.Text = "Grupos";
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
            this.cboxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIdiomas.FormattingEnabled = true;
            this.cboxIdiomas.Location = new System.Drawing.Point(188, 3);
            this.cboxIdiomas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxIdiomas.Name = "cboxIdiomas";
            this.cboxIdiomas.Size = new System.Drawing.Size(92, 21);
            this.cboxIdiomas.TabIndex = 45;
            this.cboxIdiomas.Tag = "Combobox_Idiomas_GPer";
            this.cboxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cboxIdiomas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(68, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 40);
            this.label8.TabIndex = 47;
            this.label8.Tag = "Label_GestorPermisos_GPer";
            this.label8.Text = "Gestor Permisos";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_CrearGrupo
            // 
            this.button_CrearGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_CrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_CrearGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CrearGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CrearGrupo.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_CrearGrupo.Location = new System.Drawing.Point(120, 216);
            this.button_CrearGrupo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_CrearGrupo.Name = "button_CrearGrupo";
            this.button_CrearGrupo.Size = new System.Drawing.Size(131, 48);
            this.button_CrearGrupo.TabIndex = 48;
            this.button_CrearGrupo.Tag = "Button_CrearGrupo_GPer";
            this.button_CrearGrupo.Text = "Crear Grupo";
            this.button_CrearGrupo.UseVisualStyleBackColor = false;
            this.button_CrearGrupo.Click += new System.EventHandler(this.button_CrearGrupo_Click);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Nombre.Location = new System.Drawing.Point(124, 134);
            this.textBox_Nombre.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(122, 20);
            this.textBox_Nombre.TabIndex = 49;
            this.textBox_Nombre.Tag = "TextBox_Nombre_GPer";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNombre.Location = new System.Drawing.Point(138, 33);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(94, 30);
            this.lblNombre.TabIndex = 50;
            this.lblNombre.Tag = "Label_Nombre_GPer";
            this.lblNombre.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(149, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 52;
            this.label3.Tag = "Label_Permisos_GPer";
            this.label3.Text = "Permisos";
            // 
            // comboBox_Permisos
            // 
            this.comboBox_Permisos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_Permisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Permisos.FormattingEnabled = true;
            this.comboBox_Permisos.Location = new System.Drawing.Point(123, 19);
            this.comboBox_Permisos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Permisos.Name = "comboBox_Permisos";
            this.comboBox_Permisos.Size = new System.Drawing.Size(119, 21);
            this.comboBox_Permisos.TabIndex = 51;
            this.comboBox_Permisos.Tag = "Combobox_Permisos_GPer";
            // 
            // button_Borrar
            // 
            this.button_Borrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Borrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Borrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Borrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_Borrar.Location = new System.Drawing.Point(208, 30);
            this.button_Borrar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(131, 48);
            this.button_Borrar.TabIndex = 53;
            this.button_Borrar.Tag = "Button_Borrar_GPer";
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = false;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // button_BorrarGrupo
            // 
            this.button_BorrarGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_BorrarGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_BorrarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BorrarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BorrarGrupo.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_BorrarGrupo.Location = new System.Drawing.Point(58, 69);
            this.button_BorrarGrupo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_BorrarGrupo.Name = "button_BorrarGrupo";
            this.button_BorrarGrupo.Size = new System.Drawing.Size(131, 48);
            this.button_BorrarGrupo.TabIndex = 54;
            this.button_BorrarGrupo.Tag = "Button_BorrarGrupo_GPer";
            this.button_BorrarGrupo.Text = "Borrar Grupo";
            this.button_BorrarGrupo.UseVisualStyleBackColor = false;
            this.button_BorrarGrupo.Click += new System.EventHandler(this.button_BorrarGrupo_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(137, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 30);
            this.label4.TabIndex = 56;
            this.label4.Tag = "Label_Usuarios_GPer";
            this.label4.Text = "Usuarios";
            // 
            // comboBox_Usuarios
            // 
            this.comboBox_Usuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_Usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Usuarios.FormattingEnabled = true;
            this.comboBox_Usuarios.Location = new System.Drawing.Point(136, 138);
            this.comboBox_Usuarios.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_Usuarios.Name = "comboBox_Usuarios";
            this.comboBox_Usuarios.Size = new System.Drawing.Size(99, 21);
            this.comboBox_Usuarios.TabIndex = 55;
            this.comboBox_Usuarios.Tag = "Combobox_Usuarios_GPer";
            this.comboBox_Usuarios.SelectedIndexChanged += new System.EventHandler(this.comboBox_Usuarios_SelectedIndexChanged);
            // 
            // comboBox_PermisosAsignados
            // 
            this.comboBox_PermisosAsignados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_PermisosAsignados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PermisosAsignados.FormattingEnabled = true;
            this.comboBox_PermisosAsignados.Location = new System.Drawing.Point(132, 48);
            this.comboBox_PermisosAsignados.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox_PermisosAsignados.Name = "comboBox_PermisosAsignados";
            this.comboBox_PermisosAsignados.Size = new System.Drawing.Size(107, 21);
            this.comboBox_PermisosAsignados.TabIndex = 57;
            this.comboBox_PermisosAsignados.Tag = "Combobox_PermisosAsignados_GPer";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(112, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 15);
            this.label5.TabIndex = 58;
            this.label5.Tag = "Label_PermisosAsignados_GPer";
            this.label5.Text = "Permisos de Usuarios";
            // 
            // button_AsignarGrupo
            // 
            this.button_AsignarGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AsignarGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_AsignarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AsignarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AsignarGrupo.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_AsignarGrupo.Location = new System.Drawing.Point(120, 219);
            this.button_AsignarGrupo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_AsignarGrupo.Name = "button_AsignarGrupo";
            this.button_AsignarGrupo.Size = new System.Drawing.Size(131, 48);
            this.button_AsignarGrupo.TabIndex = 59;
            this.button_AsignarGrupo.Tag = "Button_AsignarGrupo_GPer";
            this.button_AsignarGrupo.Text = "Asignar Grupo";
            this.button_AsignarGrupo.UseVisualStyleBackColor = false;
            this.button_AsignarGrupo.Click += new System.EventHandler(this.button_AsignarGrupo_Click);
            // 
            // button_DesasignarGrupo
            // 
            this.button_DesasignarGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_DesasignarGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_DesasignarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DesasignarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DesasignarGrupo.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_DesasignarGrupo.Location = new System.Drawing.Point(120, 90);
            this.button_DesasignarGrupo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_DesasignarGrupo.Name = "button_DesasignarGrupo";
            this.button_DesasignarGrupo.Size = new System.Drawing.Size(131, 64);
            this.button_DesasignarGrupo.TabIndex = 61;
            this.button_DesasignarGrupo.Tag = "Button_DesAsignarGrupo_GPer";
            this.button_DesasignarGrupo.Text = "Desasignar Grupo";
            this.button_DesasignarGrupo.UseVisualStyleBackColor = false;
            this.button_DesasignarGrupo.Click += new System.EventHandler(this.button_DesasignarGrupo_Click);
            // 
            // button_LimpiarArbol
            // 
            this.button_LimpiarArbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_LimpiarArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(64)))), ((int)(((byte)(62)))));
            this.button_LimpiarArbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LimpiarArbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LimpiarArbol.ForeColor = System.Drawing.Color.Gainsboro;
            this.button_LimpiarArbol.Location = new System.Drawing.Point(563, 596);
            this.button_LimpiarArbol.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_LimpiarArbol.Name = "button_LimpiarArbol";
            this.button_LimpiarArbol.Size = new System.Drawing.Size(131, 48);
            this.button_LimpiarArbol.TabIndex = 62;
            this.button_LimpiarArbol.Tag = "Button_LimpiarArbol_GPer";
            this.button_LimpiarArbol.Text = "Limpiar Arbol";
            this.button_LimpiarArbol.UseVisualStyleBackColor = false;
            this.button_LimpiarArbol.Click += new System.EventHandler(this.button_LimpiarArbol_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_Salir, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_LimpiarArbol, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1258, 654);
            this.tableLayoutPanel1.TabIndex = 63;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.button_BorrarGrupo, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.comboBox_Grupos, 1, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(380, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(497, 124);
            this.tableLayoutPanel7.TabIndex = 69;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBox_PermisosAsignados, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.button_DesasignarGrupo, 0, 2);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(883, 427);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.55882F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.44118F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(372, 157);
            this.tableLayoutPanel5.TabIndex = 67;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox_Usuarios, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_AsignarGrupo, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(883, 133);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(372, 288);
            this.tableLayoutPanel4.TabIndex = 66;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblNombre, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Nombre, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button_CrearGrupo, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 133);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(371, 288);
            this.tableLayoutPanel3.TabIndex = 65;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 427);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(371, 157);
            this.tableLayoutPanel2.TabIndex = 64;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.comboBox_Permisos, 0, 1);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(365, 36);
            this.tableLayoutPanel9.TabIndex = 55;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.button_Borrar, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.button_Agregar, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(365, 109);
            this.tableLayoutPanel8.TabIndex = 54;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cboxIdiomas, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(883, 590);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(372, 61);
            this.tableLayoutPanel6.TabIndex = 68;
            // 
            // frmGestorPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1259, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "frmGestorPermisos";
            this.ShowIcon = false;
            this.Tag = "Form_GestorPermisos_GPer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Grupos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxIdiomas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_CrearGrupo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Permisos;
        private System.Windows.Forms.Button button_BorrarGrupo;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Button button_AsignarGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_PermisosAsignados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Usuarios;
        private System.Windows.Forms.Button button_DesasignarGrupo;
        private System.Windows.Forms.Button button_LimpiarArbol;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}