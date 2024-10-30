using BEs;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs
{
    public class BLL_BITACORA
    {
        public BLL_BITACORA()
        {
            Mpp_Bitacora = new MPP_BITACORA();
        }

        private MPP_BITACORA Mpp_Bitacora;

        #region Filtros

        public List<Bitacora> FiltrarXUsuario(Usuario oUsuario)
        {
            try
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por usuario"); Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por usuario");
                return Mpp_Bitacora.FiltrarXUsuario(oUsuario);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Bitacora> FiltrarXFecha(DateTime Desde, DateTime Hasta)
        {
            try
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por Fecha");
                return Mpp_Bitacora.FiltrarXFecha(Desde, Hasta);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Bitacora> FiltrarXTipo(Enum_TiposBitacora Tipo)
        {
            try
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por tipo");
                return Mpp_Bitacora.FiltrarXTipo(Tipo);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Bitacora> FiltrarXFechaYUsuario(DateTime Desde, DateTime Hasta, Usuario oUsuario)
        {
            Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por Fecha y Usuario");
            return Mpp_Bitacora.FiltrarXFechaYUsuario(Desde, Hasta, oUsuario);
        }

        public List<Bitacora> FiltrarXFechaYTipo(DateTime Desde, DateTime Hasta, Enum_TiposBitacora Tipo)
        {
            Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.FILTRAR, "Filtra por Fecha y Tipo");
            return Mpp_Bitacora.FiltrarXFechaYTipo(Desde, Hasta, Tipo);
        }

        #endregion Filtros
    }
}