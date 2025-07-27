using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmInicioSesion : Form, IObservador
    {
        private SessionManager sesion;
        public frmInicioSesion()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Permiso = new BLL_PERMISO();
            Bll_Usuario = new BLL_USUARIO();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            BuscarControles(this.Controls);
        }
        private BLL_USUARIO Bll_Usuario;
        private BLL_PERMISO Bll_Permiso;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        List<Control> ListaControles = new List<Control>();

        public void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                if (c.Tag != null)
                {
                    ListaControles.Add(c);
                }

                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }


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
        private void button_IniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario(textBox_Email.Text, textBox_Contraseña.Text);
            if (ValidarCampos(oUsuario))
            {
                // Intentar iniciar sesión utilizando las credenciales y el método actualizado
                bool usuarioValidado = Bll_Usuario.LogIn(textBox_Email.Text, textBox_Contraseña.Text);
                if (usuarioValidado)
                {
                    SessionManager.GetInstance().Permisos = Bll_Permiso.BuscarPermisosAsignados(SessionManager.GetInstance().oUsuario);
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito");
                    frmMenuPrincipal menuPrincipal = new frmMenuPrincipal();
                    menuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email o contraseña incorrectos.", "Error");
                }
            }
        }

        private void label_Registrarse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por favor, comuníquese con el administrador para registrarse.",
                            "Registro Requerido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void InicioSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            string mySetting = ConfigurationManager.AppSettings["DebugMode"];

            if (mySetting == "S")
            {
                textBox_Email.Text = "tutu@gmail.com";
                textBox_Contraseña.Text = "tutu@gmail.com";
            }
        }
        #endregion Controles de Usuario
        #region Validaciones
        public bool ValidarCampos(Usuario oUsuario)
        {
            errorProvider1.Clear();
            var contexto = new ValidationContext(oUsuario, null, null);
            var resultados = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(oUsuario, contexto, resultados, true);
            if (!isValid)
            {
                foreach (var validationResult in resultados)
                {
                    var memberName = validationResult.MemberNames.FirstOrDefault();
                    errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    errorProvider1.SetError(ObtenerControl(memberName), validationResult.ErrorMessage);
                }
                return false;
            }
            return true;
        }

        private Control ObtenerControl(string propertyName)
        {
            foreach (Control control in Controls)
            {
                if (control.Name.StartsWith("textBox_" + propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    return control;
                }
            }
            return null;
        }
        #endregion Validaciones

        private void cboxIdiomas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                sesion.CambiarIdioma(idiomaSeleccionado);
                ListaControles.Clear();
                BuscarControles(this.Controls);
                ActualizarTextosControles(idiomaSeleccionado);
            }
        }
    }
}