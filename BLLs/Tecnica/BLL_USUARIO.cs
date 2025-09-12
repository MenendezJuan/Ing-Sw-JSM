using BEs;
using BEs.Clases;
using BLLs.Tecnica;
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
            
            // Verificación global solo al login, no en gestión
            // var bllControlCambios = new BLL_CONTROLCAMBIOS();
            // bllControlCambios.VerificarSeguridadGlobal();
        }

        public BLL_USUARIO(bool verificarSeguridad)
        {
            Mpp_Usuario = new MPP_USUARIO();
            Mpp_Bitacora = new MPP_BITACORA();
            
            if (verificarSeguridad)
            {
                var bllControlCambios = new BLL_CONTROLCAMBIOS();
                bllControlCambios.VerificarSeguridadGlobal();
            }
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

        public List<Usuario> ListarParaGestion()
        {
            try
            {
                List<Usuario> Lista = Mpp_Usuario.Listar();
                if (Lista != null)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listaron usuarios (gestión)");
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

                if (oUsuario != null && oUsuario.Contraseña == usuario.Contraseña)
                {
                    string dvCalculado = Seguridad.CalcularDigitoVerificadorHorizontal(oUsuario);
                    
                    if (oUsuario.DV != dvCalculado)
                    {
                        Mpp_Bitacora.Agregar(oUsuario, Enum_TiposBitacora.VALIDACION, 
                            $"Validacion Digito FALLIDA - DV_BD: {oUsuario.DV}, DV_Calculado: {dvCalculado}");
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

            // Log de debug para ver qué usuarios se están procesando
            System.Diagnostics.Debug.WriteLine($"=== CÁLCULO DVV - Usuarios Activos Encontrados: {Usuarios.Count} ===");

            foreach (Usuario u in Usuarios)
            {
                System.Diagnostics.Debug.WriteLine($"Usuario ID: {u.Id}, Email: {u.Email}, DV: {u.DV ?? "NULL"}, DV Length: {u.DV?.Length ?? 0}");
                DV += u.DV;
            }

            System.Diagnostics.Debug.WriteLine($"Concatenación final: {DV}");
            System.Diagnostics.Debug.WriteLine($"Longitud concatenación: {DV.Length}");

            string hash = Seguridad.Hash(DV);
            System.Diagnostics.Debug.WriteLine($"Hash final: {hash}");

            return hash;
        }

        public void VerificarSeguridad()
        {
            try
            {
                string dvCalculado = CalcularDigitoVertical();
                string dvAlmacenado = Mpp_Usuario.VerificarSeguridad();

                if (dvCalculado != dvAlmacenado)
                {
                    // Crear mensaje detallado para debugging
                    string mensajeDetallado = $"VERIFICACIÓN DE SEGURIDAD FALLIDA:\n" +
                        $"- DV Calculado: {dvCalculado}\n" +
                        $"- DV Almacenado: {dvAlmacenado}\n" +
                        $"- Longitud Calculado: {dvCalculado?.Length ?? 0}\n" +
                        $"- Longitud Almacenado: {dvAlmacenado?.Length ?? 0}\n" +
                        $"- ¿Ambos no son null?: {(dvCalculado != null && dvAlmacenado != null)}\n" +
                        $"- ¿Valores exactamente iguales?: {string.Equals(dvCalculado, dvAlmacenado, StringComparison.Ordinal)}\n" +
                        $"- ¿Coinciden ignorando case?: {string.Equals(dvCalculado, dvAlmacenado, StringComparison.OrdinalIgnoreCase)}";

                    throw new Exception($"La base de datos fue comprometida. Detalles: {mensajeDetallado}");
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