using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGestorIdiomas : Form, IObservador
    {
        public frmGestorIdiomas()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traducciones = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            ActualizarGrid();
        }

        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traducciones;
        private SessionManager sesion;

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

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traducciones.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }
            }

            RecorrerDataGridTraduccion(idioma);

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        public void RecorrerDataGridTraduccion(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Tag != null)
                        {
                            string traduccion = Bll_Traducciones.BuscarTraduccion(column.Tag.ToString(), idioma.Id);
                            if (!string.IsNullOrEmpty(traduccion))
                            {
                                column.HeaderText = traduccion;
                            }
                        }
                    }
                }
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

        #endregion Idiomas

        #region Controles de Usuario

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIdiomas.CurrentRow != null)
                {
                    Idioma idiomaSeleccionado = (Idioma)dgvIdiomas.CurrentRow.DataBoundItem;
                    frmConfigurarIdioma configurarIdiomaForm = new frmConfigurarIdioma(idiomaSeleccionado);
                    configurarIdiomaForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un idioma para configurar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvIdiomas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                Actualizar(idiomaSeleccionado);
            }
        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                Actualizar(idiomaSeleccionado);
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Hide();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvIdiomas.CurrentRow != null && !string.IsNullOrWhiteSpace(tboxNombre.Text))
                {
                    Idioma idiomaSeleccionado = (Idioma)dgvIdiomas.CurrentRow.DataBoundItem;
                    idiomaSeleccionado.Nombre = tboxNombre.Text;
                    Bll_Idioma.Modificar(idiomaSeleccionado);
                    CargarIdiomas();
                    LimpiarCampos();
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un idioma y complete el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvIdiomas.CurrentRow != null)
                {
                    Idioma idiomaSeleccionado = (Idioma)dgvIdiomas.CurrentRow.DataBoundItem;
                    Bll_Idioma.Borrar(idiomaSeleccionado);
                    CargarIdiomas();
                    LimpiarCampos();
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un idioma para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GestorIdiomas_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            sesion.DesregistrarObservador(this);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxNombre.Text))
                {
                    Idioma nuevoIdioma = new Idioma
                    {
                        Nombre = tboxNombre.Text
                    };
                    Bll_Idioma.Agregar(nuevoIdioma);
                    CargarIdiomas();
                    LimpiarCampos();
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un nombre para el idioma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Controles de Usuario

        #region Extras

        private void ActualizarGrid()
        {
            dgvIdiomas.DataSource = null;
            dgvIdiomas.DataSource = Bll_Idioma.Listar();
            dgvIdiomas.Columns["Traducciones"].Visible = false;
            dgvIdiomas.Columns["Nombre"].Tag = "NombreIdioma_column";
        }

        private void LimpiarCampos()
        {
            tboxNombre.Clear();
        }

        #endregion Extras
    }
}