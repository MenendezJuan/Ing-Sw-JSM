using BEs;
using BEs.Clases;
using MPPs;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLLs
{
    public class BLL_USUARIO : IGeneric<Usuario>
    {
        public BLL_USUARIO()
        {
            Mpp_Usuario = new MPP_USUARIO();
            Mpp_Bitacora = new MPP_BITACORA();
            VerificarSeguridad();
        }

        private MPP_USUARIO Mpp_Usuario;
        private MPP_BITACORA Mpp_Bitacora;

        #region ABML

        public bool Agregar(Usuario entidad)
        {
            try
            {
                entidad.Contraseña = Seguridad.Hash(entidad.Contraseña);
                entidad.DV = Seguridad.CalcularDigitoVerificadorHorizontal(entidad);
                if (Mpp_Usuario.Agregar(entidad))
                {
                    Mpp_Usuario.ActualizarDigitoVertical(CalcularDigitoVertical());
                    return Mpp_Bitacora.Agregar(entidad, Enum_TiposBitacora.ABML, "Se creo un usuario");
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Borrar(Usuario entidad)
        {
            try
            {
                if (Mpp_Usuario.Borrar(entidad))
                {
                    Mpp_Usuario.ActualizarDigitoVertical(CalcularDigitoVertical());
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se elimino el usuario " + entidad.Id.ToString());
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Modificar(Usuario entidad)
        {
            try
            {
                entidad.Contraseña = Servicios.Seguridad.Hash(entidad.Contraseña);
                entidad.DV = Seguridad.CalcularDigitoVerificadorHorizontal(entidad);
                if (Mpp_Usuario.Modificar(entidad))
                {
                    Mpp_Usuario.ActualizarDigitoVertical(CalcularDigitoVertical());
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se modifico el usuario " + entidad.Id.ToString());
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> Lista = Mpp_Usuario.Listar();
                foreach (Usuario u in Lista)
                {
                    if (u.DV != Seguridad.CalcularDigitoVerificadorHorizontal(u))
                    {
                        throw new Exception("Digito verificador no coicide");
                    }
                }
                if (Lista != null)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listaron");
                    return Lista;
                }
                throw new Exception("No se encontraron usuarios");
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        #endregion ABML

        #region Login/>Logout

        public bool LogIn(string email, string contraseña)
        {
            try
            {
                Usuario usuario = new Usuario(email, contraseña);
                Usuario oUsuario = Mpp_Usuario.BuscarUsuarioPorCredenciales(usuario.Email); // Busca el usuario que coincida con el email
                usuario.Contraseña = Seguridad.Hash(usuario.Contraseña);
                usuario.DV = Seguridad.CalcularDigitoVerificadorHorizontal(usuario);

                if (oUsuario != null && oUsuario.Contraseña == usuario.Contraseña)
                {
                    if (oUsuario.DV != usuario.DV)
                    {
                        Mpp_Bitacora.Agregar(oUsuario, Enum_TiposBitacora.VALIDACION, "Validacion Digito");
                        return false;
                    }
                    Mpp_Bitacora.Agregar(oUsuario, Enum_TiposBitacora.INFO, "Login");
                    SessionManager sessionManager = SessionManager.GetInstance();
                    sessionManager.Login(oUsuario);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public void LogOut()
        {
            // Lógica para cerrar sesión
            Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.INFO, "LogOut");
            SessionManager.Logout(); // Resetear el usuario actual al cerrar sesión
        }

        #endregion Login/>Logout

        #region DV

        public string CalcularDigitoVertical()
        {
            List<Usuario> Usuarios = Mpp_Usuario.ListarUsuariosActivos();
            if (Usuarios.Count == 0) { return ""; }
            string DV = "";
            foreach (Usuario u in Usuarios)
            {
                DV += u.DV;
            }
            return Seguridad.Hash(DV);
        }

        public void VerificarSeguridad()
        {
            try
            {
                string DV = CalcularDigitoVertical();
                if (DV != Mpp_Usuario.VerificarSeguridad())
                {
                    throw new Exception("La base de datos fue comprometida");
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion DV

        #region Historial

        public bool Restaurar(HistorialUsuario oHistorial)
        {
            try
            {
                if (Mpp_Usuario.Restaurar(oHistorial))
                {
                    return Mpp_Usuario.ActualizarDigitoVertical(CalcularDigitoVertical());
                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<HistorialUsuario> ListarHistorial(Usuario oUsuario)
        {
            return Mpp_Usuario.ListarHistorial(oUsuario);
        }

        #endregion Historial
    }
}