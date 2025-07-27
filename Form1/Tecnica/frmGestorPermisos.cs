using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmGestorPermisos : Form, IObservador
    {
        public frmGestorPermisos()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            Bll_Permiso = new BLL_PERMISO();
            Bll_Usuario = new BLL_USUARIO();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            ActualizarPermisos();
            ActualizarCombos();
            ActualizarUsuarios();
        }

        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private BLL_PERMISO Bll_Permiso;
        private BLL_USUARIO Bll_Usuario;
        private SessionManager sesion;

        #region Idioma

        private List<Control> ListaControles = new List<Control>();

        public void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                ListaControles.Add(c);
                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }

        private void CargarIdiomas()
        {
            try
            {
                var idiomas = Bll_Idioma.ListarTodos();
                cboxIdiomas.DataSource = idiomas;
                cboxIdiomas.DisplayMember = "Nombre";
                cboxIdiomas.ValueMember = "Id";

                var idiomaPredeterminado = idiomas.FirstOrDefault(i => i.Nombre == "Español");
                if (idiomaPredeterminado != null)
                {
                    cboxIdiomas.SelectedValue = idiomaPredeterminado.Id;
                    sesion.CambiarIdioma(idiomaPredeterminado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }
            }

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        #endregion Idioma

        #region Controles

        private void button_LimpiarArbol_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.SelectedNode = null;
        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                ListaControles.Clear();
                BuscarControles(this.Controls);
                ActualizarTextosControles(idiomaSeleccionado);
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        private void ActualizarTextosControles(Idioma idioma)
        {
            try
            {
                var traducciones = Bll_Traduccion.ListarPorIdioma(idioma.Id);

                foreach (Control control in ListaControles)
                {
                    var traduccion = traducciones.FirstOrDefault(t => t.Palabra == control.Text);
                    if (traduccion != null)
                    {
                        control.Text = traduccion.TraduccionTexto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Hide();
        }

        private void button_CrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Nombre.Text == string.Empty) { MessageBox.Show("Complete el campo nombre"); return; }
                GrupoPermisos oGrupo = new GrupoPermisos(0, textBox_Nombre.Text);
                Bll_Permiso.AgregarGrupo(oGrupo);
                ActualizarCombos();
                ActualizarPermisos();
                textBox_Nombre.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private List<TreeNode> Nodos = new List<TreeNode>();

        public void cargarNodos(TreeNode tn)
        {
            Nodos.Add(tn);
            foreach (TreeNode t in tn.Nodes)
            {
                if (t.Nodes.Count > 0)
                {
                    cargarNodos(t);
                    Nodos.Add(t);
                }
                else
                {
                    Nodos.Add(t);
                }
            }
        }

        public bool ValidarNodo(Componente oComponente)
        {
            Nodos.Clear();
            cargarNodos(treeView1.Nodes[0]);
            foreach (TreeNode t in Nodos)
            {
                if (t.Text == oComponente.Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Componente oComponente = (Componente)comboBox_Permisos.SelectedItem;
                if (treeView1.Nodes.Count <= 0)// No hay Nodo Raiz
                {
                    if (oComponente is Permiso) { MessageBox.Show("Seleccione un grupo de permisos"); return; }

                    TreeNode nodo = new TreeNode();
                    nodo.Text = oComponente.Nombre;
                    nodo.Tag = (GrupoPermisos)oComponente;
                    treeView1.Nodes.Add(nodo);
                    return;
                }
                else// Hay Nodo Raiz
                {
                    if (treeView1.SelectedNode == null)
                    {
                        MessageBox.Show("Selecciones un nodo");
                        return;
                    }
                    if (ValidarNodo(oComponente))
                    {
                        MessageBox.Show("Este permiso ya esta asignado a este grupo");
                        return;
                    }

                    oComponente = (Componente)treeView1.SelectedNode.Tag;
                }
                if (oComponente is Permiso)// Nodo Raiz no es grupo
                {
                    MessageBox.Show("No se pueden agregar permisos a una hoja", "Error");
                    return;
                }

                GrupoPermisos Grupo = (GrupoPermisos)oComponente;
                Componente oPermiso = (Componente)comboBox_Permisos.SelectedItem;

                if (Bll_Permiso.ValidarBucle(Grupo, oPermiso))
                {
                    MessageBox.Show("Ya esta asignado a este permiso");
                    return;
                }
                Grupo.AgregarHijo(oPermiso);
                if (Bll_Permiso.Agregar(Grupo, oPermiso))
                {
                    MessageBox.Show("Se agrego el permiso " + oPermiso.Nombre + " al grupo " + Grupo.Nombre);
                }
                ActualizarCombos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_BorrarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Grupos.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos para borrar");
                    return;
                }
                GrupoPermisos oGrupo = (GrupoPermisos)comboBox_Grupos.SelectedItem;
                if (Bll_Permiso.BorrarGrupo(oGrupo))
                {
                    MessageBox.Show("Se elimino el grupo: " + oGrupo.Nombre);
                }
                ActualizarCombos();
                ActualizarPermisos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox_Grupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Grupos.SelectedIndex != -1)
            {
                treeView1.Nodes.Clear();
                GrupoPermisos oGrupo = (GrupoPermisos)comboBox_Grupos.SelectedItem;

                // Crear el nodo para el grupo seleccionado
                tn = new TreeNode();
                tn.Text = oGrupo.Nombre;
                tn.Tag = oGrupo;

                var permisosRecursivos = Bll_Permiso.ObtenerPermisosRecursivos(oGrupo.Id);
                AgregarPermisosAlTreeView(oGrupo, permisosRecursivos, tn);

                // Agregar el nodo del grupo al TreeView
                treeView1.Nodes.Add(tn);
                treeView1.ExpandAll();
            }
        }

        // Método para agregar permisos al TreeView de forma recursiva
        private void AgregarPermisosAlTreeView(GrupoPermisos grupoPadre, List<Componente> permisos, TreeNode parentNode)
        {
            // Filtramos solo los permisos o subgrupos que son hijos directos del grupo padre
            var hijosDirectos = grupoPadre.Permisos;

            foreach (var componente in hijosDirectos)
            {
                TreeNode node = new TreeNode
                {
                    Text = componente.Nombre,
                    Tag = componente
                };

                if (componente is GrupoPermisos subGrupo)
                {
                    // Llamar recursivamente para agregar los hijos del subgrupo
                    AgregarPermisosAlTreeView(subGrupo, subGrupo.Permisos, node);
                }

                // Agregar el nodo al nodo padre
                parentNode.Nodes.Add(node);
            }
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                GrupoPermisos Padre = null;
                if (treeView1.Nodes.Count < 1) { Padre = null; }
                else if (treeView1.SelectedNode.Parent != null)
                {
                    Padre = (GrupoPermisos)treeView1.SelectedNode.Parent.Tag;
                }
                Componente oComponente = (Componente)treeView1.SelectedNode.Tag;

                if (Bll_Permiso.Borrar(oComponente, Padre))
                {
                    MessageBox.Show("Se elimino el permiso seleccionado");
                }
                ActualizarCombos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_AsignarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Grupos.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos para asignar");
                    return;
                }
                GrupoPermisos oGrupo = (GrupoPermisos)comboBox_Grupos.SelectedItem;
                Usuario oUsuario = (Usuario)comboBox_Usuarios.SelectedItem;

                if (Bll_Permiso.AsignarGrupo(oGrupo, oUsuario))
                {
                    MessageBox.Show("Se agrego el permiso al usuario");
                    ActualizarPermisosAsignados();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_DesasignarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_PermisosAsignados.Items.Count == 0) { return; }
                GrupoPermisos oGrupo = (GrupoPermisos)comboBox_PermisosAsignados.SelectedItem;
                Usuario oUsuario = (Usuario)comboBox_Usuarios.SelectedItem;
                if (Bll_Permiso.DesAsignar(oGrupo, oUsuario))
                {
                    MessageBox.Show("Se le desasigno el permiso al usuario");
                    ActualizarPermisosAsignados();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Usuarios.SelectedIndex != -1)
            {
                comboBox_PermisosAsignados.DataSource = null;
                Usuario oUsuario = (Usuario)comboBox_Usuarios.SelectedItem;
                comboBox_PermisosAsignados.DataSource = Bll_Permiso.BuscarPermisosAsignados(oUsuario);
            }
        }

        #endregion Controles

        #region Carga de elementos

        public void ActualizarCombos()
        {
            comboBox_Grupos.DataSource = null;
            comboBox_Grupos.DataSource = Bll_Permiso.ListarGrupos();
        }

        public void ActualizarPermisos()
        {
            comboBox_Permisos.DataSource = null;
            comboBox_Permisos.DataSource = Bll_Permiso.ListarPermisos();
        }

        private TreeNode tn = new TreeNode();

        public Componente BuscarHijos(GrupoPermisos oGrupo, TreeNode n)
        {
            foreach (Componente c in oGrupo.Permisos)
            {
                if (c is GrupoPermisos)
                {
                    TreeNode node = new TreeNode();
                    node.Text = c.Nombre;
                    node.Tag = c;
                    GrupoPermisos grupo = (GrupoPermisos)BuscarHijos((GrupoPermisos)c, node);

                    if (n != null)
                    {
                        n.Nodes.Add(node);
                    }
                    else
                    {
                        tn.Nodes.Add(node);
                    }
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Text = c.Nombre;
                    node.Tag = c;
                    if (n != null)
                    {
                        n.Nodes.Add(node);
                    }
                    else
                    {
                        tn.Nodes.Add(node);
                    }
                }
            }
            return oGrupo;
        }

        public void ActualizarPermisosAsignados()
        {
            comboBox_PermisosAsignados.DataSource = null;
            Usuario oUsuario = (Usuario)comboBox_Usuarios.SelectedItem;
            comboBox_PermisosAsignados.DataSource = Bll_Permiso.BuscarPermisosAsignados(oUsuario);
        }

        public void ActualizarUsuarios()
        {
            comboBox_Usuarios.DataSource = null;
            comboBox_Usuarios.DataSource = Bll_Usuario.Listar();
        }

        #endregion Carga de elementos
    }
}