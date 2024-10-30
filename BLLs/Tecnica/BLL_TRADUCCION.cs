using BEs;
using BEs.Interfaces;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs
{
    public class BLL_TRADUCCION : IGeneric<Traduccion>
    {
        private MPP_TRADUCCION Mpp_Traduccion;
        private MPP_BITACORA Mpp_Bitacora;

        public BLL_TRADUCCION()
        {
            Mpp_Traduccion = new MPP_TRADUCCION();
            Mpp_Bitacora = new MPP_BITACORA();
        }

        #region ABML

        public bool Agregar(Traduccion entidad)
        {
            try
            {
                return Mpp_Traduccion.Agregar(entidad);
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Borrar(Traduccion entidad)
        {
            try
            {
                return Mpp_Traduccion.Borrar(entidad);
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public bool Modificar(Traduccion entidad)
        {
            try
            {
                if (Mpp_Traduccion.Modificar(entidad))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se modificó una traducción");
                }
                return false;
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<ITraduccion> ListarPorIdioma(int idiomaId)
        {
            try
            {
                return Mpp_Traduccion.ListarPorIdioma(idiomaId);
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<string> ListarPalabrasSinTraduccion(int idiomaId)
        {
            try
            {
                return Mpp_Traduccion.ListarPalabrasSinTraduccion(idiomaId);
            }
            catch (Exception ex)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, ex.Message);
                throw ex;
            }
        }

        public List<Traduccion> Listar()
        {
            throw new NotImplementedException();
        }

        public string BuscarTraduccion(string tag, int idiomaId)
        {
            try
            {
                return Mpp_Traduccion.BuscarTraduccion(tag, idiomaId);
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