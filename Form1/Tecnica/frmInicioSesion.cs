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
            Bll_Usuario = new BLL_USUARIO(true);
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

        private List<Control> ListaControles = new List<Control>();

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
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", BLLs.Tecnica.ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", BLLs.Tecnica.ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bool usuarioValidado = Bll_Usuario.LogIn(textBox_Email.Text, textBox_Contraseña.Text);
                if (usuarioValidado)
                {
                    SessionManager.GetInstance().Permisos = Bll_Permiso.BuscarPermisosAsignados(SessionManager.GetInstance().oUsuario);

                    MessageBox.Show("Inicio de sesión exitoso.", BLLs.Tecnica.ConstantesUI.Titulos.Informacion);
                    frmMenuPrincipal menuPrincipal = new frmMenuPrincipal();
                    //frmReporteInteligente menuPrincipal = new frmReporteInteligente();
                    //frmInicioOrden menuPrincipal = new frmInicioOrden();
                    //frmBackupRestore menuPrincipal = new frmBackupRestore();
                    menuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email o contraseña incorrectos.", BLLs.Tecnica.ConstantesUI.Titulos.Error);
                }
            }
        }

        /// <summary>
        /// Verifica la integridad de la base de datos (DVH y DVV) al iniciar sesión
        /// </summary>
        /// <returns>True si la integridad es correcta, False si hay problemas</returns>
        private bool VerificarIntegridadBaseDatos()
        {
            try
            {
                var bllIntegridad = new BLL_INTEGRIDAD();
                bool integridadOK = bllIntegridad.VerificarIntegridadBaseDatos(out List<BEs.InconsistenciaIntegridad> errores);

                if (!integridadOK && errores != null && errores.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"⚠️ ALERTA DE SEGURIDAD ⚠️\n\n" +
                        $"Se detectaron {errores.Count} inconsistencias en los dígitos verificadores.\n\n" +
                        $"Esto indica que la base de datos fue modificada externamente.\n" +
                        $"Es necesario corregir estos errores antes de continuar.\n\n" +
                        $"¿Desea abrir el módulo de corrección ahora?",
                        "Error de Integridad Detectado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        var usuarioLogueado = SessionManager.GetInstance().oUsuario;
                        bool esAdmin = VerificarSiEsAdmin(usuarioLogueado);

                        if (esAdmin)
                        {
                            var frmIntegridad = new CheeseLogix.Tecnica.frmVerificacionIntegridad();
                            frmIntegridad.ShowDialog();

                            bool integridadCorregida = bllIntegridad.VerificarIntegridadBaseDatos(out errores);

                            if (!integridadCorregida)
                            {
                                MessageBox.Show(
                                    "Aún existen inconsistencias. No se puede continuar.\n\n" +
                                    "Por seguridad, la sesión será cerrada.",
                                    "Integridad No Corregida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return false;
                            }

                            MessageBox.Show(
                                "✓ Integridad corregida exitosamente.",
                                "Corrección Exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "⚠️ ACCESO DENEGADO ⚠️\n\n" +
                                "Solo el administrador puede corregir inconsistencias de integridad.\n\n" +
                                "La sesión se cerrará por seguridad.",
                                "Sin Permisos de Administrador",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "No se puede iniciar sesión sin corregir los errores de integridad.\n\n" +
                            "Por seguridad, la sesión será cerrada.",
                            "Inicio de Sesión Cancelado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return false;
                    }
                }

                return true; // Integridad OK o corregida
            }
            catch (Exception ex)
            {
                // Si hay error en la verificación, registrar pero permitir continuar
                System.Diagnostics.Debug.WriteLine($"Error en verificación DV: {ex.Message}");
                MessageBox.Show(
                    $"Advertencia: No se pudo verificar la integridad de la base de datos.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"La aplicación continuará en modo normal.",
                    "Advertencia de Verificación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return true; // Permitir continuar si falla la verificación
            }
        }

        /// <summary>
        /// Verifica si un usuario es administrador
        /// </summary>
        private bool VerificarSiEsAdmin(Usuario usuario)
        {
            try
            {
                if (usuario == null) return false;

                var permisos = SessionManager.GetInstance().Permisos;

                if (permisos != null)
                {
                    foreach (var permiso in permisos)
                    {
                        if (permiso.Id == 26 ||
                            permiso.Nombre.Contains("ADMIN") ||
                            permiso.Nombre.Contains("GestionUsuarios") ||
                            permiso.Nombre.Contains("GestionPermisos"))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void label_Registrarse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por favor, comuníquese con el administrador para registrarse.",
                            BLLs.Tecnica.ConstantesUI.Titulos.Informacion,
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
