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
    public partial class frmGestorUsuarios : Form, IObservador
    {
        public frmGestorUsuarios()
        {
            InitializeComponent();
            Bll_Usuario = new BLL_USUARIO();
            sesion = SessionManager.GetInstance();
            ActualizarGrid();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            BuscarControles(this.Controls);
            Actualizar(oIdioma);
        }
        private BLL_USUARIO Bll_Usuario;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private SessionManager sesion;

        #region Controles de Usuario
        private void button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistro registro = new frmRegistro(null);
                registro.ShowDialog(null);
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario oUsuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
                if (oUsuario.Email == SessionManager.GetInstance().oUsuario.Email)
                {
                    MessageBox.Show("No se puede eliminar el usuario si esta logeado");
                }
                if (Bll_Usuario.Borrar(oUsuario))
                {
                    MessageBox.Show("Se elimino el usuario exitosamente", "Eliminacion exitosa", MessageBoxButtons.OK);

                    ActualizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la eliminacion", MessageBoxButtons.OK);
            }
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario oUsuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
                frmRegistro registro = new frmRegistro(oUsuario);
                registro.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Hide();
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

        private void button_Restaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Index == -1)
                {
                    MessageBox.Show("Seleccione un historial");
                }
                HistorialUsuario oHistorial = (HistorialUsuario)dataGridView2.CurrentRow.DataBoundItem;
                if (Bll_Usuario.Restaurar(oHistorial))
                {
                    MessageBox.Show("Se restauro el usuario");
                    ActualizarGrid();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Usuario oUsuario = dataGridView1.CurrentRow.DataBoundItem as Usuario;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = Bll_Usuario.ListarHistorial(oUsuario);
                dataGridView2.Columns["DV"].Visible = false;
            }
        }
        #endregion Controles de Usuario
        #region Actualizaciones
        public void ActualizarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Bll_Usuario.Listar();
            dataGridView1.Columns["Contraseña"].Visible = false;
            dataGridView1.Columns["DV"].Visible = false;
        }
        #endregion Actualizaciones
        #region Idiomas
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
        #endregion Idiomas
    }
}