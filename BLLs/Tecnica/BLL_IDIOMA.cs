using BEs;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs
{
    public class BLL_IDIOMA : IGeneric<Idioma>
    {
        private MPP_IDIOMA Mpp_Idioma;
        private MPP_BITACORA Mpp_Bitacora;
        private MPP_TRADUCCION Mpp_Traducion;

        public BLL_IDIOMA()
        {
            Mpp_Idioma = new MPP_IDIOMA();
            Mpp_Bitacora = new MPP_BITACORA();
            Mpp_Traducion = new MPP_TRADUCCION();
        }

        #region ABML

        public bool Agregar(Idioma entidad)
        {
            try
            {
                if (Mpp_Idioma.Agregar(entidad))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se creó un idioma");
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Borrar(Idioma entidad)
        {
            try
            {
                if (Mpp_Idioma.Borrar(entidad))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se eliminó el idioma " + entidad.Id.ToString());
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Modificar(Idioma entidad)
        {
            try
            {
                if (Mpp_Idioma.Modificar(entidad))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se modificó el idioma " + entidad.Id.ToString());
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<Idioma> ListarTodos()
        {
            try
            {
                return Mpp_Idioma.Listar();
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<Idioma> Listar()
        {
            try
            {
                List<Idioma> Lista = Mpp_Idioma.Listar();
                if (Lista != null)
                {
                    foreach (Idioma item in Lista)
                    {
                        item.Traducciones = Mpp_Traducion.ListarPorIdioma(item.Id);
                    }
                    return Lista;
                }
                throw new Exception("No se encontraron idiomas");
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        #endregion ABML
    }
}