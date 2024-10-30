using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmRegistro : Form
    {
        public frmRegistro(Usuario u)
        {
            InitializeComponent();
            Bll_Usuario = new BLL_USUARIO();
            if (u != null)
            {
                button_Registrarse.Text = "Modificar";
                textBox_Email.Text = u.Email;
                usuario = u;
            }
        }
        BLL_USUARIO Bll_Usuario;
        private Usuario usuario = null;

        #region Controles de Usuario
        private void button_Registrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if(usuario != null)
                {
                    Modificar();
                }
                else
                {
                    Agregar();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion Controles de Usuario
        #region Demas Funciones
        public void Agregar()
        {
            Usuario nuevoUsuario = new Usuario(textBox_Email.Text, textBox_Contraseña.Text);
            if (ValidarCampos(nuevoUsuario))
            {
                if (Bll_Usuario.Agregar(nuevoUsuario))
                {
                    MessageBox.Show("Registro exitoso.", "Éxito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario. Posiblemente el email ya esté en uso.", "Error");
                }
            }
        }

        public void Modificar()
        {
            usuario.Email = textBox_Email.Text; //validar correo ya en BD
            usuario.Contraseña = textBox_Contraseña.Text;

            if (ValidarCampos(usuario))
            {
                
                if (Bll_Usuario.Modificar(usuario))
                {
                    MessageBox.Show("Modificacion exitosa", "Éxito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario. Posiblemente el email ya esté en uso.", "Error");
                }
            }
        }

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
        #endregion Demas Funciones
    }
}
