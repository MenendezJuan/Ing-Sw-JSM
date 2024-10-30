using BEs;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_BITACORA
    {
        public MPP_BITACORA()
        {
            oCnx = Conexion.Instance;
        }

        private Conexion oCnx;

        public bool Agregar(Usuario oUsuario, Enum_TiposBitacora tipoBitacora, string descripcion)
        {
            try
            {
                Hashtable Table = new Hashtable();
                Table.Add("@Fecha", DateTime.Now.Date);
                Table.Add("@Email", oUsuario.Email);
                Table.Add("@Accion", (int)tipoBitacora);
                Table.Add("@Descripcion", descripcion);

                return oCnx.Guardar("Guardar_Bitacora", Table);
            }
            catch (Exception ex) { throw ex; }
        }

        #region Filtros

        public List<Bitacora> FiltrarXFecha(DateTime Desde, DateTime Hasta)
        {
            try
            {
                Hashtable Parametros = new Hashtable();

                Parametros.Add("@Desde", Desde);
                Parametros.Add("@Hasta", Hasta);
                DataTable Table = oCnx.Leer("FiltrarXFecha", Parametros);
                List<Bitacora> Lista = new List<Bitacora>();
                foreach (DataRow row in Table.Rows)
                {
                    Usuario user = new Usuario((int)row["Id1"], row["Email"].ToString());
                    Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], user, row["Descripcion"].ToString());
                    Lista.Add(bit);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Bitacora> FiltrarXUsuario(Usuario oUsuario)
        {
            try
            {
                Hashtable Parametros = new Hashtable();

                Parametros.Add("@Usuario", oUsuario.Id);
                DataTable Table = oCnx.Leer("FiltrarXUsuario", Parametros);
                List<Bitacora> Lista = new List<Bitacora>();
                foreach (DataRow row in Table.Rows)
                {
                    Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], oUsuario, row["Descripcion"].ToString());
                    Lista.Add(bit);
                }
                return Lista;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Bitacora> FiltrarXTipo(Enum_TiposBitacora tiposBitacora)
        {
            try
            {
                if (tiposBitacora == Enum_TiposBitacora.TODO)
                {
                    return Listar();
                }
                Hashtable Parametros = new Hashtable();

                Parametros.Add("@Accion", (int)tiposBitacora);
                DataTable Table = oCnx.Leer("FiltrarXTipo", Parametros);
                List<Bitacora> Lista = new List<Bitacora>();
                foreach (DataRow row in Table.Rows)
                {
                    Usuario user = new Usuario((int)row["Id"], row["Email"].ToString());
                    Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], user, row["Descripcion"].ToString());
                    Lista.Add(bit);
                }
                return Lista;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Bitacora> FiltrarXFechaYUsuario(DateTime Desde, DateTime Hasta, Usuario oUsuario)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Desde", Desde);
            Parametros.Add("@Hasta", Hasta);
            Parametros.Add("@Usuario", oUsuario.Id);
            DataTable Table = oCnx.Leer("FiltrarXFechaYUsuario", Parametros);
            List<Bitacora> Lista = new List<Bitacora>();
            foreach (DataRow row in Table.Rows)
            {
                Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], oUsuario, row["Descripcion"].ToString());
                Lista.Add(bit);
            }
            return Lista;
        }

        public List<Bitacora> FiltrarXFechaYTipo(DateTime Desde, DateTime Hasta, Enum_TiposBitacora Tipo)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Desde", Desde);
            Parametros.Add("@Hasta", Hasta);
            Parametros.Add("@Tipo", (int)Tipo);
            DataTable Table = oCnx.Leer("FiltrarXFechaYTipo", Parametros);
            List<Bitacora> Lista = new List<Bitacora>();
            foreach (DataRow row in Table.Rows)
            {
                Usuario user = new Usuario((int)row["Id1"], row["Email"].ToString());
                Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], user, row["Descripcion"].ToString());
                Lista.Add(bit);
            }
            return Lista;
        }

        public List<Bitacora> Listar()
        {
            try
            {
                Hashtable Parametros = new Hashtable();
                DataTable Table = oCnx.Leer("Listar_Bitacoras", null);
                List<Bitacora> Lista = new List<Bitacora>();
                foreach (DataRow row in Table.Rows)
                {
                    Usuario user = new Usuario((int)row["Usuario"], row["Email"].ToString());
                    Bitacora bit = new Bitacora((int)row["Id"], (DateTime)row["Fecha"], (Enum_TiposBitacora)row["Accion"], user, row["Descripcion"].ToString());
                    Lista.Add(bit);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Filtros
    }
}