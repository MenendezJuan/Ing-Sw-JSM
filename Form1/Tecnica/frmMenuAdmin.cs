using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmMenuAdmin : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        public frmMenuAdmin()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
        }

        List<Control> ListaControles = new List<Control>();
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

        #region Permisos
        public void Buscar(Componente c)
        {
            GrupoPermisos grupo = (GrupoPermisos)c;
            foreach (Componente p in grupo.Permisos)
            {
                if (p is GrupoPermisos)
                {
                    Buscar(p);
                    Comprobar(p);
                }
                else
                {
                    Comprobar(p);
                }
            }
        }

        public void Comprobar(Componente p)
        {
            foreach (Control c in ListaControles)
            {
                if (c.Tag != null && c.Tag.ToString() == p.Nombre)
                {
                    c.Visible = true;
                }
            }
        }
        #endregion Permisos
        #region Idiomas
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
        #endregion Idiomas
        #region Controles de Usuario
        private void button_Usuarios_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pForm = Owner as frmMenuPrincipal;
            frmGestorUsuarios gestorUsuarios = new frmGestorUsuarios();

            if (pForm != null)
            {
                pForm.AddOwnedForm(gestorUsuarios);
                pForm.FormHijo(gestorUsuarios);
            }
            gestorUsuarios.Show();
        }

        private void button_Bitacora_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pForm = Owner as frmMenuPrincipal;
            frmGestorBitacora gestorBitacora = new frmGestorBitacora();

            if (pForm != null)
            {
                pForm.AddOwnedForm(gestorBitacora);
                pForm.FormHijo(gestorBitacora);
            }
            gestorBitacora.Show();
        }

        private void button_Permisos_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pForm = Owner as frmMenuPrincipal;
            frmGestorPermisos gestorPermisos = new frmGestorPermisos();

            if (pForm != null)
            {
                pForm.AddOwnedForm(gestorPermisos);
                pForm.FormHijo(gestorPermisos);
            }
            gestorPermisos.Show();
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

        private void btnIdioma_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pForm = Owner as frmMenuPrincipal;
            frmGestorIdiomas gestorIdiomas = new frmGestorIdiomas();
            pForm.AddOwnedForm(gestorIdiomas);
            pForm.FormHijo(gestorIdiomas);
            gestorIdiomas.Show();

        }

        private void MenuInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void button_Salir_Click_1(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            SessionManager.Logout();
            Cerrar();
        }
        #endregion Controles de Usuario
        #region Extras
        int i = 0;
        public void Cerrar()
        {
            if (i == 0)
            {
                i++;
                this.Close();
            }
        }
        #endregion Extras

        private void frmMenuAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}