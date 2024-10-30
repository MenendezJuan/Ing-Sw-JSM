using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmConfigurarIdioma : Form, IObservador
    {
        public frmConfigurarIdioma(Idioma idioma)
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            idiomaSeleccionado = idioma;
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traducciones = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            ActualizarGrid();
            tboxPalabra.ReadOnly = true;
        }

        private Idioma idiomaSeleccionado;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traducciones;
        private SessionManager sesion;
        private BindingList<string> palabrasBindingList;

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

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        #endregion Idiomas

        #region Extras

        private void CargarTraducciones()
        {
            try
            {
                var traducciones = Bll_Traducciones.ListarPorIdioma(idiomaSeleccionado.Id);
                dgvTraducciones.DataSource = null;
                dgvTraducciones.DataSource = traducciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las traducciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> ObtenerPalabrasSinTraduccion()
        {
            List<string> palabras = Bll_Traducciones.ListarPalabrasSinTraduccion(idiomaSeleccionado.Id);

            return palabras; // Asegurarse de que no haya duplicados
        }

        private void ObtenerPalabrasDeControles(Control.ControlCollection controls, List<string> palabras)
        {
            foreach (Control control in controls)
            {
                if (control is Button || control is Label || control is TextBox)
                {
                    palabras.Add(control.Text);
                }
                else if (control is DataGridView)
                {
                    foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
                    {
                        palabras.Add(column.HeaderText);
                    }
                }
                else if (control.HasChildren)
                {
                    ObtenerPalabrasDeControles(control.Controls, palabras);
                }
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                CargarTraducciones();

                var palabrasSinTraducir = ObtenerPalabrasSinTraduccion();
                palabrasBindingList = new BindingList<string>(palabrasSinTraducir);

                // Actualizar el DataGridView de palabras con el formato correcto
                dgvPalabras.DataSource = null;
                dgvPalabras.DataSource = palabrasBindingList.Select(p => new { Palabra = p }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            tboxPalabra.Clear();
            tboxTraduccion.Clear();
        }

        #endregion Extras

        #region Controles de Usuario

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTraducciones.CurrentRow != null && !string.IsNullOrWhiteSpace(tboxPalabra.Text) && !string.IsNullOrWhiteSpace(tboxTraduccion.Text))
                {
                    Traduccion traduccionSeleccionada = (Traduccion)dgvTraducciones.CurrentRow.DataBoundItem;
                    traduccionSeleccionada.Palabra = tboxPalabra.Text;
                    traduccionSeleccionada.TraduccionTexto = tboxTraduccion.Text;
                    Bll_Traducciones.Modificar(traduccionSeleccionada);
                    LimpiarCampos();
                    ActualizarGrid();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una traducción y complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxPalabra.Text) && !string.IsNullOrWhiteSpace(tboxTraduccion.Text))
                {
                    Traduccion nuevaTraduccion = new Traduccion
                    {
                        Palabra = tboxPalabra.Text,
                        TraduccionTexto = tboxTraduccion.Text,
                        IdiomaId = idiomaSeleccionado.Id
                    };

                    if (Bll_Traducciones.Agregar(nuevaTraduccion))
                    {
                        // Remover la palabra de la BindingList
                        palabrasBindingList.Remove(tboxPalabra.Text);

                        LimpiarCampos();
                        ActualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la traducción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxPalabra.Text) && !string.IsNullOrWhiteSpace(tboxTraduccion.Text))
                {
                    Traduccion traduccionAEliminar = new Traduccion
                    {
                        Palabra = tboxPalabra.Text,
                        TraduccionTexto = tboxTraduccion.Text,
                        IdiomaId = idiomaSeleccionado.Id
                    };

                    if (Bll_Traducciones.Borrar(traduccionAEliminar))
                    {
                        // Agregar la palabra de nuevo a la BindingList
                        palabrasBindingList.Add(traduccionAEliminar.Palabra);

                        LimpiarCampos();
                        ActualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la traducción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una traducción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTraducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTraducciones.CurrentRow != null)
            {
                Traduccion traduccionSeleccionada = (Traduccion)dgvTraducciones.CurrentRow.DataBoundItem;
                tboxPalabra.Text = traduccionSeleccionada.Palabra;
                tboxTraduccion.Text = traduccionSeleccionada.TraduccionTexto;
            }
        }

        private void ConfigurarIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            sesion.DesregistrarObservador(this);
        }

        private void dgvPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPalabras.Rows[e.RowIndex];
                tboxPalabra.Text = row.Cells["Palabra"].Value.ToString();
            }
        }

        private void dgvPalabras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPalabras.Rows[e.RowIndex];
                tboxPalabra.Text = row.Cells["Palabra"].Value.ToString();
            }
        }

        #endregion Controles de Usuario
    }
}