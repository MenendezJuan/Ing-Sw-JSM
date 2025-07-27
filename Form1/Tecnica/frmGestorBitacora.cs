using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmGestorBitacora : Form, IObservador
    {
        public frmGestorBitacora()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            comboBox_Filtro.SelectedIndex = 0;
            comboBox_cobinado.SelectedIndex = 0;
            Bll_Usuario = new BLL_USUARIO();
            Bll_Bitacora = new BLL_BITACORA();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traducciones = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            comboBox_Usuarios.DataSource = Bll_Usuario.Listar();
            comboBox_Tipos.DataSource = Enum.GetValues(typeof(Enum_TiposBitacora));
        }

        private BLL_BITACORA Bll_Bitacora;
        private BLL_USUARIO Bll_Usuario;
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

                if (control.HasChildren)
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        if (controlChild.Tag != null)
                        {
                            string traduccion = Bll_Traducciones.BuscarTraduccion(controlChild.Tag.ToString(), idioma.Id);
                            if (!string.IsNullOrEmpty(traduccion))
                            {
                                controlChild.Text = traduccion;
                            }
                        }
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

        private void comboBox_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Filtro.SelectedIndex == 0)//Fecha
            {
                groupBox_PorUsuario.Visible = false;
                groupBox_PorTipo.Visible = false;
                groupBox_PorFecha.Visible = true;
            }
            if (comboBox_Filtro.SelectedIndex == 1)//Tipo
            {
                groupBox_PorUsuario.Visible = false;
                groupBox_PorTipo.Visible = true;
                groupBox_PorFecha.Visible = false;
            }
            if (comboBox_Filtro.SelectedIndex == 2)//Usuario
            {
                groupBox_PorUsuario.Visible = true;
                groupBox_PorTipo.Visible = false;
                groupBox_PorFecha.Visible = false;
            }
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Filtro.SelectedIndex == 0)//Fecha
                {
                    dataGridView1.DataSource = null;
                    if (dateTimePicker_Desde.Value.Date > dateTimePicker_Hasta.Value.Date)
                    {
                        MessageBox.Show("la fecha desde tiene que ser inferior o igual a Hasta");
                        return;
                    }
                    if (checkCombinado.Checked)
                    {
                        if (comboBox_cobinado.SelectedIndex == 0)//Tipo
                        {
                            dataGridView1.DataSource = Bll_Bitacora.FiltrarXFechaYTipo(dateTimePicker_Desde.Value.Date, dateTimePicker_Hasta.Value.Date, (Enum_TiposBitacora)comboBox_Tipos.SelectedItem);
                        }
                        if (comboBox_cobinado.SelectedIndex == 1)//Usuario
                        {
                            dataGridView1.DataSource = Bll_Bitacora.FiltrarXFechaYUsuario(dateTimePicker_Desde.Value.Date, dateTimePicker_Hasta.Value.Date, (Usuario)comboBox_Usuarios.SelectedItem);
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = Bll_Bitacora.FiltrarXFecha(dateTimePicker_Desde.Value.Date, dateTimePicker_Hasta.Value.Date);
                    }
                }
                if (comboBox_Filtro.SelectedIndex == 1)//Tipo
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Bll_Bitacora.FiltrarXTipo((Enum_TiposBitacora)comboBox_Tipos.SelectedItem);
                }
                if (comboBox_Filtro.SelectedIndex == 2)//Usuario
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Bll_Bitacora.FiltrarXUsuario((Usuario)comboBox_Usuarios.SelectedItem);
                }
            }
            catch (Exception) { }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCombinado.Checked)
            {
                groupBox_Combo.Visible = true;
                comboBox_Filtro.SelectedIndex = 0;
                comboBox_Filtro.Enabled = false;
            }
            else
            {
                groupBox_Combo.Visible = false;
                comboBox_Filtro.Enabled = true;
                groupBox_PorTipo.Visible = false;
                groupBox_PorUsuario.Visible = false;
            }
        }

        private void comboBox_cobinado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_cobinado.SelectedIndex == 0 && checkCombinado.Checked)
            {
                groupBox_PorTipo.Visible = true;
                groupBox_PorUsuario.Visible = false;
            }
            if (comboBox_cobinado.SelectedIndex == 1 && checkCombinado.Checked)
            {
                groupBox_PorTipo.Visible = false;
                groupBox_PorUsuario.Visible = true;
            }
        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        #endregion Controles de Usuario
    }
}